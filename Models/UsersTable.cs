using System;
using LinqToDB.Mapping;
using MySql.Data.MySqlClient;

namespace GetDrinxAdmin.Models
{  
    
    public partial class User
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

        private string _Email;
        [Column(Storage = "_Email")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }


        private string _SignInCount;
        [Column(Storage = "_SignInCount")]
        public string SignInCount
        {
            get
            {
                return this._SignInCount;
            }
            set
            {
                this._SignInCount = value;
            }
        }

        private string _LastSignInTime;
        [Column(Storage = "_LastSignInTime")]
        public string LastSignInTime
        {
            get
            {
                return this._LastSignInTime;
            }
            set
            {
                this._LastSignInTime = value;
            }
        }

        private string _LastSignInIP;
        [Column(Storage = "_LastSignInIP")]
        public string LastSignInIP
        {
            get
            {
                return this._LastSignInIP;
            }
            set
            {
                this._LastSignInIP = value;
            }
        }

        private string _CreatedDate;
        [Column(Storage = "_CreatedDate")]
        public string CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this._CreatedDate = value;
            }
        }

        private string _UpdatedDate;
        [Column(Storage = "_UpdatedDate")]
        public string UpdatedDate
        {
            get
            {
                return this._UpdatedDate;
            }
            set
            {
                this._UpdatedDate = value;
            }
        }


        private string _FirstName;
        [Column(Storage = "_FirstName")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        private string _LastName;
        [Column(Storage = "_LastName")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        private string _Gender;
        [Column(Storage = "_Gender")]
        public string Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
            }
        }

        private string _Status;
        [Column(Storage = "_Status")]
        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }


        private string _Age;
        [Column(Storage = "_Age")]
        public string Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                this._Age = value;
            }
        }

        private string _ProfileDescription;
        [Column(Storage = "_ProfileDescription")]
        public string ProfileDescription
        {
            get
            {
                return this._ProfileDescription;
            }
            set
            {
                this._ProfileDescription = value;
            }
        }
        

        private string _ImageURL;
        [Column(Storage = "_ImageURL")]
        public string ImageURL
        {
            get
            {
                return this._ImageURL;
            }
            set
            {
                this._ImageURL = value;
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
                    string connstring = string.Format("Server=IP; Port=PORT; database={0}; UID=USER; password=PASSWORD”, databaseName);
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

