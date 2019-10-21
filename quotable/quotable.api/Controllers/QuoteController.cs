using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quotable.core;
using Microsoft.AspNetCore.Mvc;
using quotable.api.Models;
using quotable.core.Models;


namespace quotable.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {

        private SimpleRandomQuoteProvider Provider { get; }

        public QuoteController(SimpleRandomQuoteProvider provider)
        {
            Provider = provider;
        }
        // GET api/quote
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Quote>> Get(int id)
        {
          //var quote=new Quote();
          IEnumerable<Quote> quote;
           quote = Provider.getQuotesByID(id);

            return quote.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
