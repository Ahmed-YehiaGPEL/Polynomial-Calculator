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
    public partial class LogPanel : Form
    {
        public LogPanel()
        {
            InitializeComponent();

        }
        public LogPanel(List<string> _logdata)
        {
            InitializeComponent();

            foreach (var item in _logdata)
            {
                _rbox.AppendText(item + "\r\n");
            }
            for (int i = 0; i < _rbox.TextLength; i++)
            {
                _rbox.SelectionStart = i;
                _rbox.SelectionLength = 1;
                _rbox.SelectionFont = Properties.Settings.Default.Font;
                _rbox.SelectionColor = Properties.Settings.Default.Color;
            }
            countLabel.Text = (_rbox.Lines.Length - 1).ToString("0") + " Log items";
        }

        private void LogPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
