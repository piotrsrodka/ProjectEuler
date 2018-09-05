using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace TestRun
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void FactorialFewStartingValues()
        {
               Assert.AreEqual(1, Functions.Factorial(0));
               Assert.AreEqual(1, Functions.Factorial(1));
               Assert.AreEqual(2, Functions.Factorial(2));
               Assert.AreEqual(6, Functions.Factorial(3));
               Assert.AreEqual(24, Functions.Factorial(4));
               Assert.AreEqual(120, Functions.Factorial(5));
               Assert.AreEqual(720, Functions.Factorial(6));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException), "Too big a number")]
        public void FactorialLimit()
        {
            long i;
             
            for (i = 0; i < 30; i++)
            {
                var factorial = Functions.Factorial(i);
                //Trace.WriteLine(factorial);
                //Assert.IsTrue(factorial > 0);
            }

            //Assert.Fail();

            //Assert.Fail($"Failed at {i}");
        }
    }
}
