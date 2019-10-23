using NUnit.Framework;
using quotable.core;
using quotable.core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            // arrange
            var provider = new SimpleRandomQuoteProvider();

            var actual = provider.getQuotesByID(1);
            // assert
            Assert.AreEqual(actual.ID, 1);
            Assert.AreEqual(actual.Author, "Dr.Seuss");
            var actual2 = provider.getQuotesByID(0);
            // assert
            Assert.AreEqual(actual2.ID, 0);
            Assert.AreEqual(actual2.Text, "You’re off to great to places. Today is your day. Your mountain is waiting. So get on your way");


            var actual3 = provider.getQuotesByID(2);
            // assert
            Assert.AreEqual(actual3.ID, 2);

            var actual4 = provider.getQuotes(3).Count();
            Assert.IsTrue(actual4 == 3);

            var actual5 = provider.getQuotes(7).Count();
            Assert.IsTrue(actual5 == 7);

            var actual6 = provider.getAllQuotes().Count();

            Assert.IsTrue(actual6==provider.quoteList.Length);

            var actual7 = provider.getRandomQuote();
            var countQuotes = provider.quoteList.Length;
            Assert.IsTrue(actual7.ID <= countQuotes);
        }
    }
}