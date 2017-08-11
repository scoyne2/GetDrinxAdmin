using System;

namespace GetDrinxAdmin.Models
{

    public class MonthlyStats
    {
        

        private string _StatId;
        public string StatId
        {
            get
            {
                return this._StatId;
            }
            set
            {
                this._StatId = value;
            }

        }


        private string _Date;
        public string Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this._Date = value;
            }

        }

       
        private string _Registrations;
        public string Registrations
        {
            get
            {
                return this._Registrations;
            }
            set
            {
                this._Registrations = value;
            }

        }

        private string _Logins;
        public string Logins
        {
            get
            {
                return this._Logins;
            }
            set
            {
                this._Logins = value;
            }

        }


    }
}

    