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
        Solve,
        Generate,
        OldMultiplication,
        OldAddition,
        OldSubtration
    }

    public partial class MainForm : Form
    {
        internal Polynomial polynomial1, polynomial2, resultPolynomial;
        internal Solver _solverInstance;
        internal PolynomialTrie _historyTrie;
        string filePath = Application.StartupPath + "\\appdata.xml";
        
        public MainForm()
        {
    
            InitializeComponent();

            Thread loadThread = new Thread(LoadThread);
            
            loadThread.Start();

            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "returnType";
        }
        void LoadThread()
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
        /// Shows the result polynomial to the user.
        /// </summary>
        /// <param name="_poly">Polynomial to show</param>
        public void ShowPolynomial(Polynomial _poly)
        {
            flowResultPoly.Controls.Clear();
            for (int i = _poly.Count-1; i >= 0; i--)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)_poly[i].Degree,(decimal)_poly[i].Coefficient.Real,true,_poly[i].Degree==0);
                flowResultPoly.Controls.Add(_ptc);
                Label l = new Label();
                l.Text = "+";
                l.TextAlign = ContentAlignment.MiddleCenter;
                
                flowResultPoly.Controls.Add(l);
            }
            flowResultPoly.Controls.RemoveAt(flowResultPoly.Controls.Count - 1);
        }
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
                case OperationTypeEnum.Solve:
                    LogPanel.Text += ("\r\n" + DateTime.Now.ToShortTimeString() + " Polynomials Solved\nRoots:\n");
                    //ShowRoots
                    break;
                case OperationTypeEnum.Generate:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Generated terms.\r");
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
             }
        }
        #region Solve
        void SolvePolynomial(Polynomial _poly)
        {
            _solverInstance = new Solver(_poly);
            Complex[] _roots = _solverInstance.solve();
            foreach (var item in _roots)
            {
                LogPanel.Text += "\r\n" + item.ToString();
            }
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
                    hL = new HistoryLog(polynomial1, polynomial2, '*', DateTime.Now.TimeOfDay.ToString(),resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Subtraction:
                    _historyTrie.insert(polynomial1, '-', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '*', DateTime.Now.TimeOfDay.ToString(),resultPolynomial);
                    LogItem(hL);
                    break;
                case OperationTypeEnum.Multiplication:
                    _historyTrie.insert(polynomial1, '*', polynomial2, resultPolynomial);
                    hL = new HistoryLog(polynomial1, polynomial2, '*', DateTime.Now.TimeOfDay.ToString(),resultPolynomial);
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
            } 
            listBox1.Items.Add(_log);
        }
        #endregion
        private void PerformOperation(object sender, EventArgs e)
        {
            Polynomial searchResult;
            try
            {
                switch ((sender as Glass.GlassButton).Tag as string)
                {
                        
                    case "Add":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        if (_historyTrie.try_search(polynomial1, '+', polynomial2, out searchResult))
                        {
                            ShowPolynomial(searchResult);
                            LogOperation(OperationTypeEnum.Addition);
                        }
                        else
                        {
                            resultPolynomial = polynomial1 + polynomial2;
                            ShowPolynomial(resultPolynomial);

                            LogInHistory(OperationTypeEnum.Addition);

                            LogOperation(OperationTypeEnum.Addition);
                        }
                        break;  
                    case "Subtract":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        if (_historyTrie.try_search(polynomial1, '-', polynomial2, out searchResult))
                        {
                            ShowPolynomial(searchResult);
                            LogOperation(OperationTypeEnum.OldSubtration);

                        }
                        else
                        {

                            resultPolynomial = polynomial1 - polynomial2;
                            ShowPolynomial(resultPolynomial);

                            LogInHistory(OperationTypeEnum.Subtraction);

                            LogOperation(OperationTypeEnum.Subtraction);
                        }
                        break;
                    case "Multiply":
                       polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                       polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                       if (_historyTrie.try_search(polynomial1, '*', polynomial2, out searchResult))
                       {
                           ShowPolynomial(searchResult);
                           LogOperation(OperationTypeEnum.OldMultiplication);

                       }
                       else
                       {
                           resultPolynomial = polynomial1 * polynomial2;

                           ShowPolynomial(resultPolynomial);

                           LogInHistory(OperationTypeEnum.Multiplication);

                           LogOperation(OperationTypeEnum.Multiplication);
                       }
                        break;
                    case "Find X1":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        LogOperation(OperationTypeEnum.Solve);
                        SolvePolynomial(polynomial1);
                        break;
                    case "Find X2":
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        LogOperation(OperationTypeEnum.Solve);
                        SolvePolynomial(polynomial2);
                        break;  
                    case "Poly1":
                        GeneratePolynomialTerms((int)p1Count.Value,1);
                        LogOperation(OperationTypeEnum.Generate);
                        break;
                    case "Poly2":
                        GeneratePolynomialTerms((int)p2Count.Value, 2);
                        LogOperation(OperationTypeEnum.Generate);
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        Polynomial GetPolynomial(Control.ControlCollection PolynomialTerms)
        {
        
            SortedList<int, Complex> _polynomialTerms = new SortedList<int, Complex>();
            
            foreach (var item in PolynomialTerms )
            {
                var ct = item as PolynomialTermControl;
                Complex n = new Complex((double)ct.Coefficient, 0.0);
                _polynomialTerms.Add((int)ct.Degree, n);
            }
            return new Polynomial(_polynomialTerms);
        }
        void GeneratePolynomialTerms(int termNumber,byte polyNumber)
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
            toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", " Exit ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void polynomialTerm8_Load(object sender, EventArgs e)
        {

        }

        private void flowPolynomial1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogPanel.AppendText("Log started " + DateTime.Now.ToShortTimeString());
        }

        
        public void setClose(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }
        private void showForm(Form frm, Form owner, FormClosedEventHandler closeHandle)
        {
            frm.Owner = owner;
            frm.Show();
            frm.Activate();
            owner.Enabled = false;
            frm.FormClosed += new FormClosedEventHandler(closeHandle);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _historyTrie.save(filePath);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            HistoryLogViewForm hForm = new HistoryLogViewForm(listBox1.SelectedItem as HistoryLog);
            showForm(hForm, this, setClose);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _historyTrie.save(filePath);
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all past operations ?\n this action cannot be reverse","Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
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
            showForm(new credits(), this, setClose);
        }
        
    }
    public class HistoryLog
    {
        public Polynomial firstPolynomial, secondPolynomial, resultPolynomial;
        public char Operation { get; private set; }
        public string _timeStamp{  get;private set;}
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
    }

}
