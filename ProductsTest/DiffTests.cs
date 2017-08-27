using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Net;
using ProductApp.Controllers;
using ProductApp.Models;
using System.Collections.Generic;
using ProductApp.Repository;
using ProductApp.Domain;

namespace ProductsTest
{
    [TestClass]
    public class DiffTests
    {
        private DiffController controller;
        private DiffService diffService;
        private LeftRepository leftRepository;
        private RightRepository rightRepository;

        [TestInitialize]
        public void Setup()
        {
            controller = new DiffController();
            leftRepository = new LeftRepository();
            rightRepository = new RightRepository();
            diffService = new DiffService();
        }

        [TestMethod]
        public void ShouldReturnNoValues()
        {
            int id = 1;
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Id " + id + " does not exists in Left and Right side");
        }

        [TestMethod]
        public void OnlyLeftSideExists()
        {
            int id = 1;
            leftRepository.Add(CreateBase64Data(id, "Test"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Id " + id + " does not exists in Right side");
        }

        [TestMethod]
        public void OnlyRightSideExists()
        {
            int id = 1;
            rightRepository.Add(CreateBase64Data(id, "Test"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Id " + id + " does not exists in Left side");
        }

        [TestMethod]
        public void BothSideExistsAndAreEqual()
        {
            int id = 1;
            leftRepository.Add(CreateBase64Data(id, "Test"));
            rightRepository.Add(CreateBase64Data(id, "Test"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Equals");
        }

        [TestMethod]
        public void BothSideExistsAndAreDifferentSizes()
        {
            int id = 1;
            leftRepository.Add(CreateBase64Data(id, "Test"));
            rightRepository.Add(CreateBase64Data(id, "Test1"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Not of Equal Size");
        }

        [TestMethod]
        public void BothSideExistsWithSameSizeDifferentData()
        {
            int id = 1;
            leftRepository.Add(CreateBase64Data(id, "1234"));
            rightRepository.Add(CreateBase64Data(id, "2234"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Number of differences found: 1.");
        }

        [TestMethod]
        public void BothSideExistsWithSameSizeDiffDataValidateErrorPosition()
        {
            int id = 1;
            leftRepository.Add(CreateBase64Data(id, "1234"));
            rightRepository.Add(CreateBase64Data(id, "2234"));
            JsonResponse response = diffService.Compare(id);
            Assert.AreEqual(response.Result, "Number of differences found: 1.");
            Assert.AreEqual(response.Differences[0], "Difference in position 0 to 0");
        }

        //Non-Test Methods

        private Base64Data CreateBase64Data(int id, string value)
        {
            Base64Data newBase64Data = new Base64Data();
            newBase64Data.Id = id;
            //newBase64Data.Base64Value = System.Text.Encoding.UTF8.GetBytes(value);
            newBase64Data.Base64Value = value;
            return newBase64Data;
        }


    }
}
