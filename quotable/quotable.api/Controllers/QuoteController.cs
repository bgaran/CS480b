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
    ///get a quote by id or get all quotes
    public class QuoteController : ControllerBase
    {
       
        private RandomQuoteProvider Provider { get; }
        /// <summary>
        /// constructior for the controller
        /// takes a RandomQuoteProvider
        /// </summary>
        /// <param name="provider"></param>
        public QuoteController(RandomQuoteProvider provider)
        {
            Provider = provider;
        }
        /// <summary>
        /// returns all quotes
        /// </summary>
        /// <returns></returns>
        // GET api/quote
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> Get()
        {
            IEnumerable<Quote> quotes;
            quotes = Provider.getAllQuotes();

            return quotes.ToList();
        }
        /// <summary>
        /// returns quote at a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/1
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
