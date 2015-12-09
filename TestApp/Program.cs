using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMath.PolynomialEquation;
using CMath.PolynomialSolver;
using CMath.Trie;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                //rank, coef
             Polynomial pl = new Polynomial(new SortedList<int, decimal> { 
            {2,(decimal)4.0},
            {-1,(decimal)3.0},
            {5,(decimal)5.0},
            {6,(decimal)8.0},
            });
             Console.WriteLine(pl._data.Count.ToString());

             foreach (var item in pl._data)
             {
                     Console.WriteLine(item.Key.ToString() + " " + item.Value.ToString());
             }
             Console.Read();

            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.Read();

            }
        }
    }
}
