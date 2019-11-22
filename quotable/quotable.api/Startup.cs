using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using quotable.core;
using Microsoft.AspNetCore.HttpsPolicy;

namespace quotable.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<QuotableContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<RandomQuoteProvider, SimpleRandomQuoteProvider>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<QuotableContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                PopulateDatabase(context);
            }
        }
        private static void PopulateDatabase(QuotableContext context)
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
                FirstName = "J.K.",
                LastName = "Rowling"
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

            context.SaveChangesAsync();
        }
    }
}
