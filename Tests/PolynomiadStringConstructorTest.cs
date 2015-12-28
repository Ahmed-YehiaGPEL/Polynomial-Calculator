using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMath.PolynomialEquation;

namespace Tests
{
    [TestClass]
    public class PolynomiadStringConstructorTest
    {
        [TestMethod]
        public void PolynomialStringConstructor_nullPolynomials()
        {
            Polynomial a = new Polynomial("");

            Assert.AreEqual("(0,0)(0)\r\n", a.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PolynomialStringConstructor_badformat1()
        {
            Polynomial a = new Polynomial("(0,0)()");
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PolynomialStringConstructor_badformat2()
        {
            Polynomial a = new Polynomial("(--1,0)(2)\r\n(1,2)(1)");
        }
    }
}
