using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Repository
{
    public class Database
    {
        /// <summary>
        /// In memory database to store the data sent in the requests
        /// </summary>
        private static Database database = null;
        public List<Base64Data> RightData = null;
        public List<Base64Data> LeftData = null;

        public static Database GetInstance()
        {
            if (Database.database == null)
            {
                Database.database = new Database();
                Database.database.RightData = new List<Base64Data>();
                Database.database.LeftData = new List<Base64Data>();
            }

            return Database.database;
        }
    }
}