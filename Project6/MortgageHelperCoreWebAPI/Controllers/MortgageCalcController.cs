using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MortgageCalculator;

namespace MortgageHelperCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageCalcController : ControllerBase
    {
        private readonly ILogger<MortgageCalcController> _logger;

        public MortgageCalcController(ILogger<MortgageCalcController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public double Get(double principal, double years, double rate)
        {
            return MortgageCalculator.MortgageCalcHelper.ComputeMonthlyPayment(principal, years, rate);
        }



    }
}
