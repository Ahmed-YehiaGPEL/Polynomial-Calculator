using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorFont;
using CMath.PolynomialEquation;
using System.Numerics;

namespace CalculatorUI
{
    
    public partial class CustomizeForm : Form
    {
        internal string deg = "", coeff = "";
        internal Color clr, poly1Clr, poly2Clr, resPolyClr;
        internal Font fnt;
        internal int minVal, maxVal;
        public CustomizeForm()
        {
            //Initialize old stored settings

            clr = Properties.Settings.Default.Color;
            fnt = Properties.Settings.Default.Font;

            poly1Clr = Properties.Settings.Default.Polynomial1Color;
            poly2Clr = Properties.Settings.Default.Polynomial2Color;
            resPolyClr = Properties.Settings.Default.ResultPolyColor;

            minVal = Properties.Settings.Default.MinValue;
            maxVal = Properties.Settings.Default.MaxValue;

            InitializeComponent();
            //Load color,font into richtextbox
            for (int i = 0; i < sampleTextBox.TextLength; i++)
            {
                sampleTextBox.SelectionStart = i;
                sampleTextBox.SelectionLength = 1;
                sampleTextBox.SelectionFont = fnt;
                sampleTextBox.SelectionColor = clr;
            }
            checkBox1.Checked = Properties.Settings.Default.AskOnExit;

            lblPoly1.ForeColor = poly1Clr;
            lblPoly2.ForeColor = poly2Clr;
            lblPoly3.ForeColor = resPolyClr;

            minNumeric.Value = minVal;
            maxNumeric.Value = maxVal;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dResult = fontDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                fnt = fontDialog1.Font;
                for (int i = 0; i < sampleTextBox.TextLength; i++)
                {
                    sampleTextBox.SelectionStart = i;
                    sampleTextBox.SelectionLength = 1;
                    sampleTextBox.SelectionFont = fontDialog1.Font;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dResult = colorDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                clr = colorDialog1.Color;
                for (int i = 0; i < sampleTextBox.TextLength; i++)
              {
                sampleTextBox.SelectionStart = i;
                sampleTextBox.SelectionLength = 1;
                sampleTextBox.SelectionColor = colorDialog1.Color;
              }

            }
            
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
           
            Properties.Settings.Default.Color = clr;
            Properties.Settings.Default.Font = fnt;
            
            Properties.Settings.Default.Polynomial1Color = poly1Clr;
            Properties.Settings.Default.Polynomial2Color = poly2Clr;
            Properties.Settings.Default.ResultPolyColor = resPolyClr;

            Properties.Settings.Default.MinValue = minVal;
            Properties.Settings.Default.MaxValue = maxVal;

            
            Properties.Settings.Default.Save();

        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sampleTextBox.TextLength; i++)
            {
                sampleTextBox.SelectionStart = i;
                sampleTextBox.SelectionLength = 1;
                sampleTextBox.SelectionFont = Properties.Settings.Default.Font;
                sampleTextBox.SelectionColor = Properties.Settings.Default.Color;
            }
            lblPoly1.ForeColor = Properties.Settings.Default.Polynomial1Color;
            lblPoly2.ForeColor = Properties.Settings.Default.Polynomial2Color;
            lblPoly3.ForeColor = Properties.Settings.Default.ResultPolyColor;

            minNumeric.Value = Properties.Settings.Default.MinValue;
            maxNumeric.Value = Properties.Settings.Default.MaxValue;
        }
      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (sampleTextBox.TextLength != 0)
            {
                char lastChar = sampleTextBox.Text.Last();
                if (lastChar == 'X' || lastChar == 'x')
                {
                    sampleTextBox.SelectionCharOffset = 7;
                }
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sampleTextBox.SelectionCharOffset = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AskOnExit = checkBox1.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dResult = colorDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                poly1Clr = colorDialog1.Color;
                lblPoly1.ForeColor = poly1Clr;

            }
        }

        private void btnColorChng2_Click(object sender, EventArgs e)
        {
            DialogResult dResult = colorDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                poly2Clr = colorDialog1.Color;
                lblPoly2.ForeColor = poly2Clr;

            }
        }

        private void btnColorChng3_Click(object sender, EventArgs e)
        {
            DialogResult dResult = colorDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                resPolyClr = colorDialog1.Color;
                lblPoly3.ForeColor = resPolyClr;

            }
        }

        private void minNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (minNumeric.Value > (maxNumeric.Value - 20))
            {
                minNumeric.Value = maxNumeric.Value - (decimal)20.0;
            }
            else
            {
                minVal = (int)minNumeric.Value;
            }

        }

        private void maxNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (maxNumeric.Value < (minNumeric.Value + 20))
            {
                maxNumeric.Value = minNumeric.Value + (decimal)20.0;
            }
            else
            {
                maxVal = (int)maxNumeric.Value;
            }
        }

      
       
    }
}
