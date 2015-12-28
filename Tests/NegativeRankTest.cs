using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMath.PolynomialEquation;
using System.Collections.Generic;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class NegativeRankTest
    {

        [TestMethod]
        [ExpectedException(typeof(NegativeRankException))]
        public void PolynomialStringConstructor_NegativeRank()
        {
            Polynomial a = new Polynomial("(1,-2)(-5)\r\n(1,0)(2)");
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeRankException))]
        public void PolynomialListConstructor_NegativeRank()
        {
            var _list = new SortedList<int, Complex>();
            _list.Add(-5, 1);
            _list.Add(2,new Complex(1,-2));
            Polynomial a = new Polynomial("(1,-2)(-5)\r\n(1,0)(2)");
        }
    }
}
