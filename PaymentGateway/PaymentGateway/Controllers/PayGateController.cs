using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Services;
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

        [HttpGet]
        [Route("GetPaymentDetails")]
        public async Task<IActionResult> GetPaymentDetailsWithID(string id)
        {
            if(int.TryParse(id, out _))
            {
                var transactionWithStatus = await _payGateService.GetTransactionWithIdAsync(int.Parse(id));
                if (transactionWithStatus != null)
                {
                    return Ok(transactionWithStatus);
                }
            }
            
            return NotFound();
        }

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment(string request)
        {
            var transactionWithStatus=await _payGateService.ProcessPaymentAsync(request);
            if(transactionWithStatus != null)
            {
                return Ok(transactionWithStatus.Status);
            }
            return NotFound();
        }

    }
}
