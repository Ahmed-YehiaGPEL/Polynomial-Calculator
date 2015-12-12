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
        public PolynomialTermControl(decimal _degree,decimal coef)
        {
            
            InitializeComponent();
            this.Degree = _degree;
            this.Coefficient = coef;
        }
        public decimal Degree 
        { 
            get
            {
                return this.degree.Value;
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
            this.Parent.Controls.Remove(this);
        }
    }
}
