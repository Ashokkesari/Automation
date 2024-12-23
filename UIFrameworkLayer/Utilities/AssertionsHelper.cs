using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkLayer.Utilities
{
    public class AssertionsHelper
    {
        public static void AssertCheck(bool condition, string message)
        {
            if (condition)
            {
                Assert.Pass(message);

            }
            else
            {
                Assert.Fail(message);
            }

        }

        public static void AssertEqualCheck(string actual, string expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        public static void AssertEqualCheck(int expected, int actual)
        {
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
