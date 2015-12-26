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
        private TextBox rootsLog = new TextBox();
        public HistoryLogViewForm()
        {
            InitializeComponent();
        }
        public HistoryLogViewForm(HistoryLog _log)
        {
            InitializeComponent();
            if (_log.Operation != '=')
            {
                ParsePolynomial(_log.firstPolynomial, polynomial1TextBox);
                ParsePolynomial(_log.secondPolynomial, polynomial2TextBox);
                ParsePolynomial(_log.resultPolynomial, resultPolynomialTextBox);
            }
            else
            {
                showRoots(_log.firstPolynomial, _log.roots);
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
                case 'g':
                    this.Text += " GCD";
                    break;
            }
        }
        public void showRoots(Polynomial equation, List<Complex> roots)
        {
            ParsePolynomial(equation, polynomial1TextBox);
            splitContainer2.Panel1Collapsed = true;
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
        private void ParsePolynomial(Polynomial _polynomial, RichTextBox _rtBox)
        {

            if (_polynomial.isnull())
            {
                _rtBox.Text = "0";
            }
            else
            {
                for (int i = _polynomial.Count - 1; i >= 0; i--)
                {
                    if (_polynomial[i].Coefficient.Real < 0)
                    {
                        _rtBox.AppendText("-");
                    }
                    else if (i < _polynomial.Count - 1 || _polynomial[i].Coefficient != 1)
                    {
                        _rtBox.AppendText("+");
                    }
                    if (_polynomial[i].Degree == 0)
                    {
                        _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                    }
                    else
                    {
                        if (Math.Abs(_polynomial[i].Coefficient.Real) != 1)
                            _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                        _rtBox.AppendText("X");
                        _rtBox.SelectionCharOffset = 7;
                        if (_polynomial[i].Degree > 1)
                            _rtBox.AppendText(_polynomial[i].Degree.ToString());
                        _rtBox.SelectionCharOffset = 0;
                    }
                }
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
