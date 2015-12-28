using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMath.PolynomialEquation;

namespace Tests
{
    [TestClass]
    public class PolynomialAdditionTest
    {
        [TestMethod]
        public void PolynomialAddition_nullPolynomials()
        {
            Polynomial a = new Polynomial(), b = new Polynomial();
            Polynomial c = new Polynomial("(5.5,0)(2)\r\n"), d = new Polynomial("(-5.5,0)(2)\r\n");


            Polynomial e = a + b;
            Polynomial f = c + d;

            Assert.IsTrue(e.isnull(), "Null polynomials test failed");
            Assert.IsTrue(f.isnull(), "Null polynomials test failed");
        }

        [TestMethod]
        public void PolynomialAddition_zeroTerm()
        {
            Polynomial a = new Polynomial("(1,0)(1)\r\n(1,0)(0)");
            Polynomial b = new Polynomial("(1,0)(1)\r\n(-1,0)(0)");

            Polynomial c = a + b;

            Assert.AreEqual("(2,0)(1)\r\n",c.ToString(),"Zero-term test failed");
        }

        [TestMethod]
        public void PolynomialAddition_randomPolynomial()
        {
            Random rand = new Random(DateTime.Now.Second);
            Polynomial a = new Polynomial(),b = new Polynomial();
            int n = rand.Next(2,1000);
            for (int i = 0; i < n; i++)
            {
                a.Add(new Term(rand.Next(), new System.Numerics.Complex(rand.NextDouble(), rand.NextDouble())));
            }
            n = rand.Next(2, 1000);
            for (int i = 0; i < n; i++)
            {
                b.Add(new Term(rand.Next(), new System.Numerics.Complex(rand.NextDouble(), rand.NextDouble())));
            }


            Polynomial c = a + b;

            String msg = "random Polynomials test failed";
            foreach (var term in c)
            {
                Assert.AreNotEqual(0.0, term.Coefficient,msg);
                Assert.IsTrue(a.Contains(term.Degree) || b.Contains(term.Degree),msg);
                if (a.Contains(term.Degree))
                {
                    if (b.Contains(term.Degree))
                    {
                        Assert.AreEqual(a.CoefficientOf(term.Degree) + b.CoefficientOf(term.Degree), term.Coefficient, msg);
                    }
                    else
                    {
                        Assert.AreEqual(a.CoefficientOf(term.Degree), term.Coefficient, msg);
                    }
                }
                else
                {
                    Assert.IsTrue(b.Contains(term.Degree),msg);
                    Assert.AreEqual(b.CoefficientOf(term.Degree), term.Coefficient, msg);
                }
            }
        }


    }
}
