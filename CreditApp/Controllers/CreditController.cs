using CreditApp.Models;
using CreditApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditController : ControllerBase
    {
        private CreditService _creditService;
        public CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public IActionResult GetApproval(Credit credit)
        {
            try
            {
                var answer = _creditService.GetApproval(credit);
                return Ok(answer);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
