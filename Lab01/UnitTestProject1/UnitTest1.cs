using Kalkulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 calculator = new Class1();   
            Random random = new Random();
            int y = random.Next();
            int x = calculator.Add(4, y);
            Assert.AreEqual(x, 4 + y);    
        }
    }
}

