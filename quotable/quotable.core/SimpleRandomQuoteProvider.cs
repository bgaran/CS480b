using System;
using System.Collections.Generic;
using System.Linq;
using quotable.core.Models;

namespace quotable.core

{
    /// this class contains a hardcoded list of quotes from which the getQuotes method can pull from.
    public class SimpleRandomQuoteProvider: RandomQuoteProvider
    {
       Quote[] quoteList = new Quote[] {new Quote(), new Quote(), new Quote()};
        //"You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way",
           // "Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not",
          //  "It is better to know how to learn than to know"
         /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        /// 
        public void initializeQuotes()
        {
            quoteList[0].ID = 0;
            quoteList[0].Author = "Dr. Seuss";
            quoteList[0].Text = "You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way";

            quoteList[1].ID = 1;
            quoteList[1].Author = "Dr. Seuss";
            quoteList[1].Text = "Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not";

            quoteList[2].ID = 2;
            quoteList[2].Author = "Dr. Seuss";
            quoteList[2].Text = "It is better to know how to learn than to know";
        }


        public IEnumerable<Quote> getQuotes(long numQuotes)
	    {
            initializeQuotes();
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

        public IEnumerable<Quote> getQuotesByID(int id)
        {
            initializeQuotes();
            Quote[] returnList = new Quote[1];
            if (id < quoteList.Length)
            {
                returnList[0] = quoteList[id];
            }
            IEnumerable<Quote> returnQuote = returnList;
            return returnQuote.ToList();
        }
    }
}
    
