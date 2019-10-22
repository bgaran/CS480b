using quotable.core;
using quotable.api;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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

            Assert.That(actual.ID, Is.EqualTo(1));
        }
    }
}
