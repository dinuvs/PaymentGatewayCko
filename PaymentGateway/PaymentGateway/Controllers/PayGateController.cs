using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Controllers
{
    [ApiController]
    [Route("api/Transaction")]
    public class PayGateController : ControllerBase
    {
        private readonly IPayGateService _payGateService;

        public PayGateController(IPayGateService payGateService)
        {
            _payGateService = payGateService;
        }

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment(string request)
        {

            
            await _payGateService.ProcessPayment(request);
            return NotFound();
        }

    }
}
