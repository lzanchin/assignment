using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Repository
{
    public class Database
    {
        private static Database database = null;

        public List<Product> ProductsRight = null;
        public List<Product> ProductsLeft = null;

        public static Database GetInstance()
        {
            if (Database.database == null)
            {
                Database.database = new Database();
                Database.database.ProductsRight = new List<Product>()
                {
                    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75 },
                    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99 }
                };

                Database.database.ProductsLeft = new List<Product>()
                {
                    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75 },
                    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 15.99 }
                };
            }

            return Database.database;
        }
    }
}