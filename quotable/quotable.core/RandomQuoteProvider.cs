using System.Collections.Generic;
using System;

namespace quotable.core
{
    /// this interface is implemented by all types or randomQuoteProviders and ensures that the 
    /// getQuotes method with the correct parameters and return type is present
    public interface RandomQuoteProvider
    {
        IEnumerable<string> getQuotes(long numQuotes);
    }
}
