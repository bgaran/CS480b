using System;
using System.Collections.Generic;

namespace quotable.core

{
    /// this class contains a hardcoded list of quotes from which the getQuotes method can pull from.
    public class SimpleRandomQuoteProvider: RandomQuoteProvider
    {
       string[] quoteList = new string[] { "You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way",
            "Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not",
            "It is better to know how to learn than to know" };
         /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        public IEnumerable<string> getQuotes(long numQuotes)
	    {
           string[] returnList=new string[numQuotes];
            for (int i=0;i<numQuotes;i++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[i]=quoteList[randomQuote];
            }
            IEnumerable<string> returnQuotes=returnList;
            return returnQuotes;
        }

	}
}
    
