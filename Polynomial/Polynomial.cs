using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMath.PolynomialEquation
{
    public class Polynomial
    {
        [Serializable]
        public class NegativeRankException : Exception
        {
            public NegativeRankException() { }
            public NegativeRankException(string message) : base(message) { }
            public NegativeRankException(string message, Exception inner) : base(message, inner) { }
            protected NegativeRankException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
        public Polynomial(SortedList<int,decimal> _list)
        {
            if (_list.Count == 0)
            {
                throw new NullReferenceException("Null polynomial occured");
            }
            else
            {
                if (_list.ElementAt(0).Key < 0)
                {
                    throw new NegativeRankException("Negative rank isn't allowed");
                }
            }
            _data = _list;
        }
       public SortedList<int, decimal> _data { get; private set; }
       

    }
}
