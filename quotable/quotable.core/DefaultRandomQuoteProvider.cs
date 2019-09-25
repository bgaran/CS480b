using System;
using System.Collections.Generic;

namespace quotable.core

{
    /// <summary>
    /// this object will provide a random list of x quotes with x being an input value
    /// </summary>
    public class DefaultRandomQuoteProvider: RandomQuoteProvider
    {
        IEnumerable<string> quoteList; 
        /// <summary>
        /// constructer takes in a list of quotes of type IEnumerable
        /// </summary>
        /// <param name="inputQuotes"></param>
        public DefaultRandomQuoteProvider(IEnumerable<string> inputQuotes)
        {
            quoteList = inputQuotes;

        }
        /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        public IEnumerable<string> getQuotes(long numQuotes)
        {
            List<string> typeList = new List<string>();
            int i = 0;
            foreach (var x in quoteList)
            {
                typeList[i] = x;
                i++;
            }
            string[] returnList = new string[numQuotes];
            for (int y = 0; y < numQuotes; y++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[y] = typeList[randomQuote];
            }
            IEnumerable<string> returnQuotes = returnList;
            return returnQuotes;
        }

    }
}

