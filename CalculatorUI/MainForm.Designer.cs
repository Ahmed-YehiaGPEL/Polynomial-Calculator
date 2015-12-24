namespace CalculatorUI
{
    partial class MainForm
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
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowPolynomial2 = new System.Windows.Forms.FlowLayoutPanel();
            this.polynomial2Text = new System.Windows.Forms.RichTextBox();
            this.p2Count = new System.Windows.Forms.NumericUpDown();
            this.glassButton2 = new Glass.GlassButton();
            this.btnSolve = new Glass.GlassButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new Glass.GlassButton();
            this.btnSubtract = new Glass.GlassButton();
            this.btnMult = new Glass.GlassButton();
            this.BtnDiv = new Glass.GlassButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowResultPoly = new System.Windows.Forms.FlowLayoutPanel();
            this.resPolyText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowPolynomial1 = new System.Windows.Forms.FlowLayoutPanel();
            this.polynomial1Text = new System.Windows.Forms.RichTextBox();
            this.glassButton1 = new Glass.GlassButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LogPanel = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowPolynomial2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2Count)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowResultPoly.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowPolynomial1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusBar.Location = new System.Drawing.Point(0, 486);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusBar.Size = new System.Drawing.Size(656, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            this.statusBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusBar_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Date / Time";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel2.Text = "Loading history";
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuBar.Size = new System.Drawing.Size(656, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.clearLogToolStripMenuItem,
            this.toolStripMenuItem2,
            this.customizeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customizeToolStripMenuItem.Text = "Customize";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(120, 6);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.aboutUsToolStripMenuItem.Text = "&About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(656, 462);
            this.splitContainer1.SplitterDistance = 491;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 172);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(491, 173);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Polynomial 2";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.flowPolynomial2);
            this.panel3.Controls.Add(this.p2Count);
            this.panel3.Controls.Add(this.glassButton2);
            this.panel3.Controls.Add(this.btnSolve);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 156);
            this.panel3.TabIndex = 1;
            // 
            // flowPolynomial2
            // 
            this.flowPolynomial2.AutoScroll = true;
            this.flowPolynomial2.Controls.Add(this.polynomial2Text);
            this.flowPolynomial2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPolynomial2.Location = new System.Drawing.Point(0, 0);
            this.flowPolynomial2.Margin = new System.Windows.Forms.Padding(2);
            this.flowPolynomial2.Name = "flowPolynomial2";
            this.flowPolynomial2.Size = new System.Drawing.Size(487, 79);
            this.flowPolynomial2.TabIndex = 10;
            // 
            // polynomial2Text
            // 
            this.polynomial2Text.Location = new System.Drawing.Point(2, 2);
            this.polynomial2Text.Margin = new System.Windows.Forms.Padding(2);
            this.polynomial2Text.Multiline = false;
            this.polynomial2Text.Name = "polynomial2Text";
            this.polynomial2Text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.polynomial2Text.Size = new System.Drawing.Size(483, 31);
            this.polynomial2Text.TabIndex = 0;
            this.polynomial2Text.Tag = "Poly2";
            this.polynomial2Text.Text = "Second Polynomial";
            this.polynomial2Text.TextChanged += new System.EventHandler(this.SuperScriptOnX);
            this.polynomial2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseOnEnter);
            // 
            // p2Count
            // 
            this.p2Count.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p2Count.Location = new System.Drawing.Point(0, 79);
            this.p2Count.Margin = new System.Windows.Forms.Padding(2);
            this.p2Count.Name = "p2Count";
            this.p2Count.Size = new System.Drawing.Size(487, 20);
            this.p2Count.TabIndex = 8;
            // 
            // glassButton2
            // 
            this.glassButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.glassButton2.Location = new System.Drawing.Point(0, 99);
            this.glassButton2.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.Size = new System.Drawing.Size(487, 32);
            this.glassButton2.TabIndex = 9;
            this.glassButton2.Tag = "Poly2";
            this.glassButton2.Text = "Generate Terms";
            this.glassButton2.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnSolve
            // 
            this.btnSolve.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSolve.Location = new System.Drawing.Point(0, 131);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(487, 25);
            this.btnSolve.TabIndex = 11;
            this.btnSolve.Tag = "Find X2";
            this.btnSolve.Text = "Find X";
            this.btnSolve.Click += new System.EventHandler(this.PerformOperation);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnSubtract);
            this.flowLayoutPanel1.Controls.Add(this.btnMult);
            this.flowLayoutPanel1.Controls.Add(this.BtnDiv);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-1, 428);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(493, 33);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Tag = "Add";
            this.btnAdd.Text = "Add Polynomials";
            this.btnAdd.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(100, 2);
            this.btnSubtract.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(112, 25);
            this.btnSubtract.TabIndex = 1;
            this.btnSubtract.Tag = "Subtract";
            this.btnSubtract.Text = "Subtract Polynomials";
            this.btnSubtract.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnMult
            // 
            this.btnMult.Location = new System.Drawing.Point(216, 2);
            this.btnMult.Margin = new System.Windows.Forms.Padding(2);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(112, 25);
            this.btnMult.TabIndex = 2;
            this.btnMult.Tag = "Multiply";
            this.btnMult.Text = "Multiply Polynomials";
            this.btnMult.Click += new System.EventHandler(this.PerformOperation);
            // 
            // BtnDiv
            // 
            this.BtnDiv.Location = new System.Drawing.Point(332, 2);
            this.BtnDiv.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDiv.Name = "BtnDiv";
            this.BtnDiv.Size = new System.Drawing.Size(112, 25);
            this.BtnDiv.TabIndex = 3;
            this.BtnDiv.Tag = "Division";
            this.BtnDiv.Text = "Divide Polynomials";
            this.BtnDiv.Click += new System.EventHandler(this.PerformOperation);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 345);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(491, 117);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.flowResultPoly);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(487, 100);
            this.panel4.TabIndex = 2;
            // 
            // flowResultPoly
            // 
            this.flowResultPoly.AutoScroll = true;
            this.flowResultPoly.Controls.Add(this.resPolyText);
            this.flowResultPoly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowResultPoly.Location = new System.Drawing.Point(0, 0);
            this.flowResultPoly.Margin = new System.Windows.Forms.Padding(2);
            this.flowResultPoly.Name = "flowResultPoly";
            this.flowResultPoly.Size = new System.Drawing.Size(487, 100);
            this.flowResultPoly.TabIndex = 12;
            // 
            // resPolyText
            // 
            this.resPolyText.Location = new System.Drawing.Point(2, 2);
            this.resPolyText.Margin = new System.Windows.Forms.Padding(2);
            this.resPolyText.Multiline = false;
            this.resPolyText.Name = "resPolyText";
            this.resPolyText.ReadOnly = true;
            this.resPolyText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.resPolyText.Size = new System.Drawing.Size(483, 32);
            this.resPolyText.TabIndex = 0;
            this.resPolyText.Tag = "resPoly";
            this.resPolyText.Text = "Result would be here";
            this.resPolyText.TextChanged += new System.EventHandler(this.SuperScriptOnX);
            this.resPolyText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseOnEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(491, 172);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polynomial 1";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.flowPolynomial1);
            this.panel2.Controls.Add(this.glassButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 155);
            this.panel2.TabIndex = 0;
            // 
            // flowPolynomial1
            // 
            this.flowPolynomial1.AutoScroll = true;
            this.flowPolynomial1.Controls.Add(this.polynomial1Text);
            this.flowPolynomial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPolynomial1.Location = new System.Drawing.Point(0, 0);
            this.flowPolynomial1.Margin = new System.Windows.Forms.Padding(2);
            this.flowPolynomial1.Name = "flowPolynomial1";
            this.flowPolynomial1.Size = new System.Drawing.Size(487, 130);
            this.flowPolynomial1.TabIndex = 7;
            // 
            // polynomial1Text
            // 
            this.polynomial1Text.Location = new System.Drawing.Point(2, 2);
            this.polynomial1Text.Margin = new System.Windows.Forms.Padding(2);
            this.polynomial1Text.Multiline = false;
            this.polynomial1Text.Name = "polynomial1Text";
            this.polynomial1Text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.polynomial1Text.Size = new System.Drawing.Size(483, 36);
            this.polynomial1Text.TabIndex = 0;
            this.polynomial1Text.Tag = "Poly1";
            this.polynomial1Text.Text = "First Polynomial";
            this.polynomial1Text.TextChanged += new System.EventHandler(this.SuperScriptOnX);
            this.polynomial1Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseOnEnter);
            // 
            // glassButton1
            // 
            this.glassButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.glassButton1.Location = new System.Drawing.Point(0, 130);
            this.glassButton1.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(487, 25);
            this.glassButton1.TabIndex = 12;
            this.glassButton1.Tag = "Find X1";
            this.glassButton1.Text = "Find X";
            this.glassButton1.Click += new System.EventHandler(this.PerformOperation);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 462);
            this.panel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(162, 345);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LogPanel);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 345);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(162, 117);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // LogPanel
            // 
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogPanel.Location = new System.Drawing.Point(2, 15);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(2);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogPanel.Size = new System.Drawing.Size(158, 100);
            this.LogPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 508);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Polynomial Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowPolynomial2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2Count)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowResultPoly.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowPolynomial1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox LogPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Glass.GlassButton btnAdd;
        private Glass.GlassButton btnSubtract;
        private Glass.GlassButton btnMult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowResultPoly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowPolynomial2;
        private System.Windows.Forms.NumericUpDown p2Count;
        private Glass.GlassButton glassButton2;
        private Glass.GlassButton btnSolve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowPolynomial1;
        private Glass.GlassButton glassButton1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox polynomial2Text;
        private System.Windows.Forms.RichTextBox resPolyText;
        private System.Windows.Forms.RichTextBox polynomial1Text;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private Glass.GlassButton BtnDiv;
    }
}

