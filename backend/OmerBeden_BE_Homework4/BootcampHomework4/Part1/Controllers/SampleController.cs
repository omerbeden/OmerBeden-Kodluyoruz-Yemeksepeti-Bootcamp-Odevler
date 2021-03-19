using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part1.Services.Abstract;

namespace Part1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly IScoppedService _scoppedService1;
        private readonly IScoppedService _scoppedService2;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        public SampleController(ISingletonService singletonService, IScoppedService scoppedService, ITransientService transientService1, ITransientService transientService2, IScoppedService scoppedService2)
        {
            _singletonService = singletonService;
            _scoppedService1 = scoppedService;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scoppedService2 = scoppedService2;
        }


        [HttpGet]
        public IActionResult Get()
        {

            string singletonLog = _singletonService.LogRequestToConsole(this.HttpContext);
            string scoppedLog1 = _scoppedService1.Calculate();
            string scoppedLog2 = _scoppedService2.Calculate();
            string transientLog1 = _transientService1.Calculate();
            string transientLog2 = _transientService2.Calculate();


            String result = $"Singleton: {singletonLog}{Environment.NewLine}" +
                            $"Scopped1: {scoppedLog1}{Environment.NewLine}" +
                            $"Scopped2: {scoppedLog2}{Environment.NewLine}" +
                            $"Transient1: {transientLog1}{Environment.NewLine}" +
                            $"Transient2: {transientLog2}";
            return Ok(result);
        }
    }
}
