using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Repository
{
    /// <summary>
    /// This class is responsible to handle the interactions with the 'database'
    /// </summary>
    public class LeftRepository
    {
        
        public Base64Data GetById(int id)
        {
            Base64Data entity = Database.GetInstance().LeftData.Where(s => s.Id == id).FirstOrDefault();
            return entity;
        }

        public List<Base64Data> GetAll()
        {
            return Database.GetInstance().LeftData;
        }

        public void Add(Base64Data product)
        {
            Save(product);
        }
        public void Edit(Base64Data product)
        {
            Save(product);
        }

        private void Save(Base64Data product)
        {
            Base64Data existentProduct = GetById(product.Id);
            if (existentProduct != null)
            {
                Database.GetInstance().LeftData.Remove(existentProduct);
            }
            Database.GetInstance().LeftData.Add(product);
        }
    }
}