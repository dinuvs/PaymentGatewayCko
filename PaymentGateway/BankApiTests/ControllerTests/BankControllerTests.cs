using BankApi.Controllers;
using BankApi.Models;
using BankApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BankApiTests.ControllerTests
{
    [TestClass]
    public class BankControllerTests
    {
        [TestMethod]
        public void ValidateAndProcess_ValidCardDetails_ReturnsSuccessful()
        {
            //Arrange
            IndividualPayment individualPayment = new()
            {
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            string request = JsonConvert.SerializeObject(individualPayment);

            IValidationService validationService = new ValidationService();
            IJsonObjectConverter jsonObjectConverter = new JsonObjectConverter();
            BankController bankController = new( validationService, jsonObjectConverter);

            //Act
            var response = (OkObjectResult)bankController.ValidateAndProcess(request);

            //Assert
            Assert.AreEqual(((PaymentResponse)response.Value).SuccessStatus, "Sucessful");

        }

        [TestMethod]
        public void ValidateAndProcess_InValidCardNumber_ReturnsUnSuccessful()
        {
            //Arrange
            IndividualPayment individualPayment = new()
            {
                cardnumber = "42322345432657AD",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            string request = JsonConvert.SerializeObject(individualPayment);

            IValidationService validationService = new ValidationService();
            IJsonObjectConverter jsonObjectConverter = new JsonObjectConverter();
            BankController bankController = new(validationService, jsonObjectConverter);

            //Act
            var response = (OkObjectResult)bankController.ValidateAndProcess(request);

            //Assert
            Assert.AreEqual(((PaymentResponse)response.Value).SuccessStatus, "UnSucessful");
        }

       

        [TestMethod]
        public void ValidateAndProcess_InValidCardMonth_ReturnsUnSuccessful()
        {
            //Arrange
            IndividualPayment individualPayment = new()
            {
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "13/24",
                name = "test",
                country = "UK",
            };

            string request = JsonConvert.SerializeObject(individualPayment);

            IValidationService validationService = new ValidationService();
            IJsonObjectConverter jsonObjectConverter = new JsonObjectConverter();
            BankController bankController = new(validationService, jsonObjectConverter);

            //Act
            var response = (OkObjectResult)bankController.ValidateAndProcess(request);

            //Assert
            Assert.AreEqual(((PaymentResponse)response.Value).SuccessStatus, "UnSucessful");
        }


        [TestMethod]
        public void ValidateAndProcess_InValidCardCvv_ReturnsUnSuccessful()
        {
            //Arrange
            IndividualPayment individualPayment = new()
            {
                cardnumber = "423223454326578",
                cvv = "3224",
                expiry = "13/24",
                name = "test",
                country = "UK",
            };

            string request = JsonConvert.SerializeObject(individualPayment);

            IValidationService validationService = new ValidationService();
            IJsonObjectConverter jsonObjectConverter = new JsonObjectConverter();
            BankController bankController = new(validationService, jsonObjectConverter);

            //Act
            var response = (OkObjectResult)bankController.ValidateAndProcess(request);

            //Assert
            Assert.AreEqual(((PaymentResponse)response.Value).SuccessStatus, "UnSucessful");
        }
    }
}
