namespace CalculatorUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new Glass.GlassButton();
            this.btnSubtract = new Glass.GlassButton();
            this.btnMult = new Glass.GlassButton();
            this.btnSolve = new Glass.GlassButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowPolynomial2 = new System.Windows.Forms.FlowLayoutPanel();
            this.p2Count = new System.Windows.Forms.NumericUpDown();
            this.glassButton2 = new Glass.GlassButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowPolynomial1 = new System.Windows.Forms.FlowLayoutPanel();
            this.p1Count = new System.Windows.Forms.NumericUpDown();
            this.generatePoly1 = new Glass.GlassButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowResultPoly = new System.Windows.Forms.FlowLayoutPanel();
            this.polynomialTerm7 = new CalculatorUI.PolynomialTerm();
            this.polynomialTerm8 = new CalculatorUI.PolynomialTerm();
            this.polynomialTerm9 = new CalculatorUI.PolynomialTerm();
            this.polynomialTerm12 = new CalculatorUI.PolynomialTerm();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2Count)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1Count)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowResultPoly.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 478);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(905, 25);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 20);
            this.toolStripStatusLabel1.Text = "Date / Time";
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(905, 28);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(139, 24);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.aboutUsToolStripMenuItem.Text = "&About Us";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(705, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Operation 1",
            "Operation 2"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 306);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 144);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 123);
            this.textBox1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnSubtract);
            this.flowLayoutPanel1.Controls.Add(this.btnMult);
            this.flowLayoutPanel1.Controls.Add(this.btnSolve);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 433);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(705, 45);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 31);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Polynomials";
            this.btnAdd.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(134, 3);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(150, 31);
            this.btnSubtract.TabIndex = 1;
            this.btnSubtract.Text = "Subtract Polynomials";
            this.btnSubtract.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnMult
            // 
            this.btnMult.Location = new System.Drawing.Point(290, 3);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(150, 31);
            this.btnMult.TabIndex = 2;
            this.btnMult.Text = "Multiply Polynomials";
            this.btnMult.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(446, 3);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(150, 31);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Find X";
            this.btnSolve.Click += new System.EventHandler(this.PerformOperation);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 151);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Polynomial 2";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.flowPolynomial2);
            this.panel3.Controls.Add(this.p2Count);
            this.panel3.Controls.Add(this.glassButton2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 130);
            this.panel3.TabIndex = 1;
            // 
            // flowPolynomial2
            // 
            this.flowPolynomial2.AutoScroll = true;
            this.flowPolynomial2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPolynomial2.Location = new System.Drawing.Point(0, 0);
            this.flowPolynomial2.Name = "flowPolynomial2";
            this.flowPolynomial2.Size = new System.Drawing.Size(699, 69);
            this.flowPolynomial2.TabIndex = 10;
            // 
            // p2Count
            // 
            this.p2Count.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p2Count.Location = new System.Drawing.Point(0, 69);
            this.p2Count.Name = "p2Count";
            this.p2Count.Size = new System.Drawing.Size(699, 22);
            this.p2Count.TabIndex = 8;
            // 
            // glassButton2
            // 
            this.glassButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.glassButton2.Location = new System.Drawing.Point(0, 91);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.Size = new System.Drawing.Size(699, 39);
            this.glassButton2.TabIndex = 9;
            this.glassButton2.Tag = "Poly2";
            this.glassButton2.Text = "Generate Terms";
            this.glassButton2.Click += new System.EventHandler(this.PerformOperation);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polynomial 1";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.flowPolynomial1);
            this.panel2.Controls.Add(this.p1Count);
            this.panel2.Controls.Add(this.generatePoly1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 119);
            this.panel2.TabIndex = 0;
            // 
            // flowPolynomial1
            // 
            this.flowPolynomial1.AutoScroll = true;
            this.flowPolynomial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPolynomial1.Location = new System.Drawing.Point(0, 0);
            this.flowPolynomial1.Name = "flowPolynomial1";
            this.flowPolynomial1.Size = new System.Drawing.Size(699, 58);
            this.flowPolynomial1.TabIndex = 7;
            // 
            // p1Count
            // 
            this.p1Count.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p1Count.Location = new System.Drawing.Point(0, 58);
            this.p1Count.Name = "p1Count";
            this.p1Count.Size = new System.Drawing.Size(699, 22);
            this.p1Count.TabIndex = 1;
            // 
            // generatePoly1
            // 
            this.generatePoly1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.generatePoly1.Location = new System.Drawing.Point(0, 80);
            this.generatePoly1.Name = "generatePoly1";
            this.generatePoly1.Size = new System.Drawing.Size(699, 39);
            this.generatePoly1.TabIndex = 6;
            this.generatePoly1.Tag = "Poly1";
            this.generatePoly1.Text = "Generate Terms";
            this.generatePoly1.Click += new System.EventHandler(this.PerformOperation);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Location = new System.Drawing.Point(0, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 101);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.flowResultPoly);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(699, 80);
            this.panel4.TabIndex = 2;
            // 
            // flowResultPoly
            // 
            this.flowResultPoly.AutoScroll = true;
            this.flowResultPoly.Controls.Add(this.polynomialTerm7);
            this.flowResultPoly.Controls.Add(this.polynomialTerm8);
            this.flowResultPoly.Controls.Add(this.polynomialTerm9);
            this.flowResultPoly.Controls.Add(this.polynomialTerm12);
            this.flowResultPoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowResultPoly.Location = new System.Drawing.Point(0, 0);
            this.flowResultPoly.Name = "flowResultPoly";
            this.flowResultPoly.Size = new System.Drawing.Size(699, 80);
            this.flowResultPoly.TabIndex = 12;
            // 
            // polynomialTerm7
            // 
            this.polynomialTerm7.AutoSize = true;
            this.polynomialTerm7.BackColor = System.Drawing.Color.Transparent;
            this.polynomialTerm7.Location = new System.Drawing.Point(3, 3);
            this.polynomialTerm7.Name = "polynomialTerm7";
            this.polynomialTerm7.Size = new System.Drawing.Size(168, 44);
            this.polynomialTerm7.TabIndex = 1;
            // 
            // polynomialTerm8
            // 
            this.polynomialTerm8.AutoSize = true;
            this.polynomialTerm8.BackColor = System.Drawing.Color.Transparent;
            this.polynomialTerm8.Location = new System.Drawing.Point(177, 3);
            this.polynomialTerm8.Name = "polynomialTerm8";
            this.polynomialTerm8.Size = new System.Drawing.Size(168, 44);
            this.polynomialTerm8.TabIndex = 2;
            // 
            // polynomialTerm9
            // 
            this.polynomialTerm9.AutoSize = true;
            this.polynomialTerm9.BackColor = System.Drawing.Color.Transparent;
            this.polynomialTerm9.Location = new System.Drawing.Point(351, 3);
            this.polynomialTerm9.Name = "polynomialTerm9";
            this.polynomialTerm9.Size = new System.Drawing.Size(168, 44);
            this.polynomialTerm9.TabIndex = 3;
            // 
            // polynomialTerm12
            // 
            this.polynomialTerm12.AutoScroll = true;
            this.polynomialTerm12.AutoSize = true;
            this.polynomialTerm12.BackColor = System.Drawing.Color.Transparent;
            this.polynomialTerm12.Location = new System.Drawing.Point(525, 3);
            this.polynomialTerm12.Name = "polynomialTerm12";
            this.polynomialTerm12.Size = new System.Drawing.Size(168, 44);
            this.polynomialTerm12.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 503);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Form1";
            this.Text = "Polynomial Calculator";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2Count)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1Count)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowResultPoly.ResumeLayout(false);
            this.flowResultPoly.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Glass.GlassButton btnAdd;
        private Glass.GlassButton btnSubtract;
        private Glass.GlassButton btnMult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Glass.GlassButton btnSolve;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowPolynomial2;
        private System.Windows.Forms.NumericUpDown p2Count;
        private Glass.GlassButton glassButton2;
        private System.Windows.Forms.FlowLayoutPanel flowPolynomial1;
        private System.Windows.Forms.NumericUpDown p1Count;
        private Glass.GlassButton generatePoly1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowResultPoly;
        private PolynomialTerm polynomialTerm7;
        private PolynomialTerm polynomialTerm8;
        private PolynomialTerm polynomialTerm9;
        private PolynomialTerm polynomialTerm12;
    }
}

