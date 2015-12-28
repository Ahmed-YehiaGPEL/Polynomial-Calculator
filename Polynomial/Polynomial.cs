using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Collections;
using PolynomialEquation.Properties;

namespace CMath.PolynomialEquation
{
    #region NegativeRankException
    [Serializable]
    public class NegativeRankException : ArgumentException
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
    #region Term
    public class Term
    {
        private int _degree;
        public int Degree
        {
            get
            {
                return _degree;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativeRankException();
                }
                _degree = value;
            }
        }
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
        public override bool Equals(object obj)
        {
            return (this.Coefficient.Real == (obj as Term).Coefficient.Real && this.Coefficient.Imaginary == (obj as Term).Coefficient.Imaginary && this.Degree == (obj as Term).Degree);
        }
        public KeyValuePair<int, Complex> ToPair()
        {
            return new KeyValuePair<int, Complex>(this.Degree, this.Coefficient);
        }
        public override string ToString()
        {
            return "(" + this.Coefficient.Real.ToString() + "," 
                + this.Coefficient.Imaginary.ToString() + ")(" + this.Degree.ToString() + ")";
        }
    }
    #endregion
    public class Polynomial
    {
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
        public int Count
        {
            get { return _data.Count; }
        }
        public int Degree { 
            get { return this[this.Count - 1].Degree; }
        }
        public Term Back { 
            get { return this[this.Count - 1]; } 
        }
        public Complex CoefficientOf(int degree)
        {
            return _data[degree];
        }
        public bool isnull()
        {
            return (Count == 1 && this[0].Coefficient == 0);
        }
        public void Add(Term newTerm)
        {
            newTerm.Coefficient = new Complex(
                Math.Round(newTerm.Coefficient.Real * Math.Pow(10.0, (double)Settings.Default.Precision))
                / Math.Pow(10.0, (double)Settings.Default.Precision),
                Math.Round(newTerm.Coefficient.Imaginary * Math.Pow(10.0, (double)Settings.Default.Precision))
                / Math.Pow(10.0, (double)Settings.Default.Precision)
                );
            if (newTerm.Coefficient == 0 && newTerm.Degree != 0) return;
            if (_data.ContainsKey(newTerm.Degree))
            {
                _data[newTerm.Degree] = newTerm.Coefficient;
            }
            else
            {
                _data.Add(newTerm.Degree, newTerm.Coefficient);
            }
            if (this.Contains(new Term(0, 0)) && newTerm.Degree != 0)
            {
                this.Remove(0);
            }
        }
        public bool Contains(Term _term)
        {
            return _data.Contains(_term.ToPair());
        }
        public bool Contains(int degree)
        {
            return _data.ContainsKey(degree);
        }
        public void Remove(int degree)
        {
            _data.Remove(degree);
            if (Count == 0) this.Add(new Term(0, 0));
        }
        #endregion
        #region construtors
        public Polynomial(SortedList<int,Complex> _list)
        {
            if (_list.Count == 0)
            {
                _list.Add(0, 0);
            }
            if (_list.ElementAt(0).Key < 0)
            {
                throw new NegativeRankException("Negative rank isn't allowed");
            }
            _data = _list;
        }
        public Polynomial()
        {
            _data = new SortedList<int, Complex>();
            _data.Add(0, 0);
        }
        public Polynomial(string _input)
        {
            if (string.IsNullOrWhiteSpace(_input))
            {
                _input += "(0,0)(0)";
            }
            _data = new SortedList<int, Complex>();
            var PolynomialStringReader = new StringReader(_input);
            int degree;
            double real, imaginary;
            while (PolynomialStringReader.Peek() != -1)
            {
                string[] current = PolynomialStringReader.ReadLine().Split('(',')',',');
                if (current.Length != 6) throw new FormatException("bad polynomial format");
                if (!double.TryParse(current[1], out real)) throw new FormatException("bad polynomial format");
                if (!double.TryParse(current[2], out imaginary)) throw new FormatException("bad polynomial format");
                if (!int.TryParse(current[4], out degree)) throw new FormatException("bad polynomial format");
                if (degree < 0)
                {
                    throw new NegativeRankException("Negative rank isn't allowed");
                }
                _data.Add(degree,new Complex(real,imaginary));
            }
        }
        #endregion
        #region operators
        public override string ToString()
        {
            var PolynomialStringWriter = new StringWriter();
            foreach (var term in this)
            {
                PolynomialStringWriter.WriteLine(term.ToString());
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
            int minimum_rank1 = first[0].Degree;
            int minimum_rank2 = second[0].Degree;
            if (minimum_rank1 != 0)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    Term current = first[i];
                    first.Remove(current.Degree);
                    current.Degree -= minimum_rank1;
                    first.Add(current);
                }
            }
            if (minimum_rank2 != 0)
            {
                for (int i = 0; i < second.Count; i++)
                {
                    Term current = second[i];
                    second.Remove(current.Degree);
                    current.Degree -= minimum_rank2;
                    second.Add(current);
                }
            }
            Polynomial result;
            if (first.Count * second.Count <= first.Degree + second.Degree)
                result = NormalMultiply(first, second);
            else
                result = MultiplyFFT(first, second);

            if (minimum_rank1 != 0)
            {
                for (int i = first.Count - 1; i >= 0; i--)
                {
                    Term current = first[i];
                    first.Remove(current.Degree);
                    current.Degree += minimum_rank1;
                    first.Add(current);
                }
            }
            if (minimum_rank2 != 0)
            {
                for (int i = second.Count - 1; i >= 0; i--)
                {
                    Term current = second[i];
                    second.Remove(current.Degree);
                    current.Degree += minimum_rank2;
                    second.Add(current);
                }
            }
            if (minimum_rank1 + minimum_rank2 != 0)
            {
                for (int i = result.Count - 1; i >= 0; i--)
                {
                    Term current = result[i];
                    result.Remove(current.Degree);
                    current.Degree += minimum_rank1 + minimum_rank2;
                    result.Add(current);
                }
            }
            return result;
        }

        public static Polynomial operator /(Polynomial first, Polynomial second)
        {
            Complex[] firstC = new Complex[first.Degree + 1];
            for (int i = 0; i < first.Count; i++)
                firstC[first[i].Degree] = first[i].Coefficient;

            Complex[] secondC = new Complex[second.Degree + 1];
            for (int i = 0; i < second.Count; i++)
                secondC[second[i].Degree] = second[i].Coefficient;

            Complex[] res = longDiv(firstC, secondC, false);
            Polynomial ret = new Polynomial();
            for (int i = 0; i < res.Length; i++)
                if (res[i] != new Complex(0, 0))
                    ret.Add(new Term(i, res[i]));
            return ret;
        }

        public static Polynomial operator %(Polynomial first, Polynomial second)
        {
            Complex[] firstC = new Complex[first.Degree + 1];
            for (int i = 0; i < first.Count; i++)
                firstC[first[i].Degree] = first[i].Coefficient;

            Complex[] secondC = new Complex[second.Degree + 1];
            for (int i = 0; i < second.Count; i++)
                secondC[second[i].Degree] = second[i].Coefficient;

            Complex[] res = longDiv(firstC, secondC, true);
            Polynomial ret = new Polynomial();
            for (int i = 0; i < res.Length; i++)
                if (res[i] != new Complex(0, 0))
                    ret.Add(new Term(i, res[i]));
            return ret;
        }

        public static Polynomial operator +(Polynomial first,Polynomial second)
        {
            Polynomial result = new Polynomial();
            foreach (var firstTerm in first)
            {
                if (second.Contains(firstTerm.Degree))
                {
                    if(second.CoefficientOf(firstTerm.Degree) + firstTerm.Coefficient != 0)
                        result.Add(new Term(firstTerm.Degree, second.CoefficientOf(firstTerm.Degree) + firstTerm.Coefficient));
                }else{
                    if(firstTerm.Coefficient != 0)
                       result.Add(firstTerm);
                }
            }
            foreach (var secondTerm in second)
            {
                if (!result.Contains(secondTerm.Degree) && !first.Contains(secondTerm.Degree))
                {
                    if (secondTerm.Coefficient != 0)
                        result.Add(secondTerm);
                }
            }
            return result;
        }
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {

            Polynomial result = new Polynomial();
            foreach (var firstTerm in first)
            {
                if (second.Contains(firstTerm.Degree))
                {
                    if (firstTerm.Coefficient - second.CoefficientOf(firstTerm.Degree) != 0)
                        result.Add(new Term(firstTerm.Degree, firstTerm.Coefficient - second.CoefficientOf(firstTerm.Degree)));
                }
                else
                {
                    if (firstTerm.Coefficient != 0)
                        result.Add(firstTerm);
                }
            }
            foreach (var secondTerm in second)
            {
                if (!result.Contains(secondTerm.Degree) && !first.Contains(secondTerm.Degree))
                {
                    secondTerm.Coefficient = -secondTerm.Coefficient;
                    if (secondTerm.Coefficient != 0)
                        result.Add(secondTerm);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns the level-th derivative of the equation
        /// </summary>
        /// <returns></returns>
        public static Polynomial operator^(Polynomial equation, int level)
        {
            Polynomial result = new Polynomial();
            foreach (var item in equation)
            {
                if (item.Degree < level) 
                    continue;
                item.Degree -= level;
                result.Add(item);
            }
            return result;
        }
        public static Polynomial __gcd(Polynomial first, Polynomial second)
        {
            if (second.Degree > first.Degree)
            {
                Polynomial temp = second;
                second = first;
                first = temp;
            }
            while (!second.isnull())
            {
                Polynomial temp = first;
                first = second;
                second = temp % second;
            }
            return first;
        }
        #endregion
        #region MuliplyUtilies
        private static Polynomial MultiplyFFT(Polynomial first, Polynomial second)
        {
            int size = 1, lg_size = 0;
            while (size <= first.Degree + second.Degree)
            {
                size *= 2;
                lg_size ++;
            }

            List<Complex> fourierFirst = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierSecond = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierResult = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size));
            foreach (var term in first)
            {
                fourierFirst[term.Degree] = term.Coefficient;
            }
            foreach (var term in second)
            {
                fourierSecond[term.Degree] = term.Coefficient;
            }

            fft(ref fourierFirst, lg_size, false);
            fft(ref fourierSecond, lg_size, false);


            for (int i = 0; i < size; i++)
            {
                fourierResult[i] = fourierFirst[i] * fourierSecond[i];
            }

            fft(ref fourierResult, lg_size, true);

            Polynomial Result = new Polynomial();
            for (int i = 0; i < size; i++)
                if (fourierResult[i] != 0)
                    Result.Add(new Term(i,fourierResult[i]));

            return Result;
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
            Polynomial result = new Polynomial();
            foreach (var termFirst in first)
            {
                if (termFirst.Coefficient == 0) continue;
                foreach (var termSecond in second)
                {
                    if (result.Contains(termFirst.Degree + termSecond.Degree))
                        result.Add(new Term(termFirst.Degree + termSecond.Degree,
                            termFirst.Coefficient * termSecond.Coefficient
                            + result.CoefficientOf(termFirst.Degree + termSecond.Degree)));
                    else
                        result.Add(new Term(termFirst.Degree + termSecond.Degree, termFirst.Coefficient * termSecond.Coefficient));
                    if (result.CoefficientOf(termFirst.Degree + termSecond.Degree) == 0) 
                        result.Remove(termFirst.Degree + termSecond.Degree);
                }
            }
            return result;
        }
        #endregion
        #region DivisionUtilies
        private static Complex[] longDiv(Complex[] N, Complex[] D, bool modulus)
        {
            int dN, dD, dd, dq, dr;
            int i;

            dN = N.Length - 1;
            dD = D.Length - 1;

            if (dD > dN)
            {
                if (modulus) return N;
                else return new Complex[1];
            }

            dq = dN - dD;
            dr = dN - dD;

            Complex[] d = new Complex[dN + 1];
            for (i = dD + 1; i < dN + 1; i++)
                d[i] = 0;

            Complex[] q = new Complex[dq + 1];
            for (i = 0; i < dq + 1; i++)
                q[i] = 0;

            Complex[] r = new Complex[dr + 1];
            for (i = 0; i < dr + 1; i++)
                r[i] = 0;

            if (dN >= dD)
            {
                while (dN >= dD)
                {
                    for (i = 0; i < dN + 1; i++)
                        d[i] = 0;

                    for (i = 0; i < dD + 1; i++)
                        d[i + dN - dD] = D[i];

                    dd = dN;
                    
                    q[dN - dD] = N[dN] / d[dd];
                    
                    for (i = 0; i < dq + 1; i++)
                        d[i] = d[i] * q[dN - dD];

                    for (i = 0; i < dN + 1; i++)
                        N[i] = N[i] - d[i];

                    dN--;
                }
            }

            while (dN > 0 && N[dN] == 0) dN--;
            for (i = 0; i < dN + 1; i++)
                r[i] = N[i];

            dr = dN;
            if (!modulus)
                return q;
            else
                return r;
        }
        #endregion
    }
}
