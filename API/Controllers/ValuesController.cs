using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly DataContext _dataContext;

        public ValuesController(ILogger<ValuesController> logger, DataContext dataContext)
        {
            _logger = logger;
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var values = await _dataContext.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _dataContext.Values.FindAsync(id);
            return Ok(value);
        }
    }
}
