using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorUI
{
    public partial class PolynomialTermControl : UserControl
    {
        public PolynomialTermControl()
        {
            InitializeComponent();
        }
        public PolynomialTermControl(decimal _degree,decimal coef,bool isResult,bool isFreeTerm)
        {
            InitializeComponent();
         
            this.Degree = _degree;
            this.Coefficient = coef;
            this.isResultant = isResult;
            this.isFreeTerm = isFreeTerm;
        }
        public bool isResultant
        {
            get 
            { 
                return !this.degree.Visible;
            }
            set
            {
                this.degree.ReadOnly = value;
                this.coeff.ReadOnly = value;
                this.checkBox1.Visible = !value;
                this.contextMenuStrip1.Enabled = !value;
                this.Refresh();
            }
        }
        public bool isFreeTerm {
            get
            {
                return !this.label1.Visible;
            }
            set
            {
                label1.Visible = !value;
                degree.Visible = !value;
                if (value == true)
                {
                    degree.Minimum = 0.0M;
                    Degree = 0.0M;
                }
                else
                {
                    degree.Minimum = 1.0M; ;
                }
                this.Refresh();
            } 
        }
        public decimal Degree 
        { 
            get
            {
                if (isFreeTerm)
                {
                    return 0.0M;
                }
                else
                {
                    return this.degree.Value;
                }
            } 
            set
            {
                this.degree.Value = value;
            }
        }
        public decimal Coefficient
        {
            get
            {
                return this.coeff.Value;
            }
            set
            {
                this.coeff.Value = value;
            }
        }

        private void coeff_ValueChanged(object sender, EventArgs e)
        {

        }

        private void degree_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PolynomialTermControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.isFreeTerm = checkBox1.Checked;
            
        }


        private void PolynomialTermControl_Resize(object sender, EventArgs e)
        {
            
        }

        private void PolynomialTermControl_MouseHover(object sender, EventArgs e)
        {
        }

        private void PolynomialTermControl_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);

        }
    }
}
