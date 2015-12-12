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

namespace CalculatorUI
{

    public enum OperationTypeEnum
    {
        Addition,
        Subtraction,
        Multiplication,
        Solve,
        Generate
    }
    public partial class MainForm : Form
    {
        internal Polynomial polynomial1, polynomial2, resultPolynomial;
        internal Solver _solverInstance;
        public MainForm()
        {
            InitializeComponent();
        }
        public void ShowPolynomial(Polynomial _poly)
        {
            foreach (var item in _poly)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)item.Degree,(decimal)item.Coefficient.Real);
                flowResultPoly.Controls.Add(_ptc);
            }
        }
        public void LogOperation(OperationTypeEnum _operation)
        {
            switch (_operation)
            {
                case OperationTypeEnum.Addition:
                    LogPanel.Text += ("\n" + DateTime.Now.ToShortTimeString() + " Added Polynomials.");
                    break;
                case OperationTypeEnum.Subtraction:
                    LogPanel.Text += ("\n" + DateTime.Now.ToShortTimeString() + " Subtracted Polynomials.");
                    break;
                case OperationTypeEnum.Multiplication:
                    LogPanel.Text += ("\n" + DateTime.Now.ToShortTimeString() + " Multiplied Polynomials.");
                    break;
                case OperationTypeEnum.Solve:
                    LogPanel.Text += ("\n" + DateTime.Now.ToShortTimeString() + " Polynomials Solved\nRoots:\n");
                    //ShowRoots
                    break;
                case OperationTypeEnum.Generate:
                    LogPanel.AppendText("\r\n" + DateTime.Now.ToShortTimeString() + " Generated terms.");
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
                LogPanel.Text += "\n" + item.ToString();
            }
        }
        #endregion
        private void PerformOperation(object sender, EventArgs e)
        {
            try
            {
                switch ((sender as Glass.GlassButton).Tag as string)
                {
                        
                    case "Add":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        resultPolynomial = polynomial1 + polynomial2;
                        ShowPolynomial(resultPolynomial);
                        LogOperation(OperationTypeEnum.Addition);
                        break;  
                    case "Subtract":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        resultPolynomial = polynomial1 - polynomial2;
                        ShowPolynomial(resultPolynomial);
                        LogOperation(OperationTypeEnum.Subtraction);
                        break;
                    case "Multiply":
                       polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                       polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                       resultPolynomial = polynomial1 * polynomial2;
                       ShowPolynomial(resultPolynomial);
                       LogOperation(OperationTypeEnum.Multiplication);
                        break;
                    case "Find X1":
                        polynomial1 = GetPolynomial(flowPolynomial1.Controls);
                        SolvePolynomial(polynomial1);
                        LogOperation(OperationTypeEnum.Solve);
                        break;
                    case "Find X2":
                        polynomial2 = GetPolynomial(flowPolynomial2.Controls);
                        SolvePolynomial(polynomial2);
                        LogOperation(OperationTypeEnum.Solve);
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
            //this.Refresh() ;//

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
    }
}
