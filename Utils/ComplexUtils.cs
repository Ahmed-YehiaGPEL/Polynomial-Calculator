using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CMath.Utils
{
    public static class ComplexUtils
    {
        private static int _precision = 6;
        public static int Precision {
            get { return _precision; } 
            set { _precision = value; }
        }
        public static Complex complexParseBuiltin(string value)
        {
            string[] temp = value.Split('(', ',', ')');
            return new Complex(double.Parse(temp[1]), double.Parse(temp[2]));
        }
        public static bool TryParseComplex(string _number, out Complex _ref)
        {
            _number = _number.ToLower();
            _ref = new Complex();
            if (String.IsNullOrWhiteSpace(_number))
            {
                return false;
            }
            _number = _number.Replace(" ", "");
            double _real, _img;
            bool neg = false;
            if (_number[0] == '-')
            {
                neg = true;
                _number = _number.Substring(1);
            }
            if (!_number.Contains('+') && !_number.Contains('-'))
            {
                if (_number.Contains("i"))
                {
                    if (_number[_number.Length - 1] != 'i')
                        return false;
                    _number = _number.Substring(0, _number.Length - 1);
                    if (_number == "")
                    {
                        _ref = 0;
                        return true;
                    }
                    if (!double.TryParse(_number, out _img))
                        return false;
                    if (neg) _img *= -1;
                    _ref = new Complex(0.0, _img);
                    return true;
                }
                if (!double.TryParse(_number, out _real))
                    return false;
                if (neg) _real *= -1;
                _ref = new Complex(_real, 0.0);
                return true;
            }
            bool negi = _number.Contains('-');
            string real = _number.Split(new char[] { '+','-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (real == "")
                return false;
            if (!double.TryParse(real, out _real))
                return false;
            if (neg) _real *= -1;
            string complex = _number.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries)[1];
            if (complex == "")
                return false;
            if (complex[complex.Length - 1] != 'i')
                return false;
            complex = complex.Substring(0, complex.Length - 1);
            if (!double.TryParse(complex, out _img))
                return false;
            if (negi) _img *= -1;
            _ref = new Complex(_real, _img);
            return true;
        }
        public static Complex ParseComplex(string _number)
        {
            _number = _number.ToLower();
            if (String.IsNullOrWhiteSpace(_number))
            {
                return 0;
            }
            _number = _number.Replace(" ", "");
            double _real, _img;
            bool neg = false;
            if (_number[0] == '-')
            {
                neg = true;
                _number = _number.Substring(1);
            }
            if (!_number.Contains('+') && !_number.Contains('-'))
            {
                if (_number.Contains("i"))
                {
                    if (_number[_number.Length - 1] != 'i')
                        return 0;
                    _number = _number.Substring(0, _number.Length - 1);
                    if (_number == "")
                    {
                        return 0;
                    }
                    if (!double.TryParse(_number, out _img))
                        return 0;
                    if (neg) _img *= -1;
                    return new Complex(0.0, _img);;
                }
                if (!double.TryParse(_number, out _real))
                    return 0;
                if (neg) _real *= -1;
                return new Complex(_real, 0.0);
            }
            bool negi = _number.Contains('-');
            string real = _number.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (real == "")
                return 0;
            if (!double.TryParse(real, out _real))
                return 0;
            if (neg) _real *= -1;
            string complex = _number.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries)[1];
            if (complex == "")
                return 0;
            if (complex[complex.Length - 1] != 'i')
                return 0;
            complex = complex.Substring(0, complex.Length - 1);
            if (!double.TryParse(complex, out _img))
                return 0;
            if (negi) _img *= -1;
            return new Complex(_real, _img);
        }
        public static Double normalize(Double d)
        {
            d *= Math.Pow(10, Precision);
            d = Math.Round(d);
            d /= Math.Pow(10, Precision);
            return d;
        }
        public static String ComplexToString(Complex c)
        {
            c = new Complex(normalize(c.Real), normalize(c.Imaginary));
            if (c.Imaginary == 0) return c.Real.ToString();
            if (c.Real == 0) return c.Imaginary.ToString() + "i";
            return c.Real.ToString() + (c.Imaginary >= 0.0 ? "+" : "") + c.Imaginary.ToString() + "i";
        }
        public static List<Complex> complexListParse(IEnumerable<XElement> elements)
        {
            List<Complex> result = new List<Complex>();
            foreach (var element in elements)
            {
                result.Add(ParseComplex(element.Value));
            }
            return result;
        }
        public static String ComplexListToString(List<Complex> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var complex in list)
            {
                builder.AppendLine(ComplexToString(complex));
            }
            return builder.ToString();
        }
    }
}
