using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalculatorUI
{
    public partial class Form1 : Form
    {
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

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
