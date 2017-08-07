using System.Web.Mvc;
using MySql.Data.MySqlClient;
using GetDrinxAdmin.Models;
using LinqToDB.Mapping;


namespace GetDrinxAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // need to bring in: image, full name, role, created date, status, email 

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "YourDatabase";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT col0,col1 FROM YourTable";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                }
            }


            return View();
        }

       
    }
}