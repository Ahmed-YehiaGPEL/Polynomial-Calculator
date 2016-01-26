using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CMath.Trie
{
    public static class Constants
    {
        public static readonly Dictionary<char, string> operationsName =
            new Dictionary<char, string> {
            {',' , "Tree"},
            {'*', "Result"},
            {'+', "Result"},
            {'-', "Result"},
            {'/', "Result"},
            {'g', "Result"},
            {'%', "Result"},
            {'^', "Result"},
            {'I', "Result"},
            {'s', "params"},
            {'d', "params"},
            {'r', "listComplex"}
            };
        public static readonly Dictionary<Char,String> OnePolynomialColumnsName =
            new Dictionary<Char,String>{
            {'\0',"Polynomial"},
            {'^',"Derivative"},
            {'I',"Integral"},
            {'r',"Roots"},
            };
        public static readonly Dictionary<Char, String> TwoPolynomialsColumnsName =
            new Dictionary<Char, String>{
            {'\0',"Polynomial1"},
            {' ',"Polynomial2"},
            {'+',"Addition"},
            {'-',"Subtraction"},
            {'*',"Multiplication"},
            {'/',"Division"},
            {'g',"GCD"},
            {'%',"Modulus"},
            };
        public static readonly List<String> SubstitutionColumnsName =
            new List<String>{
            "Polynomial",
            "X",
            "Result",
            };
        public static readonly List<String> DefiniteIntColumnsName =
            new List<String>{
            "Polynomial",
            "A",
            "B",
            "Result",
            };
    }
}
