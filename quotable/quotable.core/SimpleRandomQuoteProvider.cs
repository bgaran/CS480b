using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using quotable.core.Models;

namespace quotable.core

{
    /// this class contains a hardcoded list of quotes from which the getQuotes method can pull from.
    public class SimpleRandomQuoteProvider : RandomQuoteProvider

    {
        static async Task Main(string[] args)
        {
            var container = new ServiceCollection();
            container.AddDbContext<QuotableContext>(options => options.UseSqlite("Data Source=quotable.db"), ServiceLifetime.Transient);
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
        /// <summary>
        /// array that stores the available quotes
        /// </summary>
        public quotable.core.Models.Quote[] quoteList = new quotable.core.Models.Quote[]
         {new quotable.core.Models.Quote("You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way",0,"Dr.Seuss"),
              new quotable.core.Models.Quote("Unless someone like you cares a whole awful lot. Nothing is going to get better. It’s not",1,"Dr.Seuss"),
              new quotable.core.Models.Quote("It is better to know how to learn than to know",2,"Dr.Seuss")};
        private readonly QuotableContext _context;
        /// <summary>
        /// This method takes an input of the number of quotes to be provided and returns an IEnumerable List of quotes.
        /// </summary>
        /// <param name="numQuotes"></param>
        /// <returns></returns>
        ///
        public IEnumerable<quotable.core.Models.Quote> getQuotes(long numQuotes)
        {
            quotable.core.Models.Quote[] returnList = new quotable.core.Models.Quote[numQuotes];
            for (int i = 0; i < numQuotes; i++)
            {
                Random random = new Random();
                int randomQuote = random.Next(0, 3);
                returnList[i] = quoteList[randomQuote];
            }
            IEnumerable<quotable.core.Models.Quote> returnQuotes = returnList;
            return returnQuotes;
        }
        /// <summary>
        /// get a single random quote
        /// </summary>
        /// <returns></returns>
        public quotable.core.Models.Quote getRandomQuote()
        {
            Random random = new Random();
            int randomQuote = random.Next(0, quoteList.Length);
            return quoteList[randomQuote];
        }
        /// <summary>
        /// get a quote with a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public quotable.core.Models.Quote getQuotesByID(int id)
        {
            if (id < quoteList.Length)
            {
                return quoteList[id];
            }
            return null;
        }
        /// <summary>
        /// returns all quotes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<quotable.core.Models.Quote> getAllQuotes()
        {
            var numQuotes = quoteList.Length;
            quotable.core.Models.Quote[] returnList = new quotable.core.Models.Quote[numQuotes];
            for (int i = 0; i < numQuotes; i++)
            {
                returnList[i] = quoteList[i];
            }
            IEnumerable<quotable.core.Models.Quote> returnQuotes = returnList;
            return returnQuotes;
        }

    }
}
    
