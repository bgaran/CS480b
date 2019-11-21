using quotable.core;
using quotable.core.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Quote = quotable.core.Quote;

namespace quotable.console
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            var container = new ServiceCollection();
            container.AddDbContext<QuotableContext>(options => options.UseSqlite("Data Source=quotable.db"), ServiceLifetime.Transient);


            /*SimpleRandomQuoteProvider provider=new SimpleRandomQuoteProvider();
            IEnumerable<quotable.core.Models.Quote> quotes;
           // RandomQuoteProvider provider=new SimpleRandomQuoteProvider();
			Console.Write("Enter the number of quotes: ");
            var numQuotes = Console.ReadLine();
            quotes= provider.getQuotes(long.Parse(numQuotes));
            
            foreach(var x in quotes)
                {
                Console.WriteLine(x);
                }*/
            var provider = container.BuildServiceProvider();

            using (var context = provider.GetService<QuotableContext>())
            {
                // [miko]
                // good for testing
                // bad for production...
                await context.Database.EnsureDeletedAsync();

                // [miko]
                // if the database doesn't exist it will be created
                // this should ideally only be run once in an application lifetime
                // this only ensure existence, this does not perform migrations.
                var dbDidntExist = await context.Database.EnsureCreatedAsync();

                if (dbDidntExist)
                {
                    await PopulateDatabase(context);
                }
            }

            using (var context = provider.GetService<QuotableContext>())
            {
                var quotes = context.Quotes
                                        .Include(d => d.QuoteAuthor)
                                        .ThenInclude(x => x.Author);

                foreach (var quote in quotes)
                {
                    Console.WriteLine($"qoute.id = {quote.Id}");
                    Console.WriteLine($"quote.content = {quote.QuoteContent}");

                    foreach (var author in quote.Authors)
                    {
                        Console.WriteLine($"quote.author.id = {author.Id}");
                        Console.WriteLine($"quote.author.firstname = {author.FirstName}");
                        Console.WriteLine($"quote.author.lasttname = {author.LastName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();


        }
        private static async Task PopulateDatabase(QuotableContext context)
        {
            var author1 = new Author()
            {
                FirstName = "Dr",
                LastName = "Seuss"
            };
            var author2 = new Author()
            {
                FirstName = "Mahatma",
                LastName = "Gandhi"
            };
            var author3 = new Author()
            {
                FirstName = "J.K. Rowling",
                LastName = "Tuvok"
            };

            var quote1 = new Quote();
            quote1.QuoteContent = "You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way";

            var quote2 = new Quote();
            quote2.QuoteContent = "Be the change that you wish to see in the world";

            var quote3 = new Quote();
            quote3.QuoteContent = "It does not do to dwell on dreams and forget to live";

            var da1 = new QuoteAuthor() { Quote = quote1, Author = author1 };
            var da2 = new QuoteAuthor() { Quote = quote2, Author = author2 };
            var da5 = new QuoteAuthor() { Quote = quote3, Author = author3 };

            context.AddRange(da1, da2, da5);

            await context.SaveChangesAsync();
        }





    }
}
