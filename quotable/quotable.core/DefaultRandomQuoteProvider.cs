using System;
using System.Collections.Generic;

namespace quotable.core

{
    public class DefaultRandomQuoteProvider : RandomQuoteProvider
    {
        IEnumerable<string> quoteList; 
        public DefaultRandomQuoteProvider(IEnumerable<string> inputQuotes)
        {
            this.quoteList = quoteList;

        }

        public IEnumerable<string> getQuotes(int numQuotes)
        {
            string[] returnList = new string[numQuotes];
            int i = 0;
            foreach (var x in quoteList)
            {
                returnList[i] = x;
                i++;
            }
            
            for (int i = 0; i < numQuotes; i++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[i] = quoteList[randomQuote];
            }
            IEnumerable<string> returnQuotes = returnList;
            return returnQuotes;
        }

    }
}

