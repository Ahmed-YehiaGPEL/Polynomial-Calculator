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
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader(Application.StartupPath + "\\license.md");
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                richTextBox1.AppendText(line+"\r\n");
            }
        }
    }
}
