using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMath.PolynomialEquation;

namespace Tests
{
    [TestClass]
    public class PolynomialToStringTest
    {
        [TestMethod]
        public void PolynomialToString_nullPolynomials()
        {
            Polynomial a = new Polynomial();
            Assert.AreEqual("(0,0)(0)\r\n", a.ToString());
        }

        [TestMethod]
        public void PolynomialToString_randomPolynomial()
        {
            Random rand = new Random(DateTime.Now.Second);
            Polynomial a = new Polynomial();
            int n = rand.Next(2, 1000);
            for (int i = 0; i < n; i++) 
                a.Add(new Term(rand.Next(), new System.Numerics.Complex(rand.NextDouble(), rand.NextDouble())));

            String[] s = a.ToString().Split('\n');
            Assert.IsFalse(s.Length == 0);
            double temp = 0.0;
            int itemp = 0;
            int cnt = 0;
            foreach (var line in s)
            {
                if(string.IsNullOrWhiteSpace(line)) // last line
                {
                    Assert.AreEqual(a.Count, cnt);
                    continue;
                }
                cnt++;
                string[] current = line.Split('(', ')', ',');
                Assert.AreEqual(6, current.Length);
                Assert.IsTrue(double.TryParse(current[1],out temp));
                Assert.IsTrue(double.TryParse(current[2],out temp));
                Assert.IsTrue(int.TryParse(current[4],out itemp));
            }
        }
    }
}
