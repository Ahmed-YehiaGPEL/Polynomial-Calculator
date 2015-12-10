using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
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
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int minimum_rank1 = first._data.First().Key;
            int minimum_rank2 = second._data.First().Key;
            if (minimum_rank1 != 0)
            {
                for (int i = 0; i < first._data.Keys.Count; i++)
                {
                    int oldKey = first._data.Keys[i];
                    decimal Val = first._data[oldKey];
                    first._data.Remove(oldKey);
                    first._data.Add(oldKey - minimum_rank1, Val);
                }
            }
            if (minimum_rank2 != 0)
            {
                for (int i = 0; i < second._data.Keys.Count; i++)
                {
                    int oldKey = second._data.Keys[i];
                    decimal Val = second._data[oldKey];
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
                    decimal Val = result._data[oldKey];
                    result._data.Remove(oldKey);
                    result._data.Add(oldKey + minimum_rank1 + minimum_rank2, Val);
                }
            }
            return result;
        }
        private static Polynomial MultiplyFFT(Polynomial first, Polynomial second)
        {
            int size = 1, lg_size = 0;
            while (size < first._data.Last().Key + second._data.Last().Key)
            {
                size *= 2;
                lg_size += 1;
            }

            List<Complex> fourierFirst = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierSecond = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size)),
                fourierResult = new List<Complex>(Enumerable.Repeat(new Complex(0.0, 0.0), size));
            foreach (var term in first._data)
            {
                fourierFirst[term.Key] = new Complex((double)term.Value, 0.0);
            }
            foreach (var term in second._data)
            {
                fourierSecond[term.Key] = new Complex((double)term.Value, 0.0);
            }

            fft(ref fourierFirst, lg_size, false);
            fft(ref fourierSecond, lg_size, false);


            for (int i = 0; i < size; i++)
            {
                fourierResult[i] = fourierFirst[i] * fourierSecond[i];
            }

            fft(ref fourierResult, lg_size, true);

            SortedList<int, decimal> Result = new SortedList<int, decimal>();
            for (int i = 0; i < size; i++)
                if (fourierResult[i].Real >= 1e-7 || fourierResult[i].Real <= -1e-7)
                    Result[i] = (decimal)fourierResult[i].Real;

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
            SortedList<int, decimal> result = new SortedList<int, decimal>();
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

    }
}
