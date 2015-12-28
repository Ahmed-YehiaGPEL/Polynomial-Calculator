using System;
using Android.App;
using System.Collections;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CMath;
using CMath.PolynomialEquation;
using CMath.PolynomialSolver;
using Android.Text;
using CMath.Trie;
using System.Numerics;
using System.Threading;

namespace Polynomial_Calculator
{
    [Activity(Label = "Polynomial Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button BtnAddPoly;
        Button BtnAdd, BtnSub, BtnMul, BtnDiv, BtnMod, BtnGcd, BtnSlv;

        internal PolynomialTrie _historyTrie;
        
        ListView ListPoly;
        ArrayAdapter<ListElement> ListPolyAdapter;

        List<Polynomial> polynomials;

        View promptView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            LinearLayout li = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            li.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
            li = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            li.SetBackgroundColor(Android.Graphics.Color.Orange);
            li = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            li.SetBackgroundColor(Android.Graphics.Color.Orange);

            polynomials = new List<Polynomial>();
            _historyTrie = new PolynomialTrie();

            BtnAddPoly = FindViewById<Button>(Resource.Id.BtnAddPoly);
            BtnAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            BtnSub = FindViewById<Button>(Resource.Id.buttonSub);
            BtnMul = FindViewById<Button>(Resource.Id.buttonMul);
            BtnDiv = FindViewById<Button>(Resource.Id.buttonDiv);
            BtnMod = FindViewById<Button>(Resource.Id.buttonMod);
            BtnGcd = FindViewById<Button>(Resource.Id.buttonGcd);
            BtnSlv = FindViewById<Button>(Resource.Id.buttonSlv);

            ListPoly = FindViewById<ListView>(Resource.Id.listPoly);

            ListPolyAdapter = new ArrayAdapter<ListElement>(this, Android.Resource.Layout.SimpleListItem1);
            ListPoly.Adapter = ListPolyAdapter;

            BtnAddPoly.Click += new EventHandler(addPolynomial);
            BtnAdd.Click += PerformOperations;
            BtnSub.Click += PerformOperations;
            BtnMul.Click += PerformOperations;
            BtnDiv.Click += PerformOperations;
            BtnMod.Click += PerformOperations;
            BtnGcd.Click += PerformOperations;
            BtnSlv.Click += PerformOperations;

            ListPoly.ItemClick += ListPoly_ItemClick;
        }

        private void ListPoly_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var elem = ListPolyAdapter.GetItem(e.Position);

            string displayMessage = elem.ToString(true);

            AlertDialog.Builder builderSingle = new AlertDialog.Builder(this);
            builderSingle.SetTitle("Log:");
            builderSingle.SetMessage(displayMessage);
            builderSingle.SetNegativeButton("Ok", delegate { });
            builderSingle.Show();

            //Console.WriteLine(displayMessage);
        }

        private void PerformOperations(object sender, EventArgs e)
        {
            int cnt = 2;

            if (((Button)sender).Id == Resource.Id.buttonSlv)
                cnt = 1;

            List<Polynomial> ps = new List<Polynomial>();

            ArrayAdapter<Polynomial> tpa = new ArrayAdapter<Polynomial>(this, Android.Resource.Layout.SimpleListItem1, polynomials);


            for (int i = 0; i < cnt; i++)
            {
                AlertDialog.Builder builderSingle = new AlertDialog.Builder(this);
                builderSingle.SetTitle("Select Polynomial No." + (cnt - i).ToString());
                builderSingle.SetNegativeButton("Cancel", delegate { });


                builderSingle.SetAdapter(tpa, (adapSender, args) =>
                {
                    ps.Add(polynomials[args.Which]);

                    if (ps.Count == cnt)
                        PerformOperations2(sender, ps);
                });

                builderSingle.Show();
            }
        }

        private void PerformOperations2(object sender, List<Polynomial> ps)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.Id == Resource.Id.buttonAdd)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], '+', ps[1], out res))
                    {
                        res = ps[0] + ps[1];
                        _historyTrie.insert(ps[0], '+', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Addition, res);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonSub)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], '-', ps[1], out res))
                    {
                        res = ps[0] - ps[1];
                        _historyTrie.insert(ps[0], '-', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Subtraction, res);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonDiv)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], '/', ps[1], out res))
                    {
                        res = ps[0] / ps[1];
                        _historyTrie.insert(ps[0], '/', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Division, res);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonMul)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], '*', ps[1], out res))
                    {
                        res = ps[0] * ps[1];
                        _historyTrie.insert(ps[0], '*', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Multiplication, res);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonMod)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], '%', ps[1], out res))
                    {
                        res = ps[0] % ps[1];
                        _historyTrie.insert(ps[0], '%', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Modulus, res);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonSlv)
                {
                    Solver s = new Solver(ps[0]);
                    System.Numerics.Complex[] roots = s.solve();
                    _historyTrie.insert(ps[0], 's', roots);
                    
                    ListElement elem = new ListElement(ps[0], roots, false);
                    ListPolyAdapter.Add(elem);
                }
                else if (btn.Id == Resource.Id.buttonGcd)
                {
                    Polynomial res;
                    if (!_historyTrie.try_search(ps[0], 'g', ps[1], out res))
                    {
                        res = Polynomial.__gcd(ps[0], ps[1]);
                        _historyTrie.insert(ps[0], 'g', ps[1], res);
                    }
                    ListElement elem = new ListElement(ps[0], ps[1], OperationTypeEnum.Gcd, res);
                    ListPolyAdapter.Add(elem);
                }
            }
            catch (Exception ex)
            {
                ListPolyAdapter.Add(ex.Message);
            }
            ListPolyAdapter.NotifyDataSetChanged();
        }

        private void addPolynomial(object sender, EventArgs e)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(this);
            promptView = layoutInflater.Inflate(Resource.Layout.PromptLayout, null);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
            alertDialogBuilder.SetView(promptView);
            
            EditText input = promptView.FindViewById<EditText>(Resource.Id.PolynomialUserInput);

            #region btnsE
            Button btn = promptView.FindViewById<Button>(Resource.Id.button1);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button2);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button3);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button4);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button5);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button6);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button7);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button8);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button9);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.button0);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.buttonP);
            
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.buttonA);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.buttonM);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.buttonD);
            btn.Click += Btn_Click;
            btn = promptView.FindViewById<Button>(Resource.Id.buttonX);
            btn.Click += Btn_Click;
            #endregion

            input.SetSingleLine(true);
            input.Focusable = false;

            alertDialogBuilder.SetCancelable(false)
                        .SetPositiveButton("Add", delegate {
                            polynomials.Add(Polynomial.Parse(input.Text));
                            ListElement elem = new ListElement(polynomials[polynomials.Count - 1]);
                            ListPolyAdapter.Add(elem);
                            ListPolyAdapter.NotifyDataSetChanged();
                        }).SetNegativeButton("Cancel", delegate {

                        });

            AlertDialog alertD = alertDialogBuilder.Create();
            alertD.Show();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            EditText input = promptView.FindViewById<EditText>(Resource.Id.PolynomialUserInput);
            
            if ((string)btn.Tag  == "tButtonPolyPrompt1")
                input.Text += "1";
            if ((string)btn.Tag == "tButtonPolyPrompt2")
                input.Text += "2";
            if ((string)btn.Tag == "tButtonPolyPrompt3")
                input.Text += "3";
            if ((string)btn.Tag == "tButtonPolyPrompt4")
                input.Text += "4";
            if ((string)btn.Tag == "tButtonPolyPrompt5")
                input.Text += "5";
            if ((string)btn.Tag == "tButtonPolyPrompt6")
                input.Text += "6";
            if ((string)btn.Tag == "tButtonPolyPrompt7")
                input.Text += "7";
            if ((string)btn.Tag == "tButtonPolyPrompt8")
                input.Text += "8";
            if ((string)btn.Tag == "tButtonPolyPrompt9")
                input.Text += "9";
            if ((string)btn.Tag == "tButtonPolyPrompt0")
                input.Text += "0";
            if ((string)btn.Tag == "tButtonPolyPromptA")
                input.Text += "+";
            if ((string)btn.Tag == "tButtonPolyPromptM")
                input.Text += "-";
            if ((string)btn.Tag == "tButtonPolyPromptP")
                input.Text += "^";
            if ((string)btn.Tag == "tButtonPolyPromptX")
                input.Text += "X";
            if ((string)btn.Tag == "tButtonPolyPromptD")
                if (input.Text.Length > 0)
                    input.Text = input.Text.Remove(input.Text.Length - 1);
        }
    }

    public enum OperationTypeEnum
    {
        NewPolynomial,
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulus,
        Gcd,
        Solve,
        PolynomialAccepted,
        OldMultiplication,
        OldModulus,
        OldDivision,
        OldAddition,
        OldSubtration,
        OldGcd,
        OldSolve
    }

    public class ListElement
    {
        Polynomial p1, p2;
        Polynomial result;
        Complex[] roots;
        OperationTypeEnum op;
        bool RootFinding;
        bool retrievedFromHistory;

        public ListElement(Polynomial P)
        {
            p1 = P;
            op = OperationTypeEnum.NewPolynomial;
        }

        public ListElement(Polynomial P, Complex[] Roots, bool retrieved)
        {
            p1 = P;
            roots = Roots;
            RootFinding = true;
            if (retrieved)
                op = OperationTypeEnum.OldSolve;
            else
                op = OperationTypeEnum.Solve;
        }

        public ListElement(Polynomial P1, Polynomial P2, OperationTypeEnum OP, Polynomial res)
        {
            p1 = P1;
            p2 = P2;
            op = OP;
            result = res;
            RootFinding = false;
            if (OP == OperationTypeEnum.OldAddition || OP == OperationTypeEnum.OldDivision || OP == OperationTypeEnum.OldGcd || OP == OperationTypeEnum.OldModulus || OP == OperationTypeEnum.OldMultiplication || OP == OperationTypeEnum.OldSolve || OP == OperationTypeEnum.OldSubtration)
                retrievedFromHistory = true;
        }

        public string ToString(bool variant)
        {
            if (op == OperationTypeEnum.NewPolynomial)
                return "Added Polynomial: " + p1.ToString();

            string ret = "";
            string endl = "\r\n";
            ret += p1.ToString() + endl;

            if (op == OperationTypeEnum.Addition || op == OperationTypeEnum.OldAddition)
                ret += "+" + endl;
            if (op == OperationTypeEnum.Subtraction || op == OperationTypeEnum.OldSubtration)
                ret += "-" + endl;
            if (op == OperationTypeEnum.Multiplication || op == OperationTypeEnum.OldMultiplication)
                ret += "*" + endl;
            if (op == OperationTypeEnum.Division || op == OperationTypeEnum.OldDivision)
                ret += "/" + endl;
            if (op == OperationTypeEnum.Modulus || op == OperationTypeEnum.OldModulus)
                ret += "%" + endl;
            if (op == OperationTypeEnum.Gcd || op == OperationTypeEnum.OldGcd)
                ret += "GCD" + endl;
            if (op == OperationTypeEnum.Solve || op == OperationTypeEnum.OldSolve)
            {
                ret += endl +  "Roots:" + endl;

                foreach (var item in roots)
                {
                    if (item.Imaginary == 0)
                        ret += item.Real.ToString() + "\r\n";
                    else
                    {
                        ret += item.Real.ToString() + " ";
                        if (item.Imaginary > 0)
                        {
                            ret += "+ " + item.Imaginary.ToString() + "i" + "\r\n";
                        }
                        else
                        {
                            ret += "- " + item.Imaginary.ToString().Substring(1);
                            ret += "i\r\n";
                        }
                    }
                }
            }
            else
            {
                ret += p2.ToString() + endl;
                ret += "_____________" + endl;
                ret += result.ToString();
            }

            return ret;
        }

        public override string ToString()
        {
            if (op == OperationTypeEnum.NewPolynomial)
                return "Added Polynomial: " + p1.ToString();

            if (RootFinding)
            {
                string resS = "Roots:\r\n";

                foreach (var item in roots)
                {
                    if (item.Imaginary == 0)
                        resS += item.Real.ToString() + "\r\n";
                    else
                    {
                        resS += item.Real.ToString() + " ";
                        if (item.Imaginary > 0)
                        {
                            resS += "+ " + item.Imaginary.ToString() + "i" + "\r\n";
                        }
                        else
                        {
                            resS += "- " + item.Imaginary.ToString().Substring(1);
                            resS += "i\r\n";
                        }
                    }
                }
                return resS;
            }

            return result.ToString();
        }
    }

}

