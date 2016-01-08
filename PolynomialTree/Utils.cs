using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CMath.Trie
{
    public class ListComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> obj)
        {
            int hashcode = 0;
            foreach (T t in obj)
            {
                hashcode ^= t.GetHashCode();
            }
            return hashcode;
        }
    }
    public class Utils
    {
        public static Dictionary<char, string> operationsName = new Dictionary<char, string> { 
            {'=' , "Result"},
            {'*', "Tree"},
            {'+', "Tree"},
            {'-', "Tree"},
            {'/', "Tree"},
            {'g', "Tree"},
            {'%', "Tree"},
            {'^', "Result"},
            {'s', "params"},
            {'d', "params"},
            {'r', "listComplex"}
        };
        public static Complex complexParse(string value)
        {
            string[] temp = value.Split('(', ',', ')');
            return new Complex(double.Parse(temp[1]), double.Parse(temp[2]));
        }
        public static List<Complex> complexListParse(IEnumerable<XElement> elements)
        {
            List<Complex> result = new List<Complex>();
            foreach (var element in elements)
            {
                result.Add(complexParse(element.Value));
            }
            return result;
        }
    }
}
