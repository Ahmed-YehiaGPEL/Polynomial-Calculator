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
                ShowPolynomial(_log.firstPolynomial, _log.secondPolynomial, _log.resultPolynomial);
            else
                showRoots(_log.firstPolynomial, _log.roots);
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
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        public void ShowPolynomial(Polynomial _poly1, Polynomial _poly2, Polynomial _res)
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

            for (int i = _res.Count - 1; i >= 0; i--)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)_res[i].Degree, (decimal)_res[i].Coefficient.Real, true, _res[i].Degree == 0);
                flowLayoutPanel3.Controls.Add(_ptc);
            }
        }
        public void showRoots(Polynomial equation, List<Complex> roots)
        {
            foreach (var item in equation)
            {
                PolynomialTermControl _ptc = new PolynomialTermControl((decimal)item.Degree, (decimal)item.Coefficient.Real, true, item.Degree == 0);
                flowLayoutPanel1.Controls.Add(_ptc);
            }
            splitContainer1.Panel2.Controls.Remove(splitContainer2);
            splitContainer1.Panel2.Controls.Add(groupBox2);
            groupBox2.Text = "Roots";
            flowLayoutPanel2.Hide();
            this.groupBox2.Controls.Add(this.rootsLog);
            this.rootsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootsLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootsLog.Multiline = true;
            this.rootsLog.Name = "LogPanel";
            this.rootsLog.ReadOnly = true;
            this.rootsLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rootsLog.TabIndex = 2;
            foreach (var item in roots)
            {
                this.rootsLog.Text += item.ToString() + "\r\n";
            }
        }
    }
}
