using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ScenarioAPI.DTO;
using ScenarioAPI.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScenarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly ILogger<ScenarioController> _logger;
        private readonly IConfiguration _config;
        private readonly IScenarioService _scenarioService;
        public ScenarioController(ILogger<ScenarioController> logger, IConfiguration config, IScenarioService scenarioService)
        {
            _logger = logger;
            _config = config;
            _scenarioService = scenarioService;
        }        

        // GET: api/<ScenarioController>
        [HttpGet]
        [Route("GetScenarios")]
        public IEnumerable<Scenario> GetScenarios()
        {
            string docsDirectory = _config.GetValue<string>("DocSettings:DocsDirectory");
            string docName = _config.GetValue<string>("DocSettings:DocName");
            return _scenarioService.GetScenarios(@"\" + docsDirectory + @"\" + docName);            
        }

        //// GET api/<ScenarioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ScenarioController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ScenarioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ScenarioController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
