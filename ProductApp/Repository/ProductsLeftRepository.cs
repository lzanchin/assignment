using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Repository
{
    public class ProductsLeftRepository
    {
        
        public Product GetById(int id)
        {
            Product entity = Database.GetInstance().ProductsLeft.Where(s => s.Id == id).FirstOrDefault();
            return entity;
        }

        public List<Product> GetAll()
        {
            return Database.GetInstance().ProductsLeft;
        }

        public void Add(Product product)
        {
            Save(product);
        }
        public void Edit(Product product)
        {
            Save(product);
        }

        private void Save(Product product)
        {
            Product existentProduct = GetById(product.Id);
            if (existentProduct != null)
            {
                Database.GetInstance().ProductsLeft.Remove(existentProduct);
            }
            Database.GetInstance().ProductsLeft.Add(product);
        }
    }
}