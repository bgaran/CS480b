using quotable.core;
using quotable.core.Models;
using NUnit.Framework;
using quotable.api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;


namespace qoutable.api.tests
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Get_Success()
        {
            var provider = new SimpleRandomQuoteProvider();
            var controller = new QuoteController(provider);

            var actual = controller.Get(1);
            Assert.That(actual, Is.EqualTo(1));
        }
    }
}
