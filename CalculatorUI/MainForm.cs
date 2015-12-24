using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMath.PolynomialEquation;
using CMath.PolynomialSolver;
using CMath.Trie;
using System.Numerics;
using System.Threading;

namespace CalculatorUI
{

    public enum OperationTypeEnum
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulus,
        SolveFirst,
        SolveSecond,
        Generate,
        OldMultiplication,
        OldModulus,
        OldDivision,
        OldAddition,
        OldSubtration,
        OldSolve
    }
    //TODO use rich text box instead of flowlayout panel    
    public partial class MainForm : Form
    {
        #region Internal Declrations
        internal Polynomial polynomial1, polynomial2, resultPolynomial;
        internal Solver _solverInstance;
        internal List<Complex> roots;
        internal PolynomialTrie _historyTrie;
        internal Thread loadThread;
        //If not found wil be created
        internal string filePath = Application.StartupPath + "\\appdata.xml";
        #endregion

        public MainForm()
        {
            InitializeComponent();
            loadThread = new Thread(LoadThread);
            loadThread.Start();
            //Initialize display,value members for later history viewing
            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "returnType";
            //Load colerd font properties
            LoadColorFont(polynomial1Text);
            LoadColorFont(polynomial2Text);
            LoadColorFont(resPolyText);

        }

        internal void LoadThread()
        {   
            try
            {
                
                _historyTrie = new PolynomialTrie(filePath);
                
            }
            catch
            {
                _historyTrie = new PolynomialTrie();
            }
        }
        //TODO Delete when parser finishes

        /// <summary>
        /// Display result polynomial to the user.
        /// </summary>
        /// <param name="_poly">Polynomial to show</param>
        
        public void ShowPolynomial(Polynomial _poly)
        {
            flowResultPoly.Controls.Clear();
            for (int i = _poly.Count - 1; i >= 0; i--)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)_poly[i].Degree, (decimal)_poly[i].Coefficient.Real, true, _poly[i].Degree == 0);
                flowResultPoly.Controls.Add(_ptc);
                Label l = new Label();
                l.Text = "+";
                l.TextAlign = ContentAlignment.MiddleCenter;

                flowResultPoly.Controls.Add(l);
            }
            flowResultPoly.Controls.RemoveAt(flowResultPoly.Controls.Count - 1);
        }

        /// <summary>
        /// Show roots of polynomial in the Log Panel
        /// </summary>
        public void ShowRoots()
        {
            foreach (var item in roots)
            {
                LogPanel.Text += "\r\n" + item.ToString();
            }
        }
        /// <summary>
        /// Logs an operation into the Log Panel
        /// </summary>
        /// <param name="_operation">Operation type to be logged</param>
        public void LogOperation(OperationTypeEnum _operation)
        {
            switch (_operation)
            {
                case OperationTypeEnum.Addition:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Added Polynomials.");
                    break;
                case OperationTypeEnum.Subtraction:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Subtracted Polynomials.");
                    break;
                case OperationTypeEnum.Multiplication:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Multiplied Polynomials.");
                    break;
                case OperationTypeEnum.Modulus:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Reminder Polynomial Calculated.");
                    break;
                case OperationTypeEnum.Division:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Divided Polynomials.");
                    break;
                case OperationTypeEnum.SolveFirst:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " First Polynomial Solved\r\nRoots:\n");
                    break;
                case OperationTypeEnum.SolveSecond:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Second Polynomial Solved\r\nRoots:\n");
                    break;
                case OperationTypeEnum.Generate:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Stored Polynomial.\r");
                    break;
                case OperationTypeEnum.OldDivision:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Division retrieved.");
                    break;
                case OperationTypeEnum.OldModulus:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Reminder Polynomials.");
                    break;
                case OperationTypeEnum.OldMultiplication:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Multiplication retrieved.\r");
                    break;
                case OperationTypeEnum.OldSubtration:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Subtraction retrieved.\r");
                    break;
                case OperationTypeEnum.OldAddition:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Addition retrieved.\r");
                    break;
                case OperationTypeEnum.OldSolve:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Polynomial root retrieved\r\nRoots:\n");
                    break;
            }
        }
        #region Solve
        void SolvePolynomial(Polynomial _poly, ref List<Complex> result)
        {
            _solverInstance = new Solver(_poly);
            roots = _solverInstance.solve().ToList();
        }
        #endregion
        #region History
        /// <summary>
        /// Adds current operation in a Trie instance to be saved for later history saving.
        /// </summary>
        /// <param name="_typeEnum"></param>
        public void LogInHistory(OperationTypeEnum _typeEnum)
        {
            HistoryLog hL;
            switch (_typeEnum)
            {
                case OperationTypeEnum.Addition:
                    _historyTrie.insert(polynomial1, '+', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '+', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Subtraction:
                    _historyTrie.insert(polynomial1, '-', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '-', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Multiplication:
                    _historyTrie.insert(polynomial1, '*', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '*', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Division:
                    _historyTrie.insert(polynomial1, '/', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '/', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.SolveFirst:
                    _historyTrie.insert(polynomial1, roots);
                    hL = new HistoryLog(polynomial1, roots, DateTime.Now.TimeOfDay.ToString());
                    LogItem(hL);
                    break;
                case OperationTypeEnum.SolveSecond:
                    _historyTrie.insert(polynomial2, roots);
                    hL = new HistoryLog(polynomial2, roots, DateTime.Now.TimeOfDay.ToString());
                    LogItem(hL);
                    break;
            }
        }
        /// <summary>
        /// Adds item to HistoryBox
        /// </summary>
        /// <param name="_log"></param>
        void LogItem(HistoryLog _log)
        {
            switch (_log.Operation)
            {
                case '+':
                    _log.DisplayName += " Addition";
                    break;
                case '-':
                    _log.DisplayName += " Subtraction";
                    break;
                case '*':
                    _log.DisplayName += " Multiplication";
                    break;
                case '/':
                    _log.DisplayName += " Division";
                    break;
                case '%':
                    _log.DisplayName += " Modulus";
                    break;
                case '=':
                    _log.DisplayName += " Root finding";
                    break;
            }
            listBox1.Items.Add(_log);
        }
        #endregion
        /// <summary>
        /// Performs the requested operation from the pressed button
        /// </summary>
        /// <!--Casts the sender as GlassButton then switch over the Tag property then execute operation-->
        private void PerformOperation(object sender, EventArgs e)
        {
            
            Polynomial searchResult;
            //try
            //{
            switch ((sender as Glass.GlassButton).Tag as string)
            {
                case "Add":
                    if (_historyTrie.try_search(polynomial1, '+', polynomial2, out searchResult))
                    {
                        PolynomialParse(searchResult, resPolyText, true);
                        LogOperation(OperationTypeEnum.Addition);
                    }
                    else
                    {
                        resultPolynomial = polynomial1 + polynomial2;
                        PolynomialParse(resultPolynomial, resPolyText, true);
                        LogInHistory(OperationTypeEnum.Addition);
                        LogOperation(OperationTypeEnum.Addition);
                    }
                    break;
                case "Subtract":
                    if (_historyTrie.try_search(polynomial1, '-', polynomial2, out searchResult))
                    {
                        PolynomialParse(searchResult, resPolyText, true);

                        LogOperation(OperationTypeEnum.OldSubtration);
                    }
                    else
                    {
                        resultPolynomial = polynomial1 - polynomial2;
                        PolynomialParse(resultPolynomial, resPolyText, true);
                        LogInHistory(OperationTypeEnum.Subtraction);
                        LogOperation(OperationTypeEnum.Subtraction);
                    }
                    break;
                case "Multiply":
                    if (_historyTrie.try_search(polynomial1, '*', polynomial2, out searchResult))
                    {
                        PolynomialParse(searchResult, resPolyText, true);
                        LogOperation(OperationTypeEnum.OldMultiplication);
                    }
                    else
                    {
                        resultPolynomial = polynomial1 * polynomial2;
                        PolynomialParse(resultPolynomial, resPolyText, true);
                        LogInHistory(OperationTypeEnum.Multiplication);
                        LogOperation(OperationTypeEnum.Multiplication);
                    }
                    break;
                case "Division":
                    if (_historyTrie.try_search(polynomial1, '/', polynomial2, out searchResult))
                    {
                        PolynomialParse(searchResult, resPolyText, true);
                        LogOperation(OperationTypeEnum.OldDivision);
                    }
                    else
                    {
                        resultPolynomial = polynomial1 / polynomial2;
                        PolynomialParse(resultPolynomial, resPolyText, true);
                        LogInHistory(OperationTypeEnum.Division);
                        LogOperation(OperationTypeEnum.Division);
                    }
                    break;
                case "Modulus":
                    if (_historyTrie.try_search(polynomial1, '%', polynomial2, out searchResult))
                    {
                        PolynomialParse(searchResult, resPolyText, true);
                        LogOperation(OperationTypeEnum.OldDivision);
                    }
                    else
                    {
                        resultPolynomial = polynomial1 % polynomial2;
                        PolynomialParse(resultPolynomial, resPolyText, true);
                        LogInHistory(OperationTypeEnum.Division);
                        LogOperation(OperationTypeEnum.Division);
                    }
                    break;
                case "Find X1":
                    if (_historyTrie.try_search(polynomial1, out roots))
                    {
                        LogOperation(OperationTypeEnum.OldSolve);
                        ShowRoots();
                    }
                    else
                    {
                        SolvePolynomial(polynomial1, ref roots);
                        LogInHistory(OperationTypeEnum.SolveFirst);
                        LogOperation(OperationTypeEnum.SolveFirst);
                    }
                    break;
                case "Find X2":
                    if (_historyTrie.try_search(polynomial2, out roots))
                    {
                        LogOperation(OperationTypeEnum.OldSolve);
                    }
                    else
                    {
                        SolvePolynomial(polynomial1, ref roots);
                        LogInHistory(OperationTypeEnum.SolveSecond);
                        LogOperation(OperationTypeEnum.SolveSecond);
                        ShowRoots();

                    }
                    break;
            }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
     //TODO To be deleted after using RichTextBoxes
        /// <summary>
        /// Creates a Polynomial from terms control collection
        /// <see cref="PolynomialTerm.cs"/> for information about input control.
        /// </summary>
        /// <param name="PolynomialTerms">The control collection to get Terms from</param>
        /// <returns></returns>
        internal Polynomial GetPolynomial(Control.ControlCollection PolynomialTerms)
        {
            SortedList<int, Complex> _polynomialTerms = new SortedList<int, Complex>();
            foreach (var item in PolynomialTerms)
            {   
                var ct = item as PolynomialTermControl;
                Complex n = new Complex((double)ct.Coefficient, 0.0);
                _polynomialTerms.Add((int)ct.Degree, n);
            }
            return new Polynomial(_polynomialTerms);
        }
      //TODO Delete when parser finished
        /// <summary>
        /// Generates terms upon number
        /// </summary>
        /// <param name="termNumber">number of terms to generate</param>
        /// <param name="polyNumber">Polynomial 1 or 2</param>
        void GeneratePolynomialTerms(int termNumber, byte polyNumber)
        {
            for (int i = 0; i < termNumber; i++)
            {
                PolynomialTermControl pTerm = new PolynomialTermControl();
                if (polyNumber == 1)
                {
                    pTerm.Name = "pTerm01-" + i.ToString();
                    flowPolynomial1.Controls.Add(pTerm);
                }
                else
                {
                    pTerm.Name = "pTerm02-" + i.ToString();
                    flowPolynomial2.Controls.Add(pTerm);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!loadThread.IsAlive)
            {
                toolStripStatusLabel2.Text = "Loaded history";
            }
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", " Exit ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogPanel.AppendText("Log started " + DateTime.Now.ToShortTimeString());
        }


        public void setClose(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            LoadColorFont(polynomial1Text);
            LoadColorFont(polynomial2Text);
            LoadColorFont(resPolyText);

        }
        /// <summary>
        /// Shows a form and disable the owner form till user closes the on top form
        /// </summary>
        /// <param name="frm">Form to show</param>
        /// <param name="owner">Form to be disabled</param>
        /// <param name="closeHandle">Handler of enable/disable</param>
        private void showForm(Form frm, Form owner, FormClosedEventHandler closeHandle)
        {
            frm.Owner = owner;
            frm.Show();
            frm.Activate();
            owner.Enabled = false;
            frm.FormClosed += new FormClosedEventHandler(closeHandle);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _historyTrie.save(filePath);
        }
        // Load history logs
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            HistoryLogViewForm hForm = new HistoryLogViewForm(listBox1.SelectedItem as HistoryLog);
            showForm(hForm, this, setClose);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _historyTrie.save(filePath);
        }

        //TODO Modify after parser finishesbt
        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all past operations ?\n this action cannot be reverse", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                System.IO.File.Delete(filePath);
                _historyTrie.Dispose();
                listBox1.Items.Clear();
                LogPanel.Text = "Log started " + DateTime.Now.ToShortTimeString();
                flowResultPoly.Controls.Clear();
                flowPolynomial1.Controls.Clear();
                flowPolynomial2.Controls.Clear();
            }

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Credits(), this, setClose);
        }

       private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
       {
           showForm(new CustomizeForm(), this, setClose);
       }
        /// <summary>
        /// Parse polynomial from rich text box
        /// </summary>
        /// <param name="_rtBox">RichTextBox that contains the data</param>
        /// <returns></returns>
       internal Polynomial PolynomialParse(RichTextBox _rtBox)
       {
           //string _deg = "", _coeff = "";
           SortedList<int, Complex> sList = new SortedList<int, Complex>();

            string expr = _rtBox.Text;
            int delay = 0;

            for (int i = 0; i < _rtBox.TextLength; i++)
            {
                _rtBox.SelectionStart = i;
                _rtBox.SelectionLength = 1;
                if (_rtBox.SelectionCharOffset > 0)
                    expr = expr.Insert(i + (delay++), "^");
            }

            string[] terms =expr.Replace("-", "+-").Split('+');

            foreach (string s in terms)
            {
                if (s.Contains('x') || s.Contains('X'))
                {
                    if (s.Contains('^'))
                    {
                        string[] cofpow = s.Split(new string[] { "x^", "X^" }, StringSplitOptions.RemoveEmptyEntries);
                        sList.Add(int.Parse(cofpow[1]), new Complex(double.Parse(cofpow[0]), 0));
                    }
                    else
                    {
                        string ts = s.Replace("X", "");
                        ts = ts.Replace("x", "");
                        if (ts == "")
                            ts = "1";
                        sList.Add(1, new Complex(double.Parse(ts), 0));
                    }
                }
                else
                    sList.Add(0, new Complex(double.Parse(s), 0));
            }

            //for (int i = 0; i < _rtBox.TextLength; i++)
            //{
            //    _rtBox.SelectionStart = i;
            //    _rtBox.SelectionLength = 1;
            //    if (_rtBox.SelectionCharOffset > 0)
            //    {
            //        _deg += _rtBox.SelectedText;
            //    }
            //    else
            //    {
            //        if ((_rtBox.SelectedText == "X" || _rtBox.SelectedText == "x"))
            //        {
            //            continue;
            //        }
            //        else if (_rtBox.SelectedText != "+" && _rtBox.SelectedText != "-")
            //        {
            //            _coeff += _rtBox.SelectedText;
            //        }
            //        else
            //        {
            //            if (_deg == "")
            //                _deg = "1"; 
            //            sList.Add(int.Parse(_deg), new System.Numerics.Complex(double.Parse(_coeff), 0));
            //            _deg = "";
            //            _coeff = "";
            //        }
            //    }
            //}
            //if (_deg == "")
            //    _deg = "0";
            //sList.Add(int.Parse(_deg), new System.Numerics.Complex(double.Parse(_coeff), 0));

            return new Polynomial(sList);
       }
        /// <summary>
        /// Parse polynomial to RichTextBox with superscript and base considration
        /// </summary>
        /// <param name="_polynomial">Polynomial to be parsed</param>
        /// <param name="_rtBox">RichTextBox to parse to</param>
        internal void PolynomialParse(Polynomial _polynomial, RichTextBox _rtBox, bool isResult)
        {
            if (isResult)
            {
                _rtBox.Text = "";
            }
            for (int i = _polynomial.Count - 1; i >= 0; i--)
            {
                if (_polynomial[i].Degree == 0)
                {
                    _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                    if (i != 0)
                    {
                        if (_polynomial[i - 1].Coefficient.Real > 0)
                            _rtBox.AppendText("+");
                    }
                }
                else
                {
                    if (_polynomial[i].Coefficient.Real != 1 || _polynomial[i].Coefficient.Imaginary != 0)
                        _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                    _rtBox.AppendText("X");
                    _rtBox.SelectionCharOffset = 7;
                    if (_polynomial[i].Degree > 1)
                        _rtBox.AppendText(_polynomial[i].Degree.ToString());
                    _rtBox.SelectionCharOffset = 0;
                    if (i != 0)
                    {
                        if (_polynomial[i - 1].Coefficient.Real > 0)
                            _rtBox.AppendText("+");
                    }
                }
            }
            if (isResult)
            {
                LoadColorFont(_rtBox);
            }
        }
       internal void LoadColorFont(RichTextBox _rbox)
       {
           for (int i = 0; i < _rbox.TextLength; i++)
           {
               _rbox.SelectionStart = i;
               _rbox.SelectionLength = 1;
               _rbox.SelectionFont = Properties.Settings.Default.Font;
               _rbox.SelectionColor = Properties.Settings.Default.Color;
           }
       }

        /// <summary>
        /// Enables superscript writing for power
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void SuperScriptOnX(object sender, EventArgs e)
       {
           RichTextBox rtbox = sender as RichTextBox;
            if (rtbox.TextLength != 0)
            {
                char lastChar = rtbox.Text.Last();
                if (lastChar == 'X' || lastChar == 'x')
                {
                    rtbox.SelectionCharOffset = 7;
                }
            }
       }

        private void BtnDiv_Click(object sender, EventArgs e)
        {

        }

        private void BaseOnEnter(object sender, KeyPressEventArgs e)
       {
           try
           {
               RichTextBox rtBox = sender as RichTextBox;
               if (e.KeyChar == (char)Keys.Enter)
               {
                   if (rtBox.SelectionCharOffset > 0)
                   {
                       rtBox.SelectionCharOffset = 0;
                   }
                   else
                   {
                       if ((rtBox.Tag as string) == "Poly1")
                           polynomial1 = PolynomialParse(rtBox);
                       else if ((rtBox.Tag as string) == "Poly2")
                           polynomial2 = PolynomialParse(rtBox);

                       LogOperation(OperationTypeEnum.Generate);
                   }
               }
           }
           catch (Exception ex)
          {
               MessageBox.Show(ex.Message);
           }
       }
       private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {

       }
       
    }
    public class HistoryLog
    {
        public Polynomial firstPolynomial, secondPolynomial, resultPolynomial;
        public List<Complex> roots;
        public char Operation { get; private set; }
        public string _timeStamp { get; private set; }
        public string DisplayName { get; set; }
        public HistoryLog returnType { get { return this; } }
        public HistoryLog(Polynomial polynomial1, Polynomial polynomial2, char operation, string timeStamp, Polynomial res)
        {
            this.firstPolynomial = polynomial1;
            this.secondPolynomial = polynomial2;
            this.resultPolynomial = res;
            this.Operation = operation;
            this._timeStamp = timeStamp;
            DisplayName = DateTime.Parse(_timeStamp).ToShortTimeString();
        }
        public HistoryLog(Polynomial polynomial1, List<Complex> roots, string timeStamp)
        {
            this.firstPolynomial = polynomial1;
            this.Operation = '=';
            this.roots = roots;
            this._timeStamp = timeStamp;
            DisplayName = DateTime.Parse(_timeStamp).ToShortTimeString();
        }
    }

}
