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
      public  Quote[] quoteList = new Quote[] 
       {new Quote("You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way",0,"Dr.Seuss"),
           new Quote("Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not",1,"Dr.Seuss"),
           new Quote("It is better to know how to learn than to know",2,"Dr.Seuss")};

         /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        ///
        public IEnumerable<Quote> getQuotes(long numQuotes)
	    {
           Quote[] returnList=new Quote[numQuotes];
            for (int i=0;i<numQuotes;i++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[i]=quoteList[randomQuote];
            }
            IEnumerable<Quote> returnQuotes=returnList;
            return returnQuotes;
        }
        /// <summary>
        /// get a single random quote
        /// </summary>
        /// <returns></returns>
        public Quote getRandomQuote()
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
        public Quote getQuotesByID(int id)
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
        public IEnumerable<Quote> getAllQuotes()
        {
            var numQuotes = quoteList.Length;
            Quote[] returnList = new Quote[numQuotes];
            for (int i = 0; i < numQuotes; i++)
            {
                returnList[i] = quoteList[i];
            }
            IEnumerable<Quote> returnQuotes = returnList;
            return returnQuotes;
        }
    }
}
    
