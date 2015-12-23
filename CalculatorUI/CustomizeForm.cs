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
            clr = Properties.Settings.Default.Color;
            fnt = Properties.Settings.Default.Font;
   
            InitializeComponent();
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionFont = fnt;
                richTextBox1.SelectionColor = clr;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomizeForm_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dResult = fontDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                fnt = fontDialog1.Font;
                for (int i = 0; i < richTextBox1.TextLength; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dResult = colorDialog1.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                clr = colorDialog1.Color;
                for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionColor = colorDialog1.Color;
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
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                richTextBox1.SelectionFont = Properties.Settings.Default.Font;
                richTextBox1.SelectionColor = Properties.Settings.Default.Color;
            }
        }
      

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (richTextBox1.TextLength != 0)
            {
                char lastChar = richTextBox1.Text.Last();
                if (lastChar == 'X' || lastChar == 'x')
                {
                    richTextBox1.SelectionCharOffset = 7;
                }
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                richTextBox1.SelectionCharOffset = 0;
            }
        }

      
       
    }
}
