using System.Collections.Generic;
using System;
using quotable.core.Models;

namespace quotable.core
{
    /// this interface is implemented by all types or randomQuoteProviders and ensures that the 
    /// getQuotes method with the correct parameters and return type is present
    public interface RandomQuoteProvider
    {
        IEnumerable<quotable.core.Models.Quote> getQuotes(long numQuotes);
        quotable.core.Models.Quote getQuotesByID(int id);
        IEnumerable<quotable.core.Models.Quote> getAllQuotes();
        quotable.core.Models.Quote getRandomQuote();
    }
}
