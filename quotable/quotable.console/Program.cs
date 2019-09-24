using quotable.core;
using System;
using System.Collections.Generic;

namespace quotable.console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SimpleRandomQuoteProvider provider=new SimpleRandomQuoteProvider();
            IEnumerable<string> quotes;
           // RandomQuoteProvider provider=new SimpleRandomQuoteProvider();
			Console.Write("Enter the number of quotes: ");
            var numQuotes = Console.ReadLine();
            quotes= provider.getQuotes(long.Parse(numQuotes));
            
            foreach(var x in quotes)
                {
                Console.WriteLine(x);
                }
            
           
		}

       
			
    }
}
