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
            Polynomial a = new Polynomial(la), b = new Polynomial(lb);
            Polynomial c = a * b;
            PolynomialTrie t = new PolynomialTrie();
            t.insert(a, '*', b, c);
            Polynomial x;
            if (t.try_search(a, '*', b, out x))
            {
                foreach (var term in x)
                {
                    Console.WriteLine(term.Degree.ToString() + " " + term.Coefficient.Real.ToString());
                }
            }
        }
    }
}
