using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PaymentGateway.Controllers;
using PaymentGateway.DataAccess.Model;
using PaymentGateway.DataAccess.Repository;
using PaymentGateway.Models;
using PaymentGateway.Services;
using PaymentGateway.Utils;
using System.Threading.Tasks;

namespace PaymentGatewayTests.ControllerTests
{
    [TestClass]
    public class PayGateControllerTests
    {
        [TestMethod]
        public void Processpayment_ValidInput_ReturnsSuccess()
        {
            //Arrange
            Payment payment = new()
            {
                description = "test",
                currency="EUR",
                amount=100,
                email="test@test.com",
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            PaymentBankResponse paymentBankResponse = new()
            {
                SuccessStatus = "Successful",
                StatusReason = "Valid Payment"
            };

            TransactionDetail transactionDetail = new()
            {
                Amount = 100,
                Name = "test",
                Status = "Successful",
                StatusReason = "Valid Request",
                Description = "test",
                Currency = "EUR",
                Email = "test@test.com",
                CardNumber = "423223454326578",
                Cvv = "322",
                Expiry = "12/24",
                Country = "UK"
            };

            var configMock = new Mock<IConfiguration>();
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.Setup(c => c.Value).Returns("http://Ckounittesting.com");
            configMock.Setup(c => c.GetSection("BankingApi")).Returns(configSectionMock.Object);
            configMock.Setup(c => c.GetSection("BankingApiGet")).Returns(configSectionMock.Object);
            ConfigurationService configurationService = new ConfigurationService(configMock.Object);


            Mock<IRestClient> restClientMock = new();
            restClientMock.Setup(r => r.PostAsync(It.IsAny<string>(), It.IsAny<PaymentRequestBank>())).Returns(Task.FromResult(JsonConvert.SerializeObject(paymentBankResponse)));
            Mock<ITransactionDetailRepository> transactionDetailReposMock = new Mock<ITransactionDetailRepository>();
            transactionDetailReposMock.Setup(t => t.AddAsync(It.IsAny<TransactionDetail>())).Returns(Task.FromResult(transactionDetail));
            IPayGateService payGateService = new PayGateService(restClientMock.Object, configurationService, transactionDetailReposMock.Object);
            PayGateController payGateController = new PayGateController(payGateService);

            //Act
            var result = (OkObjectResult)payGateController.ProcessPayment(JsonConvert.SerializeObject(payment)).Result;

            //Assert
            Assert.AreEqual("Successful", result.Value.ToString());
        }

        [TestMethod]
        public void Processpayment_InvalidInput_ReturnNotSuccess()
        {
            //Arrange
            Payment payment = new()
            {
                description = "test",
                currency = "EUR",
                amount = 100,
                email = "test@test.com",
                cardnumber = "42322345432657D",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            PaymentBankResponse paymentBankResponse = new()
            {
                SuccessStatus = "UnSuccessful",
                StatusReason = "InValid CardNumber"
            };

            TransactionDetail transactionDetail = new()
            {
                Amount = 100,
                Name = "test",
                Status = "UnSuccessful",
                StatusReason = "Valid Request",
                Description = "test",
                Currency = "EUR",
                Email = "test@test.com",
                CardNumber = "42322345432657D",
                Cvv = "322",
                Expiry = "12/24",
                Country = "UK"
            };

            var configMock = new Mock<IConfiguration>();
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.Setup(c => c.Value).Returns("http://Ckounittesting.com");
            configMock.Setup(c => c.GetSection("BankingApi")).Returns(configSectionMock.Object);
            configMock.Setup(c => c.GetSection("BankingApiGet")).Returns(configSectionMock.Object);
            ConfigurationService configurationService = new ConfigurationService(configMock.Object);


            Mock<IRestClient> restClientMock = new();
            restClientMock.Setup(r => r.PostAsync(It.IsAny<string>(), It.IsAny<PaymentRequestBank>())).Returns(Task.FromResult(JsonConvert.SerializeObject(paymentBankResponse)));
            Mock<ITransactionDetailRepository> transactionDetailReposMock = new Mock<ITransactionDetailRepository>();
            transactionDetailReposMock.Setup(t => t.AddAsync(It.IsAny<TransactionDetail>())).Returns(Task.FromResult(transactionDetail));
            IPayGateService payGateService = new PayGateService(restClientMock.Object, configurationService, transactionDetailReposMock.Object);
            PayGateController payGateController = new PayGateController(payGateService);

            //Act
            var result = (OkObjectResult)payGateController.ProcessPayment(JsonConvert.SerializeObject(payment)).Result;

            //Assert
            Assert.AreEqual("UnSuccessful", result.Value.ToString());
        }

        [TestMethod]
        public void Retrievepayment_validId_ReturnsNonZeroPaymentDetails()
        {
            //Arrange
            Payment payment = new()
            {
                description = "test",
                currency = "EUR",
                amount = 100,
                email = "test@test.com",
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            PaymentBankResponse paymentBankResponse = new()
            {
                SuccessStatus = "Successful",
                StatusReason = "Valid Payment"
            };

            TransactionDetail transactionDetail = new()
            {
                TransactionId=1,
                Amount = 100,
                Name = "test",
                Status = "Successful",
                StatusReason = "Valid Request",
                Description = "test",
                Currency = "EUR",
                Email = "test@test.com",
                CardNumber = "423223454326578",
                Cvv = "322",
                Expiry = "12/24",
                Country = "UK"
            };

            var configMock = new Mock<IConfiguration>();
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.Setup(c => c.Value).Returns("http://Ckounittesting.com");
            configMock.Setup(c => c.GetSection("BankingApi")).Returns(configSectionMock.Object);
            configMock.Setup(c => c.GetSection("BankingApiGet")).Returns(configSectionMock.Object);
            ConfigurationService configurationService = new ConfigurationService(configMock.Object);


            Mock<IRestClient> restClientMock = new();
            restClientMock.Setup(r => r.PostAsync(It.IsAny<string>(), It.IsAny<PaymentRequestBank>())).Returns(Task.FromResult(JsonConvert.SerializeObject(paymentBankResponse)));
            Mock<ITransactionDetailRepository> transactionDetailReposMock = new Mock<ITransactionDetailRepository>();
            //transactionDetailReposMock.Setup(t => t.AddAsync(It.IsAny<TransactionDetail>())).Returns(Task.FromResult(transactionDetail));
            transactionDetailReposMock.Setup(t => t.GetTransactionAsync(It.IsAny<int>())).Returns(Task.FromResult(transactionDetail));
            IPayGateService payGateService = new PayGateService(restClientMock.Object, configurationService, transactionDetailReposMock.Object);
            PayGateController payGateController = new PayGateController(payGateService);

            //Act
            var result = (OkObjectResult)payGateController.GetPaymentDetailsWithID("1").Result;

            //Assert
            Assert.IsNotNull((TransactionDetail)result.Value);
            
        }

        [TestMethod]
        public void Retrievepayment_validId_ReturnsPaymentDetails()
        {
            //Arrange
            Payment payment = new()
            {
                description = "test",
                currency = "EUR",
                amount = 100,
                email = "test@test.com",
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            PaymentBankResponse paymentBankResponse = new()
            {
                SuccessStatus = "Successful",
                StatusReason = "Valid Payment"
            };

            TransactionDetail transactionDetail = new()
            {
                TransactionId = 1,
                Amount = 100,
                Name = "test",
                Status = "Successful",
                StatusReason = "Valid Request",
                Description = "test",
                Currency = "EUR",
                Email = "test@test.com",
                CardNumber = "423223454326578",
                Cvv = "322",
                Expiry = "12/24",
                Country = "UK"
            };

            var configMock = new Mock<IConfiguration>();
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.Setup(c => c.Value).Returns("http://Ckounittesting.com");
            configMock.Setup(c => c.GetSection("BankingApi")).Returns(configSectionMock.Object);
            configMock.Setup(c => c.GetSection("BankingApiGet")).Returns(configSectionMock.Object);
            ConfigurationService configurationService = new ConfigurationService(configMock.Object);


            Mock<IRestClient> restClientMock = new();
            restClientMock.Setup(r => r.PostAsync(It.IsAny<string>(), It.IsAny<PaymentRequestBank>())).Returns(Task.FromResult(JsonConvert.SerializeObject(paymentBankResponse)));
            Mock<ITransactionDetailRepository> transactionDetailReposMock = new Mock<ITransactionDetailRepository>();
            //transactionDetailReposMock.Setup(t => t.AddAsync(It.IsAny<TransactionDetail>())).Returns(Task.FromResult(transactionDetail));
            transactionDetailReposMock.Setup(t => t.GetTransactionAsync(It.IsAny<int>())).Returns(Task.FromResult(transactionDetail));
            IPayGateService payGateService = new PayGateService(restClientMock.Object, configurationService, transactionDetailReposMock.Object);
            PayGateController payGateController = new PayGateController(payGateService);

            //Act
            var result = (OkObjectResult)payGateController.GetPaymentDetailsWithID("1").Result;

            //Assert
           
            Assert.AreEqual(1, ((TransactionDetail)result.Value).TransactionId);
            Assert.AreEqual(100, ((TransactionDetail)result.Value).Amount);
            Assert.AreEqual("test", ((TransactionDetail)result.Value).Name);
        }

        [TestMethod]
        public void Retrievepayment_InvalidId_ReturnsNullOrZeroPaymentDetails()
        {  //Arrange
            Payment payment = new()
            {
                description = "test",
                currency = "EUR",
                amount = 100,
                email = "test@test.com",
                cardnumber = "423223454326578",
                cvv = "322",
                expiry = "12/24",
                name = "test",
                country = "UK",
            };

            PaymentBankResponse paymentBankResponse = new()
            {
                SuccessStatus = "Successful",
                StatusReason = "Valid Payment"
            };

            TransactionDetail transactionDetail = new()
            {
               
                Amount = 100,
                Name = "test",
                Status = "Successful",
                StatusReason = "Valid Request",
                Description = "test",
                Currency = "EUR",
                Email = "test@test.com",
                CardNumber = "423223454326578",
                Cvv = "322",
                Expiry = "12/24",
                Country = "UK"
            };

            var configMock = new Mock<IConfiguration>();
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.Setup(c => c.Value).Returns("http://Ckounittesting.com");
            configMock.Setup(c => c.GetSection("BankingApi")).Returns(configSectionMock.Object);
            configMock.Setup(c => c.GetSection("BankingApiGet")).Returns(configSectionMock.Object);
            ConfigurationService configurationService = new ConfigurationService(configMock.Object);


            Mock<IRestClient> restClientMock = new();
            restClientMock.Setup(r => r.PostAsync(It.IsAny<string>(), It.IsAny<PaymentRequestBank>())).Returns(Task.FromResult(JsonConvert.SerializeObject(paymentBankResponse)));
            Mock<ITransactionDetailRepository> transactionDetailReposMock = new Mock<ITransactionDetailRepository>();
            //transactionDetailReposMock.Setup(t => t.AddAsync(It.IsAny<TransactionDetail>())).Returns(Task.FromResult(transactionDetail));
            transactionDetailReposMock.Setup(t => t.GetTransactionAsync(It.IsAny<int>())).Returns(Task.FromResult<TransactionDetail>(null));
            IPayGateService payGateService = new PayGateService(restClientMock.Object, configurationService, transactionDetailReposMock.Object);
            PayGateController payGateController = new PayGateController(payGateService);

            //Act
            var result = (NotFoundResult)payGateController.GetPaymentDetailsWithID("1").Result;

            //Assert

            Assert.AreEqual(404, result.StatusCode);
        }

        
    }
}
