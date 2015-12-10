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
    public partial class Form1 : Form
    {
        public Polynomial polynomial1, polynomial2, resultPolynomial;

        public Form1()
        {
            InitializeComponent();
        }
        private void PerformOperation(object sender, EventArgs e)
        {
            try
            {
                switch ((sender as Glass.GlassButton).Tag as string)
                {
                    case "Add":

                        break;
                    case "Subtract":

                        break;
                    case "Multiply":

                        break;
                    case "Solve":

                        break;
                    case "Poly1":
                        GeneratePolynomials((int)p1Count.Value,1);
                        break;
                    case "Poly2":
                        GeneratePolynomials((int)p2Count.Value, 2);
                        break;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void GeneratePolynomials(int termNumber,byte polyNumber)
        {


            for (int i = 0; i < termNumber; i++)
            {
                PolynomialTerm pTerm = new PolynomialTerm();
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
            this.Refresh() ;

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
    }
}
