using ProductApp.Models;
using ProductApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApp.Controllers
{
    public class DiffController : ApiController
    {
        //List<Product> products = new List<Product>
        //{
        //    new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
        //    new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
        //    new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        //};

        ProductsLeftRepository repositoryLeft = new ProductsLeftRepository();
        ProductsRightRepository repositoryRight = new ProductsRightRepository();

        [HttpPost]
        public IHttpActionResult Right(int id, [FromBody] Product product)
        {
            product.Id = id;
            repositoryRight.Add(product);
            return Ok("Data saved");
        }
        [HttpPost]
        public IHttpActionResult Left(int id, [FromBody] Product product)
        {
            product.Id = id;
            repositoryLeft.Add(product);
            return Ok("Data saved");
        }
        public IHttpActionResult GetAllProducts()
        {
            JsonResponse response = new JsonResponse();
            response.LeftList = repositoryLeft.GetAll();
            response.RightList = repositoryRight.GetAll();
            return Ok(response);
        }
    }
}
