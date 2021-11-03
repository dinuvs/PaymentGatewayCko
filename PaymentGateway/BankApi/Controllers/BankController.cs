using BankApi.Models;
using BankApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api/Payment")]
    public class BankController : ControllerBase
    {
        private readonly IValidationService _validationService;
        private readonly IJsonObjectConverter _jsonObjectConverter;

        public BankController(IValidationService validationService, IJsonObjectConverter jsonObjectConverter)
        {
            _validationService = validationService;
            _jsonObjectConverter = jsonObjectConverter;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return Ok("hello");
        }


        [HttpPost]
        [Route("ValidateAndProcess")]
        public IActionResult ValidateAndProcess(string request)
        {
            try
            {
                var result = _validationService.ValidateCardDetails(_jsonObjectConverter.ConvertPaymentJsonDataToObj(request));

                //TODO: Add third party call and check if payment is successful( which can be asynchronous)

                PaymentResponse paymentResponse = new();
                if (result.Item1)
                {
                    paymentResponse.SuccessStatus = "Sucessful";
                    paymentResponse.StatusReason = result.Item2;
                    return Ok(paymentResponse);
                }
                else
                {
                    paymentResponse.SuccessStatus = "UnSucessful";
                    paymentResponse.StatusReason = result.Item2;
                    return Ok(paymentResponse);
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
