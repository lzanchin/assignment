using ProductApp.Domain;
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
        //Initialize the repositories for both left and right
        LeftRepository repositoryLeft = new LeftRepository();
        RightRepository repositoryRight = new RightRepository();

        /// <summary>
        /// Action to handle the data being sent to the Right Endpoint.
        /// The endpoint will receive and save the data in the database.
        /// Same behavior for both endpoints
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Right(int id, HttpRequestMessage value)
        {
            var base64Text = value.Content.ReadAsStringAsync().Result;
            Base64Data product = new Base64Data();
            product.Id = id;
            product.Base64Value = base64Text;
            repositoryRight.Add(product);
            return Ok("Data saved");
        }
        [HttpPost]
        public IHttpActionResult Left(int id, HttpRequestMessage value)
        {
            var base64Text = value.Content.ReadAsStringAsync().Result;
            Base64Data product = new Base64Data();
            product.Id = id;
            product.Base64Value = base64Text;
            repositoryLeft.Add(product);
            return Ok("Data saved");
        }
        /// <summary>
        /// Endpoint that will actually compare right and left based in the id sent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Diff(int id)
        {
            DiffService diff = new DiffService();
            var response = diff.Compare(id);
            return Ok(response);
        }

        //Todo - Try to implement a method to get all data
        //public IHttpActionResult GetList()
        //{
        //    JsonLists response = new JsonLists();
        //    response.LeftList = repositoryLeft.GetAll();
        //    response.RightList = repositoryRight.GetAll();
        //    return Ok(response);
        //}
    }
}
