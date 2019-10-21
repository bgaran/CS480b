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
            var generator = new NaiveHailstoneNumberGenerator();
            var controller = new HailstoneController(generator);

            var actual = controller.Get(5);

        }
    }
}
