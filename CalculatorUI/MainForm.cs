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

    /// <summary>
    /// Enum that holds the operation to be stored / processed
    /// </summary>
    /// <!--Whatever opeation to be added later should be added here along with another old-like version of it ex:-->
    /// <!--GCD , OldGCD -->
    public enum OperationTypeEnum
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulus,
        Gcd,
        SolveFirst,
        SolveSecond,
        PolynomialAccepted,
        OldMultiplication,
        OldModulus,
        OldDivision,
        OldAddition,
        OldSubtration,
        OldGcd,
        OldSolve
    }
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
            historyListBox.DisplayMember = "DisplayName";
            historyListBox.ValueMember = "returnType";
            //Load colerd font properties
            LoadColorFont(polynomial1Text);
            LoadColorFont(polynomial2Text);
            LoadColorFont(resPolyText);
            

        }
        /// <summary>
        /// Load thread
        /// </summary>
        /// <!--Put whatever takes load in memory here-->
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
       
        /// <summary>
        /// Show roots of polynomial in the roots log panel
        /// </summary>
        public void ShowRoots()
        {
            rootsTextBox.Clear();
            rootsTextBox.Text += "Polynomial roots:\r\n";
            foreach (var item in roots)
            {
                if (item.Imaginary == 0)
                    rootsTextBox.Text += item.Real.ToString() + "\r\n";
                else
                {
                    rootsTextBox.Text += item.Real.ToString() + " ";
                    if (item.Imaginary > 0)
                    {
                        rootsTextBox.Text += "+ " + item.Imaginary.ToString() + "i" + "\r\n";
                    }
                    else
                    {
                        rootsTextBox.Text += "- " + item.Imaginary.ToString().Substring(1);
                        rootsTextBox.AppendText("i\r\n");
                    }
                }
            }
        }

        #region Solve
        void SolvePolynomial(Polynomial _poly, ref List<Complex> result)
        {
            try
            {
                _solverInstance = new Solver(_poly);
                roots = _solverInstance.solve().ToList();
            }
            catch (ArgumentException e)
            {
                roots = new List<Complex>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region History
        /// <summary>
        /// Logs an operation into the Log Panel and History
        /// </summary>
        /// <param name="_operation">Operation type to be logged</param>
        public void LogOperation(OperationTypeEnum _operation)
        {
            HistoryLog hL;

            switch (_operation)
            {
                case OperationTypeEnum.Addition:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Added Polynomials.\r");
                    _historyTrie.insert(polynomial1, '+', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '+', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Subtraction:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Subtracted Polynomials.");
                    _historyTrie.insert(polynomial1, '-', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '-', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Multiplication:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Multiplied Polynomials.\r");
                    _historyTrie.insert(polynomial1, '*', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '*', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Modulus:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Reminder Polynomial Calculated.\r");
                    _historyTrie.insert(polynomial1, '%', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '%', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Division:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Divided Polynomials.\r");
                    _historyTrie.insert(polynomial1, '/', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '/', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
				case OperationTypeEnum.Gcd:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Greatest Common Divisor Polynomial computed.\r");
                    _historyTrie.insert(polynomial1, 'g', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, 'g', DateTime.Now.TimeOfDay.ToString(), resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.SolveFirst:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " First Polynomial Solved.\r");
                    _historyTrie.insert(polynomial1, '=', roots);
                    hL = new HistoryLog(polynomial1, roots, DateTime.Now.TimeOfDay.ToString());
                    LogItem(hL);
                    break;
                case OperationTypeEnum.SolveSecond:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Second Polynomial Solved.\r");
                    _historyTrie.insert(polynomial2, '=', roots);
                    hL = new HistoryLog(polynomial2, roots, DateTime.Now.TimeOfDay.ToString());
                    LogItem(hL);
                    break;
                case OperationTypeEnum.OldDivision:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Division retrieved.\r");
                    break;
                case OperationTypeEnum.OldModulus:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Reminder Polynomials.\r");
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
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Polynomial root retrieved\r");
                    break;
                case OperationTypeEnum.PolynomialAccepted:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Polynomial entered\r");
                    break;
                default:
                    return;
            }
        }
        /// <summary>
        /// Adds item to HistoryBox
        /// </summary>
        /// <param name="_log">History Log to insert</param>
        internal void LogItem(HistoryLog _log)
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
                case 'g':
                    _log.DisplayName += " GCD";
                    break;
            }
            historyListBox.Items.Add(_log);
        }
        #endregion
        /// <summary>
        /// Performs the requested operation from the pressed button
        /// </summary>
        /// <!--Casts the sender as GlassButton then switch over the Tag property then execute operation-->
        private void PerformOperation(object sender, EventArgs e)
        {

            Polynomial searchResult;
            object RootResult;
            try
            {
                switch ((sender as Glass.GlassButton).Tag as string)
                {
                    case "Add":
                        if (_historyTrie.try_search(polynomial1, '+', polynomial2, out searchResult))
                        {
                            PolynomialParse(searchResult, resPolyText, true);
                            LogOperation(OperationTypeEnum.OldAddition);
                        }
                        else
                        {
                            resultPolynomial = polynomial1 + polynomial2;
                            PolynomialParse(resultPolynomial, resPolyText, true);
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
                            LogOperation(OperationTypeEnum.Division);
                        }
                        break;
                    case "Modulus":
                        if (_historyTrie.try_search(polynomial1, '%', polynomial2, out searchResult))
                        {
                            PolynomialParse(searchResult, resPolyText, true);
                            LogOperation(OperationTypeEnum.OldModulus);
                        }
                        else
                        {
                            resultPolynomial = polynomial1 % polynomial2;
                            PolynomialParse(resultPolynomial, resPolyText, true);
                            LogOperation(OperationTypeEnum.Modulus);
                        }
                        break;
                    case "GCD":
                        if (_historyTrie.try_search(polynomial1, 'g', polynomial2, out searchResult))
                        {
                            PolynomialParse(searchResult, resPolyText, true);
                            LogOperation(OperationTypeEnum.OldGcd);
                        }
                        else
                        {
                            resultPolynomial = Polynomial.__gcd(polynomial1, polynomial2);
                            PolynomialParse(resultPolynomial, resPolyText, true);
                            LogOperation(OperationTypeEnum.Gcd);
                        }
                        break;
                    case "Find X1":
                        if (_historyTrie.try_search(polynomial1, '=', out RootResult))
                        {
                            roots = (List<Complex>)RootResult;
                            LogOperation(OperationTypeEnum.OldSolve);
                        }
                        else
                        {
                            SolvePolynomial(polynomial1, ref roots);
                            LogOperation(OperationTypeEnum.SolveFirst);
                        }
                        ShowRoots();
                        break;
                    case "Find X2":
                        if (_historyTrie.try_search(polynomial2, '=', out RootResult))
                        {
                            roots = (List<Complex>)RootResult;
                            LogOperation(OperationTypeEnum.OldSolve);
                        }
                        else
                        {
                            SolvePolynomial(polynomial2, ref roots);
                            LogOperation(OperationTypeEnum.SolveSecond);

                        }
                        ShowRoots();
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                _historyTrie.save(filePath);

                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogPanel.AppendText("Log started " + DateTime.Now.ToShortTimeString());
        }

        /// <summary>
        /// Close handler of the form, applies settings on close and renables the owner form
        /// </summary>
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
            MessageBox.Show("Log saved");
        }
        // Load history logs
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HistoryLogViewForm hForm = new HistoryLogViewForm(historyListBox.SelectedItem as HistoryLog);
            showForm(hForm, this, setClose);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", " Exit ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _historyTrie.save(filePath);
            }
            else
            {
                e.Cancel = true;
            }
        }

       /// <summary>
       /// Clears items stored in log, disposes history trie and deletes history log file
       /// reinitiates the log panel, polynomials input text boxes,roots log and history log
       /// reinitiate the colored font settings.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all past operations ?\n this action cannot be reverse", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                System.IO.File.Delete(filePath);
                _historyTrie.Dispose();
                historyListBox.Items.Clear();
                LogPanel.Text = "Log started " + DateTime.Now.ToShortTimeString();
                polynomial1Text.Text = "First Polynomial";
                polynomial2Text.Text = "Second Polynomial";
                resPolyText.Text = "Result";
                rootsTextBox.Clear();
                LoadColorFont(polynomial1Text);
                LoadColorFont(polynomial2Text);
                LoadColorFont(resPolyText);
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
       #region RTF Handling

       #region Parsing Algorithms
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

            expr = expr.Replace("-X", "-1X");
            expr = expr.Replace("-x", "-1x");
            expr = expr.Replace("+X", "+1X");
            expr = expr.Replace("+x", "+1x");

            if (expr.StartsWith("X",true,System.Globalization.CultureInfo.CurrentCulture))
                expr = "1" + expr;

            string[] terms =expr.Replace("-", "+-").Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in terms)
            {
                if (s.Contains('x') || s.Contains('X'))
                {
                    if (s.Contains('^'))
                    {
                        string[] cofpow = s.Split(new string[] { "x^", "X^" }, StringSplitOptions.RemoveEmptyEntries);
                        sList.Add(int.Parse(cofpow[1]), new Complex(double.Parse(cofpow[0]), 0)); // N Coeff
                    }
                    else
                    {
                        string ts = s.Replace("X", "");
                        ts = ts.Replace("x", "");
                        if (ts == "")
                            ts = "1";
                        sList.Add(1, new Complex(double.Parse(ts), 0)); //Coeff 1 
                    }
                }
                else
                    sList.Add(0, new Complex(double.Parse(s), 0)); //Free term
            }

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

       #endregion
        /// <summary>
        /// Loads color and font settings to polylnomials text boxes
        /// </summary>
        /// <param name="_rbox"></param>
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
        /// <summary>
        /// Switch to base and parse polynomial on pressing enter
        /// </summary>
        /// <param name="sender">Control sender</param>
        /// <param name="e">KeyPress Param</param>
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

                       LogOperation(OperationTypeEnum.PolynomialAccepted);
                   }
               }
           }
           catch (Exception ex)
          {
               MessageBox.Show(ex.Message);
           }
       }

       #endregion

    }
    /// <summary>
    /// Class that holds the history item, each instance holds one record of operation and two polynomials
    /// The record can hold one operation and its roots.
    /// </summary>
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
