using quotable.core;
using quotable.core.Models;
using NUnit.Framework;
using quotable.api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

            Assert.IsTrue(actual.Value.ID == 1);


            var actual2 = controller.Get(2);
            Assert.IsTrue(actual2.Value.Text == "It is better to know how to learn than to know");

            var actual3 = controller.Get();
            Assert.IsTrue(actual3.Value.Count() == provider.quoteList.Length);


            var controller2 = new RandomController(provider);
            var actual4 = controller2.Get();

            Assert.IsTrue(actual4.Value.ID <= provider.quoteList.Length);


        }
    }
}
