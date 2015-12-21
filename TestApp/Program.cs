using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using CMath.PolynomialEquation;
using CMath.PolynomialSolver;
using CMath.Trie;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedList<int, Complex> la = new SortedList<int, Complex>(), lb = new SortedList<int, Complex>();
            int degree;
            double real;
            for (int i = 0; i < n; i++)
            {
                degree = int.Parse(Console.ReadLine());
                real = double.Parse(Console.ReadLine());
                la.Add(degree, (Complex)real);
            }
            for (int i = 0; i < n; i++)
            {
                degree = int.Parse(Console.ReadLine());
                real = double.Parse(Console.ReadLine());
                lb.Add(degree, (Complex)real);
            }
            PolynomialTrie t = new PolynomialTrie();
            Polynomial a = new Polynomial(la), b = new Polynomial(lb);
            Polynomial x;
            Polynomial c = a * b;
            Solver s = new Solver(c);
            t.insert(c, s.solve().ToList());
            Polynomial d = new Polynomial("(1,0)(0)\n(1,0)(2)");
            PolynomialTrie t1 = new PolynomialTrie("KK.xml");
            if (t1.try_search(a, '*', b, out x))
            {
                Console.WriteLine("ok");
            }
            t.insert(a, '*', b, c);
            c = d * a;
            t.insert(d, '*', a, c);
            c = d * b;
            t.insert(d, '*', b, c);
            if (t.try_search(a, '*', b, out x))
            {
                foreach (var term in x)
                {
                    Console.WriteLine(term.Degree.ToString() + " " + term.Coefficient.Real.ToString());
                }
            }
            t.save("KK.xml");
            Console.Read();
        }
    }
}
