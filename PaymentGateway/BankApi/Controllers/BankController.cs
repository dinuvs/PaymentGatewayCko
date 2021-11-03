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
        

        [HttpPost]
        [Route("ValidateAndProcess")]
        public async Task<IActionResult> ValidateAndProcess(string request)
        {
           
            return NotFound();
        }
    }
}
