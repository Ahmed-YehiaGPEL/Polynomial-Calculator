using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Collections;

namespace CMath.PolynomialEquation
{
    #region term
    public class Term
    {
        public int Degree { get; private set; }
        public Complex Coefficient {get; set;}
        public Term(KeyValuePair<int, Complex> _t)
        {
            Degree = _t.Key;
            Coefficient = _t.Value;
        }
        public Term(int _degree, Complex _coefficient)
        {
            Degree = _degree;
            Coefficient = _coefficient;
        }
    }
    #endregion
    public class Polynomial
    {
        #region NegativeRankException
        [Serializable]
        private class NegativeRankException : Exception
        {
            public NegativeRankException() { }
            public NegativeRankException(string message) : base(message) { }
            public NegativeRankException(string message, Exception inner) : base(message, inner) { }
            protected NegativeRankException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
        #endregion
        #region Enumertator
        public class PolynomialEnumerator
        {
            private int position = -1;
            private Polynomial element;

            public PolynomialEnumerator(Polynomial _e)
            {
                this.element = _e;
            }

            public bool MoveNext()
            {
                if (position < element.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public Term Current
            {
                get
                {
                    return element[position];
                }
            }
        }
        #endregion
        #region data
        /// <summary>
        /// Returns a SortedList of degree,coefficient set for polynomial terms
        /// </summary>
        public SortedList<int, Complex> _data { get; private set; }
       /// <summary>
       /// Gets the specified term at the provided index
       /// </summary>
       /// <param name="index">index to get term at</param>
       /// <returns>Term</returns>
        public Term this[int index]
        {
            get { return new Term(_data.ElementAt(index)); }
        }
        /// <summary>
        /// Returns the number of terms
        /// </summary>
        public int Count { get { return _data.Count; } }
        #endregion
        #region construtors
        public Polynomial(SortedList<int,Complex> _list)
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
        public Polynomial(string _input)
        {
            if (string.IsNullOrWhiteSpace(_input))
            {
                throw new NullReferenceException("Null polynomial occured");
            }
            _data = new SortedList<int, Complex>();
            var PolynomialStringReader = new StringReader(_input);
            int degree;
            double real, imaginary;
            while (PolynomialStringReader.Peek() != -1)
            {
                string[] current = PolynomialStringReader.ReadLine().Split('(',')',',');
                real = double.Parse(current[1]);
                imaginary = double.Parse(current[2]);
                degree = int.Parse(current[4]);
                if (degree < 0)
                {
                    throw new NegativeRankException("Negative rank isn't allowed");
                }
                _data.Add(degree,new Complex(real,imaginary));
            }
        }
        public void add(Term newTerm)
        {
            if (_data.ContainsKey(newTerm.Degree))
            {
                _data[newTerm.Degree] = newTerm.Coefficient;
            }
            else
            {
                _data.Add(newTerm.Degree, newTerm.Coefficient);
            }
        }
        #endregion
        #region operators
        public override string ToString()
        {
            var PolynomialStringWriter = new StringWriter();
            foreach (var term in this)
            {
                PolynomialStringWriter.WriteLine(
                    "({0},{1})({2})",
                    term.Coefficient.Real.ToString(),
                    term.Coefficient.Imaginary.ToString(),
                    term.Degree.ToString());
            }
            return PolynomialStringWriter.ToString();
        }

        public bool Equals(Polynomial second)
        {
            return _data.SequenceEqual(second._data);
        }
        public PolynomialEnumerator GetEnumerator()
        {
            return new PolynomialEnumerator(this);
        }
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int minimum_rank1 = first._data.First().Key;
            int minimum_rank2 = second._data.First().Key;
            if (minimum_rank1 != 0)
            {
                for (int i = 0; i < first._data.Keys.Count; i++)
                {
                    int oldKey = first._data.Keys[i];
                    Complex Val = first._data[oldKey];
                    first._data.Remove(oldKey);
                    first._data.Add(oldKey - minimum_rank1, Val);
                }
            }
            if (minimum_rank2 != 0)
            {
                for (int i = 0; i < second._data.Keys.Count; i++)
                {
                    int oldKey = second._data.Keys[i];
                    Complex Val = second._data[oldKey];
                    second._data.Remove(oldKey);
                    second._data.Add(oldKey - minimum_rank2, Val);
                }
            }
            Polynomial result;
            if (first._data.Count * second._data.Count <= first._data.Last().Key + second._data.Last().Key)
                result = NormalMultiply(first, second);
            else
                result = MultiplyFFT(first, second);

            if (minimum_rank1 + minimum_rank2 != 0)
            {
                for (int i = result._data.Keys.Count - 1; i >= 0; i--)
                {
                    int oldKey = result._data.Keys[i];
                    Complex Val = result._data[oldKey];
                    result._data.Remove(oldKey);
                    result._data.Add(oldKey + minimum_rank1 + minimum_rank2, Val);
                }
            }
            return result;
        }
        // Mock add
        public static Polynomial operator +(Polynomial first,Polynomial second)
        {
            return new Polynomial("");
        }
        // Mock subtract
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return new Polynomial("");
        }
        #endregion
        #region MuliplyUtilies
        private static Polynomial MultiplyFFT(Polynomial first, Polynomial second)
        {
            int size = 1, lg_size = 0;
            while (size <= first._data.Last().Key + second._data.Last().Key)
            {
                size *= 2;
                lg_size += 1;
            }

            List<Complex> fourierFirst = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierSecond = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierResult = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size));
            foreach (var term in first._data)
            {
                fourierFirst[term.Key] = term.Value;
            }
            foreach (var term in second._data)
            {
                fourierSecond[term.Key] = term.Value;
            }

            fft(ref fourierFirst, lg_size, false);
            fft(ref fourierSecond, lg_size, false);


            for (int i = 0; i < size; i++)
            {
                fourierResult[i] = fourierFirst[i] * fourierSecond[i];
            }

            fft(ref fourierResult, lg_size, true);

            SortedList<int, Complex> Result = new SortedList<int, Complex>();
            for (int i = 0; i < size; i++)
                if (fourierResult[i].Real >= 1e-7 || fourierResult[i].Real <= -1e-7
                    || fourierResult[i].Imaginary >= 1e-7 || fourierResult[i].Imaginary <= -1e-7)
                    Result[i] = fourierResult[i];

            return new Polynomial(Result);
        }
        private static void fft(ref List<Complex> input, int lg_size, bool invert)
        {
            if (input.Count <= 1) return;

            List<int> reverse = new List<int>();
            reverse.Add(0);
            int highest_bit = 0;
            for (int i = 1; i < input.Count; i++)
            {
                if (i >= (1<<(highest_bit+1))) highest_bit ++;
                reverse.Add(reverse[i - (1<<highest_bit)] | (1 << (lg_size - 1 - highest_bit)));
                if (i < reverse[i])
                {
                    Complex temp = input[i];
                    input[i] = input[reverse[i]];
                    input[reverse[i]] = temp;
                }
            }
            for (int length = 2; length <= input.Count; length *= 2)
            {
                double angle = 2 * Math.PI / length * (invert ? -1.0 : 1.0);
                Complex wangle = new Complex(Math.Cos(angle),Math.Sin(angle));
                for (int i = 0; i < input.Count; i += length)
                {
                    Complex current = new Complex(1.0, 0.0);
                    for (int j = 0; j < length / 2; j++)
                    {
                        Complex u = input[i + j], v = input[i + j + length / 2] * current;
                        input[i + j] = u + v;
                        input[i + j + length / 2] = u - v;
                        current *= wangle;
                    }
                }
            }
            if (invert)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    input[i] /= input.Count;
                }
            }
        }
        private static Polynomial NormalMultiply(Polynomial first, Polynomial second)
        {
            SortedList<int, Complex> result = new SortedList<int, Complex>();
            foreach (var termFirst in first._data)
            {
                foreach (var termSecond in second._data)
                {
                    if(result.Keys.Contains(termFirst.Key + termSecond.Key))
                        result[termFirst.Key + termSecond.Key] += termFirst.Value * termSecond.Value;
                    else
                        result.Add(termFirst.Key + termSecond.Key, termFirst.Value * termSecond.Value);
                }
            }
            return new Polynomial(result);
        }
        #endregion
    }
}
