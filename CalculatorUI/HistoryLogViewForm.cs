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
                ParsePolynomial(_log.firstPolynomial, richTextBox1);
                ParsePolynomial(_log.secondPolynomial, richTextBox2);
                ParsePolynomial(_log.resultPolynomial, richTextBox3);
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
            }
        }
        public void showRoots(Polynomial equation, List<Complex> roots)
        {
            ParsePolynomial(equation, richTextBox1);
            splitContainer2.Panel1Collapsed = true;
            foreach (var item in roots)
            {
                if(item.Imaginary == 0)
                    richTextBox3.Text += item.Real.ToString() + "\r\n";
                else
                {
                    richTextBox3.Text += item.Real.ToString() + " ";
                    if(item.Imaginary > 0)
                    {
                        richTextBox3.Text += "+ "+ item.Imaginary.ToString() + "i" + "\r\n";
                    }
                    else
                    {
                        richTextBox3.Text += "- " + item.Imaginary.ToString().Substring(1);
                        richTextBox3.AppendText("i\r\n");
                    }
                }
            }
        }
        private void ParsePolynomial(Polynomial _polynomial, RichTextBox _rtBox)
        {

                for (int i = _polynomial.Count -1; i >=0; i--)
                {
                    if (_polynomial[i].Degree == 0)
                    {
                        _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                        if(i!=0)
                        _rtBox.AppendText("+");
                    }
                    else
                    {
                        _rtBox.AppendText(_polynomial[i].Coefficient.Imaginary == 0 ? _polynomial[i].Coefficient.Real.ToString() : _polynomial[i].Coefficient.ToString());
                        _rtBox.AppendText("X");
                        _rtBox.SelectionCharOffset = 7;
                        _rtBox.AppendText(_polynomial[i].Degree.ToString());
                        _rtBox.SelectionCharOffset = 0;
                        if (i != 0)
                            _rtBox.AppendText("+");
                    }

                }
               
            
        }
        private void HistoryLogViewForm_Load(object sender, EventArgs e)
        {
            LoadColorFont(richTextBox1);
            LoadColorFont(richTextBox2);
            LoadColorFont(richTextBox3);
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
