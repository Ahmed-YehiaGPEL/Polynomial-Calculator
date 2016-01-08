using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMath.PolynomialEquation;

namespace CalculatorUI
{

    public partial class HistoryLogViewForm : Form
    {
        #region OperationsClassification
        List<Char> twoPolynomials = new List<Char>{ '*', '+', '-', '/', '%', 'g' };
        List<Char> oneWithParameters = new List<Char> { 's', 'd' };
        List<Char> onePolynomial = new List<Char> { '^', 'r' };
        #endregion
        private TextBox rootsLog = new TextBox();
        public HistoryLogViewForm()
        {
            InitializeComponent();
        }
        public HistoryLogViewForm(HistoryLog _log)
        {
            InitializeComponent();
            ParsePolynomial(_log.firstPolynomial, polynomial1TextBox);
            if (twoPolynomials.Contains(_log.Operation))
            {
                ParsePolynomial(_log.secondPolynomial, polynomial2TextBox);
                ParsePolynomial(_log.resultPolynomial, resultPolynomialTextBox);
            }
            else if (onePolynomial.Contains(_log.Operation))
            {
                splitContainer2.Panel1Collapsed = true;
                if (_log.Operation == '=')
                {
                    showRoots(_log.firstPolynomial, _log.roots);
                }
                else
                {
                    ParsePolynomial(_log.resultPolynomial, resultPolynomialTextBox);
                }
            }
            else if (oneWithParameters.Contains(_log.Operation))
            {
                groupBox2.Text = "Parameters";
                showParameter(_log.parameters, polynomial2TextBox);
                ParsePolynomial(_log.resultPolynomial, resultPolynomialTextBox);
            }
            else
            {
                throw new ArgumentException("Operation is not supported");
            }
                
            this.Text = DateTime.Parse(_log._timeStamp).ToShortTimeString() + " ";
            switch (_log.Operation)
            {
                case '+':
                    this.Text += " Addition";
                    break;
                case '-':
                    this.Text += " Subtraction";
                    break;
                case '*':
                    this.Text += " Multiplication";
                    break;
                case '=':
                    this.Text += " Finding Roots";
                    break;
                case '/':
                    this.Text += " Division";
                    break;
                case '%':
                    this.Text += " Modulus";
                    break;
                case 'g':
                    this.Text += " GCD";
                    break;
                case 's':
                    this.Text += " Substitution";
                    break;
                case 'd':
                    this.Text += " Definite Integral";
                    break;
                case '^':
                    this.Text = " Derivative";
                    break;
            }
        }
        public void showRoots(Polynomial equation, List<Complex> roots)
        {
            foreach (var item in roots)
            {
                if(item.Imaginary == 0)
                    resultPolynomialTextBox.Text += item.Real.ToString() + "\r\n";
                else
                {
                    resultPolynomialTextBox.Text += item.Real.ToString() + " ";
                    if(item.Imaginary > 0)
                    {
                        resultPolynomialTextBox.Text += "+ "+ item.Imaginary.ToString() + "i" + "\r\n";
                    }
                    else
                    {
                        resultPolynomialTextBox.Text += "- " + item.Imaginary.ToString().Substring(1);
                        resultPolynomialTextBox.AppendText("i\r\n");
                    }
                }
            }
        }
        public void showParameter(List<KeyValuePair<Char, Complex>> parameters, RichTextBox _rtBox)
        {
            _rtBox.Text = "";
            foreach (var item in parameters)
            {
                _rtBox.Text += item.Key.ToString() + " = " + item.Value.ToString() + "\r\n";
            }
            if (_rtBox.Text.Length >= 2 && _rtBox.Text.Substring(_rtBox.Text.Length - 2) == "\r\n")
            {
                _rtBox.Text = _rtBox.Text.Substring(0, _rtBox.Text.Length - 2);
            }
        }
        private void ParsePolynomial(Polynomial _polynomial, RichTextBox _rtBox)
        {

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
            if (_polynomial.isnull())
            {
                _rtBox.Text = "0";
            }
        }
        private void HistoryLogViewForm_Load(object sender, EventArgs e)
        {
            LoadColorFont(polynomial1TextBox);
            LoadColorFont(polynomial2TextBox);
            LoadColorFont(resultPolynomialTextBox);
        }
        void LoadColorFont(RichTextBox _rbox)
        {
            for (int i = 0; i < _rbox.TextLength; i++)
            {
                _rbox.SelectionStart = i;
                _rbox.SelectionLength = 1;
                _rbox.SelectionFont = Properties.Settings.Default.Font;
                _rbox.SelectionColor = Properties.Settings.Default.Color;
            }
        }
    }
}
