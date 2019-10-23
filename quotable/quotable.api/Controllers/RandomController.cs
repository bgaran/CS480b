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
    /// <summary>
    /// provides a random quote
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {

        private RandomQuoteProvider Provider { get; }
        /// <summary>
        /// constructor that takes a RandomQuoteProvider
        /// </summary>
        /// <param name="provider"></param>
        public RandomController(RandomQuoteProvider provider)
        {
            Provider = provider;
        }
        /// <summary>
        /// returns a radnom quote
        /// </summary>
        /// <returns></returns>
        // GET api/random
        [HttpGet]
        public ActionResult<Quote> Get()
        {
            Quote quotes;
            quotes = Provider.getRandomQuote();

            return quotes;
        }

        // GET api/random/1
        //[HttpGet("{id}")]
       // public ActionResult<IEnumerable<Quote>> Get(int id)
       // {
        //    return 1;
       // }

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
