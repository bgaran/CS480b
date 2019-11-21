using System;
using System.Collections.Generic;
using System.Linq;
using quotable.core.Models;

namespace quotable.core

{
    /// this class contains a hardcoded list of quotes from which the getQuotes method can pull from.
    public class SimpleRandomQuoteProvider: RandomQuoteProvider
   
    {
        /// <summary>
        /// array that stores the available quotes
        /// </summary>
         public quotable.core.Models.Quote[] quoteList = new quotable.core.Models.Quote[] 
          {new quotable.core.Models.Quote("You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way",0,"Dr.Seuss"),
              new quotable.core.Models.Quote("Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not",1,"Dr.Seuss"),
              new quotable.core.Models.Quote("It is better to know how to learn than to know",2,"Dr.Seuss")};

        /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        ///
        public IEnumerable<quotable.core.Models.Quote> getQuotes(long numQuotes)
	    {
            quotable.core.Models.Quote[] returnList=new quotable.core.Models.Quote[numQuotes];
            for (int i=0;i<numQuotes;i++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[i]=quoteList[randomQuote];
            }
            IEnumerable<quotable.core.Models.Quote> returnQuotes=returnList;
            return returnQuotes;
        }
        /// <summary>
        /// get a single random quote
        /// </summary>
        /// <returns></returns>
        public quotable.core.Models.Quote getRandomQuote()
        {
                Random random = new Random();
                int randomQuote = random.Next(0, quoteList.Length);
                return quoteList[randomQuote];
        }
        /// <summary>
        /// get a quote with a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public quotable.core.Models.Quote getQuotesByID(int id)
        {
            if (id < quoteList.Length)
            {
                return quoteList[id];
            }
            return null;
        }
        /// <summary>
        /// returns all quotes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<quotable.core.Models.Quote> getAllQuotes()
        {
            var numQuotes = quoteList.Length;
             quotable.core.Models.Quote[] returnList = new quotable.core.Models.Quote[numQuotes];
             for (int i = 0; i < numQuotes; i++)
             {
                 returnList[i] = quoteList[i];
             }
             IEnumerable<quotable.core.Models.Quote> returnQuotes = returnList;
             return returnQuotes;
        }
    }
}
    
