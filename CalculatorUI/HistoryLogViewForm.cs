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

namespace CalculatorUI
{
    public partial class HistoryLogViewForm : Form
    {
        public HistoryLogViewForm()
        {
            InitializeComponent();
        }
        public HistoryLogViewForm(HistoryLog _log)
        {
            InitializeComponent();
            ShowPolynomial(_log.firstPolynomial, _log.secondPolynomial, _log.resultPolynomial);
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
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        public void ShowPolynomial(Polynomial _poly1,Polynomial _poly2,Polynomial _res)
        {
            foreach (var item in _poly1)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)item.Degree, (decimal)item.Coefficient.Real, true, item.Degree == 0);
                flowLayoutPanel1.Controls.Add(_ptc);
            }
            foreach (var item in _poly2)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)item.Degree, (decimal)item.Coefficient.Real, true, item.Degree == 0);
                flowLayoutPanel2.Controls.Add(_ptc);
            }

            for (int i = _res.Count-1; i >=0; i--)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)_res[i].Degree, (decimal)_res[i].Coefficient.Real, true, _res[i].Degree == 0);
                flowLayoutPanel3.Controls.Add(_ptc);
            }
        }

        private void HistoryLogViewForm_Load(object sender, EventArgs e)
        {

        }

        private void polynomialTermControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
