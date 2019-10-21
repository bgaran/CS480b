using quotable.core;
using quotable.api.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
namespace qoutable.api.tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestMethod1()
        {
            var provider = new SimpleRandomQuoteProvider();
            var controller = new QuoteController(provider);

            var actual = controller.Get(1);

            Assert.That(actual.ID, Is.EqualTo(1));

        }
    }
}
