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
            Console.Write("Done");
            
        }
    }
}
