using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P0Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class P0Controller : ControllerBase
    {
        // GET: api/P0
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/P0/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/P0
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/P0/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/P0/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
