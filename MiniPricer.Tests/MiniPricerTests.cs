using System;
using NUnit.Framework;

namespace MiniPricer.Tests
{
    [TestFixture]
    class MiniPricerTests
    {
        [TestCase]
        public void TestBoot()
        {
            Assert.Pass();    
        }

        [TestCase]
        public void PrixTest1d()
        {
            Product p = new Product();
            p.Prix = 10;
            p.Volatilite = 10; 
            DateTime DatePrevisonnel = DateTime.Now.AddDays(1);
            Assert.AreEqual(p.GetPrixPrev(DatePrevisonnel), 11);
        }

        [TestCase]
        public void PrixTest4d()
        {
            Product p = new Product();
            p.Prix = 10;
            p.Volatilite = 10; 
            DateTime DatePrevisonnel = DateTime.Now.AddDays(4);
            Assert.AreEqual(p.GetPrixPrev(DatePrevisonnel), 12.100000000000001);
        }

        [TestCase]
        public void PrixTest2dFeries()
        {
            Product p = new Product();
            p.Prix = 10;
            p.Volatilite = 10;
            p.Feries.Add(DateTime.Now.AddDays(1));
            DateTime DatePrevisonnel = DateTime.Now.AddDays(2);
            Assert.AreEqual(p.GetPrixPrev(DatePrevisonnel), 11);
        }

        [TestCase]
        public void PrixTest4dFeries()
        {
            Product p = new Product();
            p.Prix = 10;
            p.Volatilite = 10;
            p.Feries.Add(DateTime.Now.AddDays(1));
            DateTime DatePrevisonnel = DateTime.Now.AddDays(2);
            Assert.AreEqual(p.GetPrixPrev(DatePrevisonnel), 11);
        }

        [TestCase]
        public void PrixTest4d2Feries()
        {
            Product p = new Product();
            p.Prix = 10;
            p.Volatilite = 10;
            p.Feries.Add(DateTime.Now.AddDays(1));
            p.Feries.Add(DateTime.Now.AddDays(2));
            DateTime DatePrevisonnel = DateTime.Now.AddDays(2);
            Assert.AreEqual(p.GetPrixPrev(DatePrevisonnel), 10);
        }
    }
}
