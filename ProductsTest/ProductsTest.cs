using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Net;
using ProductApp.Controllers;
using ProductApp.Models;
using System.Collections.Generic;
using ProductApp.Repository;

namespace ProductsTest
{
    [TestClass]
    public class ProductsTest
    {
        private DiffController controller;
        private LeftRepository leftRepository;

        [TestInitialize]
        public void Setup()
        {
            controller = new DiffController();
            leftRepository = new LeftRepository();
        }

        //[TestMethod]
        //public void ApiShouldIncludeItem()
        //{
        //    int count = GetLeftProducts().Count;
        //    AddProductLeft(count + 1, CreateBase64Data(count + 1, "Axe"));
        //    int newCount = GetLeftProducts().Count;
        //    Assert.AreNotEqual(count, newCount);

        //}
        [TestMethod]
        public void GenerateBase64()
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("teste1234");
            var any = System.Convert.ToBase64String(plainTextBytes);
        }

        public void ApiShouldReturnItems()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:49591/v1/products/3/right");
            request.Method = "GET";
            request.ContentType = "text/plain; charset=utf-8";
            var resp = request.GetResponse();
        }

        private List<Base64Data> GetLeftProducts()
        {
            return leftRepository.GetAll();
        }
        private Base64Data CreateBase64Data(int id, string value)
        {
            Base64Data newBase64Data = new Base64Data();
            newBase64Data.Id = id;
            //newBase64Data.Base64Value = System.Text.Encoding.UTF8.GetBytes(value);
            newBase64Data.Base64Value = value;
            return newBase64Data;
        }

        //private void AddProductLeft(int id, Base64Data value)
        //{
        //    controller.Left(id, System.Convert.ToBase64String(value.Base64Value));
        //}
        //private void AddProductLeft(int id, Base64Data value)
        //{
        //    controller.Left(id, new System.Net.Http.HttpRequestMessage( value.Base64Value);
        //}

        //private void AddProductRight(int id, Base64Data value)
        //{
        //    //controller.Right(id, System.Convert.ToBase64String(value.Base64Value));
        //    controller.Right(id, value.Base64Value);
        //}
    }
}
