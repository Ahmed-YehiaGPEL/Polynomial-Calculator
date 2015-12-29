using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMath.PolynomialEquation;
using CMath.Trie;
using System.Numerics;

namespace Stress
{
    class Program
    {
        static void Main(string[] args)
        {
            PolynomialTrie tr = new PolynomialTrie("kk.xml");
            for (int i = 0; i < 2; i++)
            {
                Polynomial a = new Polynomial();
                int n = int.Parse(Console.ReadLine());
                for (int j = 0; j < n; j++)
                {
                    int degree = int.Parse(Console.ReadLine());
                    double coeff = double.Parse(Console.ReadLine());
                    a.Add(new Term(degree, coeff));
                }
                double X = double.Parse(Console.ReadLine());
                Console.WriteLine(a.substitute(X));
                tr.insert(a, X, a.substitute(X));
            }
            tr.save("kk.xml");
            Console.Read();
            return;
            Random x = new Random(1256);
            
            PolynomialTrie _pl = new PolynomialTrie();
            

            for (int j = 0; j < 100; j++)
            {
                Polynomial _rand = new Polynomial();
                Polynomial _rand2 = new Polynomial();
                for (int i = 0; i < 100; i++)
                {
                    _rand.Add(new Term((int)Math.Abs(x.Next((int)1E6)), new Complex(x.NextDouble(), x.NextDouble())));
                    _rand2.Add(new Term((int)Math.Abs(x.Next((int)1E6)), new Complex(x.NextDouble(), x.NextDouble())));
                }
                _pl.insert(_rand, '*', _rand2, _rand * _rand2);
                Console.Write("Mult " + j.ToString());
                _pl.insert(_rand, '/', _rand2, _rand * _rand2);
                Console.Write("Div " + j.ToString());
                Console.WriteLine();
            }
            _pl.save("appdataStress.xml");
            Console.Write("Done");
            
        }
    }
}
