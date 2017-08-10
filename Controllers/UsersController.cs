using System.Web.Mvc;
using MySql.Data.MySqlClient;
using GetDrinxAdmin.Models;
using System.Collections.Generic;


namespace GetDrinxAdmin.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            //create list to hold all users          
            List<User> users = new List<User>();

            // connect to database
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "getdrinxstg_db";
            if (dbCon.IsConnect())
            {
                //query from the database  and loob through the results so that they can be stored
                string query = "SELECT id, email, sign_in_count, last_sign_in_at, last_sign_in_ip, created_at, updated_at, first_name, last_name, gender, IFNULL(status,0), age, IFNULL(about,'') FROM users WHERE last_sign_in_at IS NOT NULL AND id > 125";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create a new user
                    User user = new User(); 

                    //store the users data
                    user.UserID = reader.GetString(0);
                    user.Email = reader.GetString(1);
                    user.SignInCount = reader.GetString(2);
                    user.LastSignInTime = reader.GetString(3);
                    user.LastSignInIP = reader.GetString(4);
                    user.CreatedDate = reader.GetString(5);
                    user.UpdatedDate = reader.GetString(6);
                    user.FirstName = reader.GetString(7);
                    user.LastName = reader.GetString(8);
                    user.Gender = reader.GetString(9);
                    user.Status = reader.GetString(10);
                    user.Age = reader.GetString(11);
                    user.ProfileDescription = reader.GetString(12) ;

                    // add this user to the users list
                    users.Add(user);
                }
            }


            ViewBag.users = users;

            return View();
        }

       
    }
}