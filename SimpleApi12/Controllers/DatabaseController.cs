using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi12.Interfaces;

namespace SimpleApi12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        //this adds the DB property to the controller class
        private readonly IDatabaseRepository _databaseRepository;
        public DatabaseController(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        //
        [HttpGet]
        public async Task<ActionResult> GetDatabaseVersion()
        {
            var version = await _databaseRepository.GetDatabaseVersion();
            return Ok(version);
        }
    }
}
