using System.Collections.Generic;
using System;

namespace quotable.core
{
    public interface RandomQuoteProvider
    {
        IEnumerable<string> getQuotes(long numQuotes);
    }
}
