using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TwoNumberString()
        {
            Assert.AreEqual(7, StringCalculator.Calculate("3 , 4"));
        }
        [TestMethod]
        public void TwoNumberString2()
        {
            Assert.AreEqual(9, StringCalculator.Calculate("5 , 4"));
        }
        [TestMethod]
        public void BlankString()
        {
            Assert.AreEqual(0, StringCalculator.Calculate(""));
        }
        [TestMethod]
        public void OneNumberString()
        {
            Assert.AreEqual(5, StringCalculator.Calculate("5"));
        }
        [TestMethod]
        public void NewLineDelimitor()
        {
            Assert.AreEqual(9, StringCalculator.Calculate("5 \n 4"));
        }
        [TestMethod]
        public void CustomDelimitor()
        {
            Assert.AreEqual(10, StringCalculator.Calculate("//JimIsAwesome\n5JimIsAwesome5"));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeInNumbersToAdd()
        {
            StringCalculator.Calculate("-2,-3");
        }
        [TestMethod]
        public void IgnoreOverOneThousand()
        {
            Assert.AreEqual(5, StringCalculator.Calculate("//JimIsAwesome\n5JimIsAwesome1001"));
        }
        [TestMethod]
        public void MultipleDelimitors()
        {
            Assert.AreEqual(34, StringCalculator.Calculate("//[,][$][@]\n10,9$8@7"));
        }
    }
}