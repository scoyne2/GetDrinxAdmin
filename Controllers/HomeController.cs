using System.Web.Mvc;
using System;
using System.Globalization;
using MySql.Data.MySqlClient;
using GetDrinxAdmin.Models;
using System.Collections.Generic;
using System.Linq;

namespace GetDrinxAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View("Index");
        }

     
        public JsonResult GetStats()
        {
        

            // make an array containing the names of the last three months       
            var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);
            var lastMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Today.AddMonths(-1).Month);
            var monthBeforeLast = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Today.AddMonths(-2).Month);
            var monthArray = "['" + monthBeforeLast + "']" + "['" + lastMonth + "']" + "['" + currentMonth + "']";


            // make an array with the count of logins in the last three months            
            List<MonthlyStats> monthlyStats = new List<MonthlyStats>();

            // connect to database
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "getdrinxstg_db";
            if (dbCon.IsConnect())
            {
                //query from the database and loop through the results so that they can be stored
                string query = @"
                                SELECT SUM(x.Logins), SUM(x.Registrations), DATE_FORMAT(x.Date,'%M') as Date
                                FROM
                                (
                                    SELECT COALESCE(a.LoginCount,0) as Logins, COALESCE(b.RegistrationCount,0) as Registrations, a.Date as Date
                                    FROM
                                    (
                                    SELECT COUNT(*) as LoginCount, DATE(last_sign_in_at) as Date
                                    FROM users u1
                                    WHERE last_sign_in_at IS NOT NULL
                                    AND last_sign_in_at BETWEEN CURDATE() - INTERVAL 90 DAY AND CURDATE()
                                    GROUP BY DATE(last_sign_in_at)
                                    ) a

                                    CROSS JOIN

                                    (
                                    SELECT COUNT(*) as RegistrationCount, DATE(created_at) as Date
                                    FROM users u2
                                    WHERE created_at IS NOT NULL
                                    AND created_at BETWEEN CURDATE() - INTERVAL 90 DAY AND CURDATE()
                                    GROUP BY DATE(created_at)
                                    ) b
                                    on a.Date = b.Date
                                )x
                                GROUP BY  DATE_FORMAT(x.Date,'%M')
                                ORDER BY x.Date ASC
                                ";

                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create a new monthly stat record
                    MonthlyStats monthlyStat = new MonthlyStats();

                    //store the users data
                    monthlyStat.Logins = reader.GetString(0);
                    monthlyStat.Registrations = reader.GetString(1);
                    monthlyStat.Date = reader.GetString(2);                   

                    // add this user to the users list
                    monthlyStats.Add(monthlyStat);
                }
                reader.Close();

            }

            // make an array with the count of registrations in the last three months


            return   Json(monthlyStats, JsonRequestBehavior.AllowGet);
        }



    }
}