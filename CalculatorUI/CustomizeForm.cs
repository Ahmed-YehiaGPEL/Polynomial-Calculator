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
        internal Color clr;
        internal Font fnt;
        public CustomizeForm()
        {
            //Initialize old stored settings

            clr = Properties.Settings.Default.Color;
            fnt = Properties.Settings.Default.Font;
   
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

      
       
    }
}
