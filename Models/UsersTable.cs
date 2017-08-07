using System;

using LinqToDB.Mapping;
using MySql.Data.MySqlClient;

namespace GetDrinxAdmin.Models
{
    [Table(Name = "Users")]
    public class User
    {

        private string _UserID;
        [Column(IsPrimaryKey = true, Storage = "_UserID")]
        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }

        }

        private string _FullName;
        [Column(Storage = "_FullName")]
        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this._FullName = value;
            }
        }
    }



    public class DBConnection
        {
            private DBConnection()
            {
            }

            private string databaseName = string.Empty;
            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            public string Password { get; set; }
            private MySqlConnection connection = null;
            public MySqlConnection Connection
            {
                get { return connection; }
            }

            private static DBConnection _instance = null;
            public static DBConnection Instance()
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }

            public bool IsConnect()
            {
                bool result = true;
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        result = false;
                    string connstring = string.Format("Server=50.112.69.94; database={0}; UID=getdrinxown_usr; password=your password", databaseName);
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                    result = true;
                }

                return result;
            }

            public void Close()
            {
                connection.Close();
            }
        }

   

    }

