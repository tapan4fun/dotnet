using Complex.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Complex.Tests
{
    [TestClass]
    public class AppHelperTest
    {
        [TestMethod]
        public void Test_can_add_numbers()
        {
            AppHelper appHelper = new AppHelper();

            int sum = appHelper.Add(2, 3);

            sum.Should().Be(5);
        }

        [TestMethod]
        public void Test_can_add_small_numbers()
        {
            AppHelper appHelper = new AppHelper();

            int sum = appHelper.Add(5, 3);

            sum.Should().NotBe(18);
        }
    }
}
