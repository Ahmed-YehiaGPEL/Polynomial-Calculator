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
    public partial class SplashScreen : Form
    {
        double i;
        internal System.Threading.Thread loadThread;
        //If not found wil be created
        internal string filePath = Application.StartupPath + "\\appdata.xml";

        public SplashScreen()
        {
            InitializeComponent();
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            loadThread = new System.Threading.Thread(LoadThread);
        }
        /// <summary>
        /// Load thread
        /// </summary>
        /// <!--Put whatever takes load in memory here-->
        void LoadThread()
        {
            try
            {

                Program._historyTrie = new CMath.Trie.PolynomialTrie(filePath);
            }
            catch
            {
                Program._historyTrie = new CMath.Trie.PolynomialTrie();
            }
        }
        private void FadeIN_Tick(object sender, EventArgs e)
        {
            i += 0.15;
            if (i >= 1)
            {//if form is fully visible, we execute the Fade Out Effect
                this.Opacity = 1;
                timerFadeIn.Enabled = false;//stop the Fade In Effect
                loadThread.Start();
                threadWatcher.Enabled = true;
                return;
            }
            this.Opacity = i;
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            //Fade out effect
            i -= 0.05;
            if (i <= 0.01)
            {//if form is invisible, we execute the Fade In Effect again
                this.Opacity = 0.0;
                timerFadeOut.Enabled = false;//stop the Fade Out Effect
                MainForm frmi = new MainForm();
                frmi.Show();
                this.Hide();
                return;
            }
            this.Opacity = i;
        }

        private void threadWatcher_Tick(object sender, EventArgs e)
        {

            if (!loadThread.IsAlive)
            {
                timerFadeOut.Enabled = true;
                threadWatcher.Enabled = false;
            }
        }
    }
}
