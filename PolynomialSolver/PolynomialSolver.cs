using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CMath;
using CMath.PolynomialEquation;

namespace CMath.PolynomialSolver
{
    //Rename this class to your method 
    // ex : public class NewtonesSolver{}
    public class Solver
    {
        Complex[] cof;

        public Solver(double[] _c)
        {
            Complex[] _cn = new Complex[_c.Length];
            for (int i = 0; i < _c.Length; i++)
                _cn[i] = new Complex(_c[i], 0);
            cof = _cn;
        }

        private Solver(Complex[] _c)
        {
            cof = _c;
        }

        public Solver(Polynomial p)
        {
            Complex[] _cn = new Complex[p.Count];
            for (int i = 0; i < p.Count; i++)
                _cn[i] = p[i].Coefficient;
            cof = _cn;
        }

        public Complex[] solve()
        {
            //Complex[] res = new Complex[cof.Length];
            List<Complex> res = new List<Complex>();

            if (cof.Length == 3)
            {
                res = res.Concat<Complex>(QuadSolver(cof)).ToList();
            }
            else if (cof[0] == 0)
            {
                res.Add(new Complex(0, 0));
                List<Complex> nncof = cof.ToList<Complex>();
                nncof.RemoveAt(0);
                Complex[] ncof = nncof.ToArray();
                Solver s = new Solver(ncof);
                res = res.Concat<Complex>(s.solve()).ToList();
            }
            else
            {
                res.AddRange(newtonMethod());   
            }

            res = res.Distinct<Complex>().ToList();

            for (int i = 0; i < res.Count; i++)
            {
                double real = res[i].Real;
                double img = res[i].Imaginary;

                if (Math.Abs(real) < 1e-5)
                    real = 0;
                if (Math.Abs(img) < 1e-5)
                    img = 0;

                res[i] = new Complex(real, img);
            }

            return res.ToArray();
        }

        private Complex[] newtonMethod()
        {
            List<Complex> res = new List<Complex>();

            Complex[] dp = derive();

            Complex xb = cof[0] / cof[cof.Length - 1];
            Complex xn = cof[0] / cof[cof.Length - 1];
            int iters = 0;

            do
            {
                xb = xn;
                xn = xb - EvaluatePolynomial(xb) / EvaluatePolynomialDerivative(dp, xb);
                iters++;

            } while (Complex.Abs(xn - xb) >= 1e-7 && iters <= 64);
            xn = new Complex(Math.Round(xn.Real, 4), xn.Imaginary);
            res.Add(xn);

            Solver s = new Solver(longDiv(cof, new Complex[] { -xn, 1 }));
            res.AddRange(s.solve());

            res = res.Distinct<Complex>().ToList();
            return res.ToArray();
        }

        private Complex[] QuadSolver(Complex[] n)
        {
            List<Complex> res = new List<Complex>();

            Complex root1 = 0;
            Complex root2 = 0;
            Complex b = 0;
            Complex a = 0;
            Complex c = 0;
            Complex identifier = 0;

            a = n[2];
            b = n[1];
            c = n[0];

            identifier = (b * b) - (4 * a * c);

            root1 = (-b + Complex.Sqrt(identifier)) / (2 * a);
            root2 = (-b - Complex.Sqrt(identifier)) / (2 * a);

            res.Add(root1);
            res.Add(root2);

            return res.ToArray();
        }

        private Complex[] longDiv(Complex[] N, Complex[] D)
        {
            int dN, dD, dd, dq, dr;
            int i;

            dN = N.Length - 1;
            dD = D.Length - 1;

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

                    //Print('d', dd, d);

                    q[dN - dD] = N[dN] / d[dd];

                    //Print('q', dq, q);

                    for (i = 0; i < dq + 1; i++)
                        d[i] = d[i] * q[dN - dD];

                    //Print('d', dd, d);

                    for (i = 0; i < dN + 1; i++)
                        N[i] = N[i] - d[i];

                    dN--;

                    //Print('N', dN, N);
                }
            }

            for (i = 0; i < dN + 1; i++)
                r[i] = N[i];

            dr = dN;

            return q;
        }

        private Complex EvaluatePolynomial(Complex x)
        {
            Complex val = cof[0];

            for (int j = 1; j < cof.Length; j++)
                val += (cof[j] * Complex.Pow(x, j));

            return val;
        }

        private Complex EvaluatePolynomialDerivative(Complex[] d, Complex x)
        {
            Complex val = d[0];

            for (int j = 1; j < d.Length; j++)
                val += (d[j] * Complex.Pow(x, j));

            return val;
        }

        private Complex[] derive()
        {
            Complex[] dp = new Complex[cof.Length - 1];

            for (int i = 0; i < cof.Length - 1; i++)
                dp[i] = cof[i + 1] * (i + 1);

            return dp;
        }

    }
}
