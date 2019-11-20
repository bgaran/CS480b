using quotable.core;
using quotable.core.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace quotable.console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var container = new ServiceCollection();
            container.AddDbContext<QuotableContext>(options => options.UseSqlite("Data Source=lorem.db"), ServiceLifetime.Transient);


            SimpleRandomQuoteProvider provider=new SimpleRandomQuoteProvider();
            IEnumerable<quotable.core.Models.Quote> quotes;
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
