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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tipLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Polynomial1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LogPanel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.polynomial1Text = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.polynomial2Text = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resPolyText = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glassButton8 = new Glass.GlassButton();
            this.glassButton9 = new Glass.GlassButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.glassButton7 = new Glass.GlassButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.glassButton6 = new Glass.GlassButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.glassButton5 = new Glass.GlassButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.glassButton4 = new Glass.GlassButton();
            this.glassButton3 = new Glass.GlassButton();
            this.glassButton2 = new Glass.GlassButton();
            this.glassButton1 = new Glass.GlassButton();
            this.btnPoly2 = new Glass.GlassButton();
            this.btnPoly1 = new Glass.GlassButton();
            this.btnModulous = new Glass.GlassButton();
            this.btnDiv = new Glass.GlassButton();
            this.btnMultiply = new Glass.GlassButton();
            this.btnSubtract = new Glass.GlassButton();
            this.btnAdd = new Glass.GlassButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rootsTextBox = new System.Windows.Forms.TextBox();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Polynomial1Chart)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tipLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 535);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusBar.Size = new System.Drawing.Size(621, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Date / Time";
            // 
            // tipLabel
            // 
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(330, 17);
            this.tipLabel.Text = "Tip : You can change program settings from File->Customize";
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
            this.menuBar.Size = new System.Drawing.Size(621, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToolStripMenuItem,
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveasToolStripMenuItem.Text = "Save As";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadToolStripMenuItem.Text = "Load From File";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.customizeToolStripMenuItem.Text = "Customize";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem,
            this.licenseToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutUsToolStripMenuItem.Text = "&About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.licenseToolStripMenuItem.Text = "&License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Polynomial1Chart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.494F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.50601F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 511);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Polynomial1Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Polynomial1Chart.ChartAreas.Add(chartArea1);
            this.Polynomial1Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.Polynomial1Chart.Legends.Add(legend1);
            this.Polynomial1Chart.Location = new System.Drawing.Point(3, 363);
            this.Polynomial1Chart.Name = "Polynomial1Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Polynomial1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Polynomial2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Result Polynomial";
            this.Polynomial1Chart.Series.Add(series1);
            this.Polynomial1Chart.Series.Add(series2);
            this.Polynomial1Chart.Series.Add(series3);
            this.Polynomial1Chart.Size = new System.Drawing.Size(615, 145);
            this.Polynomial1Chart.TabIndex = 36;
            this.Polynomial1Chart.Text = "Polynomial1Chart";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.67123F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.32877F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(617, 356);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.LogPanel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(413, 352);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogPanel.Location = new System.Drawing.Point(2, 187);
            this.LogPanel.Margin = new System.Windows.Forms.Padding(2);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogPanel.Size = new System.Drawing.Size(409, 163);
            this.LogPanel.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.polynomial1Text);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(409, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polyonomial 1";
            // 
            // polynomial1Text
            // 
            this.polynomial1Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polynomial1Text.Location = new System.Drawing.Point(2, 15);
            this.polynomial1Text.Margin = new System.Windows.Forms.Padding(2);
            this.polynomial1Text.Multiline = false;
            this.polynomial1Text.Name = "polynomial1Text";
            this.polynomial1Text.Size = new System.Drawing.Size(405, 37);
            this.polynomial1Text.TabIndex = 0;
            this.polynomial1Text.Tag = "Poly1";
            this.polynomial1Text.Text = "Polynomial1";
            this.polynomial1Text.TextChanged += new System.EventHandler(this.SuperScriptOnX);
            this.polynomial1Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseOnEnter);
            this.polynomial1Text.Leave += new System.EventHandler(this.restorePlaceHolder);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.polynomial2Text);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(409, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Polynomial 2";
            // 
            // polynomial2Text
            // 
            this.polynomial2Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polynomial2Text.Location = new System.Drawing.Point(2, 15);
            this.polynomial2Text.Margin = new System.Windows.Forms.Padding(2);
            this.polynomial2Text.Multiline = false;
            this.polynomial2Text.Name = "polynomial2Text";
            this.polynomial2Text.Size = new System.Drawing.Size(405, 37);
            this.polynomial2Text.TabIndex = 1;
            this.polynomial2Text.Tag = "Poly2";
            this.polynomial2Text.Text = "Polynomial2";
            this.polynomial2Text.TextChanged += new System.EventHandler(this.SuperScriptOnX);
            this.polynomial2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseOnEnter);
            this.polynomial2Text.Leave += new System.EventHandler(this.restorePlaceHolder);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.resPolyText);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 118);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(409, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result polynomial";
            // 
            // resPolyText
            // 
            this.resPolyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resPolyText.Location = new System.Drawing.Point(2, 15);
            this.resPolyText.Margin = new System.Windows.Forms.Padding(2);
            this.resPolyText.Name = "resPolyText";
            this.resPolyText.ReadOnly = true;
            this.resPolyText.Size = new System.Drawing.Size(405, 48);
            this.resPolyText.TabIndex = 0;
            this.resPolyText.Text = "";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.historyListBox, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(419, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.7027F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.2973F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(196, 352);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(2, 182);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(192, 168);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Operations";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.glassButton8);
            this.panel1.Controls.Add(this.glassButton9);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.glassButton7);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.glassButton6);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.glassButton5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.glassButton4);
            this.panel1.Controls.Add(this.glassButton3);
            this.panel1.Controls.Add(this.glassButton2);
            this.panel1.Controls.Add(this.glassButton1);
            this.panel1.Controls.Add(this.btnPoly2);
            this.panel1.Controls.Add(this.btnPoly1);
            this.panel1.Controls.Add(this.btnModulous);
            this.panel1.Controls.Add(this.btnDiv);
            this.panel1.Controls.Add(this.btnMultiply);
            this.panel1.Controls.Add(this.btnSubtract);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 151);
            this.panel1.TabIndex = 0;
            // 
            // glassButton8
            // 
            this.glassButton8.GlowColor = System.Drawing.Color.Purple;
            this.glassButton8.Location = new System.Drawing.Point(86, 150);
            this.glassButton8.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton8.Name = "glassButton8";
            this.glassButton8.Size = new System.Drawing.Size(79, 25);
            this.glassButton8.TabIndex = 37;
            this.glassButton8.Tag = "int2";
            this.glassButton8.Text = "Poly.2 Int.";
            this.glassButton8.Click += new System.EventHandler(this.PerformOperation);
            // 
            // glassButton9
            // 
            this.glassButton9.GlowColor = System.Drawing.Color.Purple;
            this.glassButton9.Location = new System.Drawing.Point(2, 150);
            this.glassButton9.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton9.Name = "glassButton9";
            this.glassButton9.Size = new System.Drawing.Size(79, 25);
            this.glassButton9.TabIndex = 36;
            this.glassButton9.Tag = "int1";
            this.glassButton9.Text = "Poly.1 Int.";
            this.glassButton9.Click += new System.EventHandler(this.PerformOperation);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold);
            this.textBox5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox5.Location = new System.Drawing.Point(86, 283);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 34;
            this.textBox5.Tag = "Def2B";
            this.textBox5.Text = "Poly.2 b";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox5.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold);
            this.textBox6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox6.Location = new System.Drawing.Point(2, 283);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(80, 20);
            this.textBox6.TabIndex = 33;
            this.textBox6.Tag = "Def2A";
            this.textBox6.Text = "Poly.2 a";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox6.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // glassButton7
            // 
            this.glassButton7.GlowColor = System.Drawing.Color.Purple;
            this.glassButton7.Location = new System.Drawing.Point(0, 304);
            this.glassButton7.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton7.Name = "glassButton7";
            this.glassButton7.Size = new System.Drawing.Size(165, 25);
            this.glassButton7.TabIndex = 35;
            this.glassButton7.Tag = "DefInt2";
            this.glassButton7.Text = "Poly.2 Definite Integeral ";
            this.glassButton7.Click += new System.EventHandler(this.PerformOperation);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox4.Location = new System.Drawing.Point(86, 233);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 20);
            this.textBox4.TabIndex = 31;
            this.textBox4.Tag = "Def1B";
            this.textBox4.Text = "Poly.1 b";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox4.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox3.Location = new System.Drawing.Point(2, 233);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 30;
            this.textBox3.Tag = "Def1A";
            this.textBox3.Text = "Poly.1 a";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox3.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // glassButton6
            // 
            this.glassButton6.GlowColor = System.Drawing.Color.Purple;
            this.glassButton6.Location = new System.Drawing.Point(0, 255);
            this.glassButton6.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton6.Name = "glassButton6";
            this.glassButton6.Size = new System.Drawing.Size(165, 25);
            this.glassButton6.TabIndex = 32;
            this.glassButton6.Tag = "DefInt1";
            this.glassButton6.Text = "Poly.1 Definite Integral";
            this.glassButton6.Click += new System.EventHandler(this.PerformOperation);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(86, 205);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 29;
            this.textBox2.Tag = "Poly.2x";
            this.textBox2.Text = "Poly.2 x";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox2.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // glassButton5
            // 
            this.glassButton5.GlowColor = System.Drawing.Color.Purple;
            this.glassButton5.Location = new System.Drawing.Point(2, 205);
            this.glassButton5.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton5.Name = "glassButton5";
            this.glassButton5.Size = new System.Drawing.Size(79, 25);
            this.glassButton5.TabIndex = 28;
            this.glassButton5.Tag = "Sub2";
            this.glassButton5.Text = "Substitute 2";
            this.glassButton5.Click += new System.EventHandler(this.PerformOperation);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(86, 181);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.Tag = "Poly.1x";
            this.textBox1.Text = "Poly.1 x";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Enter += new System.EventHandler(this.PlaceHolderRemove);
            this.textBox1.Leave += new System.EventHandler(this.PlaceHolder);
            // 
            // glassButton4
            // 
            this.glassButton4.GlowColor = System.Drawing.Color.Purple;
            this.glassButton4.Location = new System.Drawing.Point(2, 177);
            this.glassButton4.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton4.Name = "glassButton4";
            this.glassButton4.Size = new System.Drawing.Size(79, 25);
            this.glassButton4.TabIndex = 26;
            this.glassButton4.Tag = "Sub1";
            this.glassButton4.Text = "Substitute 1";
            this.glassButton4.Click += new System.EventHandler(this.PerformOperation);
            // 
            // glassButton3
            // 
            this.glassButton3.GlowColor = System.Drawing.Color.Purple;
            this.glassButton3.Location = new System.Drawing.Point(86, 123);
            this.glassButton3.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton3.Name = "glassButton3";
            this.glassButton3.Size = new System.Drawing.Size(79, 25);
            this.glassButton3.TabIndex = 25;
            this.glassButton3.Tag = "derivative2";
            this.glassButton3.Text = "Poly.2 Deriv.";
            this.glassButton3.Click += new System.EventHandler(this.PerformOperation);
            // 
            // glassButton2
            // 
            this.glassButton2.GlowColor = System.Drawing.Color.Purple;
            this.glassButton2.Location = new System.Drawing.Point(2, 123);
            this.glassButton2.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.Size = new System.Drawing.Size(79, 25);
            this.glassButton2.TabIndex = 24;
            this.glassButton2.Tag = "derivative1";
            this.glassButton2.Text = "Poly.1 Deriv.";
            this.glassButton2.Click += new System.EventHandler(this.PerformOperation);
            // 
            // glassButton1
            // 
            this.glassButton1.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.glassButton1.Location = new System.Drawing.Point(86, 63);
            this.glassButton1.Margin = new System.Windows.Forms.Padding(2);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(79, 25);
            this.glassButton1.TabIndex = 21;
            this.glassButton1.Tag = "GCD";
            this.glassButton1.Text = "GCD";
            this.glassButton1.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnPoly2
            // 
            this.btnPoly2.GlowColor = System.Drawing.Color.Purple;
            this.btnPoly2.Location = new System.Drawing.Point(86, 93);
            this.btnPoly2.Margin = new System.Windows.Forms.Padding(2);
            this.btnPoly2.Name = "btnPoly2";
            this.btnPoly2.Size = new System.Drawing.Size(79, 25);
            this.btnPoly2.TabIndex = 23;
            this.btnPoly2.Tag = "Find X2";
            this.btnPoly2.Text = "Poly2. roots";
            this.btnPoly2.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnPoly1
            // 
            this.btnPoly1.GlowColor = System.Drawing.Color.Purple;
            this.btnPoly1.Location = new System.Drawing.Point(2, 93);
            this.btnPoly1.Margin = new System.Windows.Forms.Padding(2);
            this.btnPoly1.Name = "btnPoly1";
            this.btnPoly1.Size = new System.Drawing.Size(79, 25);
            this.btnPoly1.TabIndex = 22;
            this.btnPoly1.Tag = "Find X1";
            this.btnPoly1.Text = "Poly.1 roots";
            this.btnPoly1.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnModulous
            // 
            this.btnModulous.GlowColor = System.Drawing.Color.Olive;
            this.btnModulous.Location = new System.Drawing.Point(2, 63);
            this.btnModulous.Margin = new System.Windows.Forms.Padding(2);
            this.btnModulous.Name = "btnModulous";
            this.btnModulous.Size = new System.Drawing.Size(79, 25);
            this.btnModulous.TabIndex = 20;
            this.btnModulous.Tag = "Modulus";
            this.btnModulous.Text = "Modulus";
            this.btnModulous.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnDiv
            // 
            this.btnDiv.GlowColor = System.Drawing.Color.Lime;
            this.btnDiv.Location = new System.Drawing.Point(86, 32);
            this.btnDiv.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(79, 25);
            this.btnDiv.TabIndex = 19;
            this.btnDiv.Tag = "Division";
            this.btnDiv.Text = "Divide";
            this.btnDiv.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnMultiply
            // 
            this.btnMultiply.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMultiply.Location = new System.Drawing.Point(2, 32);
            this.btnMultiply.Margin = new System.Windows.Forms.Padding(2);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(79, 25);
            this.btnMultiply.TabIndex = 18;
            this.btnMultiply.Tag = "Multiply";
            this.btnMultiply.Text = "Multiply";
            this.btnMultiply.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnSubtract
            // 
            this.btnSubtract.GlowColor = System.Drawing.Color.Red;
            this.btnSubtract.Location = new System.Drawing.Point(86, 2);
            this.btnSubtract.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(79, 25);
            this.btnSubtract.TabIndex = 17;
            this.btnSubtract.Tag = "Subtract";
            this.btnSubtract.Text = "Subtract";
            this.btnSubtract.Click += new System.EventHandler(this.PerformOperation);
            // 
            // btnAdd
            // 
            this.btnAdd.GlowColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 25);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Tag = "Add";
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.PerformOperation);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rootsTextBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(192, 91);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Root finding";
            // 
            // rootsTextBox
            // 
            this.rootsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootsTextBox.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold);
            this.rootsTextBox.Location = new System.Drawing.Point(2, 15);
            this.rootsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.rootsTextBox.Multiline = true;
            this.rootsTextBox.Name = "rootsTextBox";
            this.rootsTextBox.ReadOnly = true;
            this.rootsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rootsTextBox.Size = new System.Drawing.Size(188, 74);
            this.rootsTextBox.TabIndex = 3;
            // 
            // historyListBox
            // 
            this.historyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyListBox.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold);
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.ItemHeight = 17;
            this.historyListBox.Location = new System.Drawing.Point(2, 97);
            this.historyListBox.Margin = new System.Windows.Forms.Padding(2);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.ScrollAlwaysVisible = true;
            this.historyListBox.Size = new System.Drawing.Size(192, 81);
            this.historyListBox.TabIndex = 1;
            this.historyListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 557);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Polynomial Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Polynomial1Chart)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripStatusLabel tipLabel;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Polynomial1Chart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox LogPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox polynomial1Text;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox polynomial2Text;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox resPolyText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private Glass.GlassButton glassButton5;
        private System.Windows.Forms.TextBox textBox1;
        private Glass.GlassButton glassButton4;
        private Glass.GlassButton glassButton3;
        private Glass.GlassButton glassButton2;
        private Glass.GlassButton glassButton1;
        private Glass.GlassButton btnPoly2;
        private Glass.GlassButton btnPoly1;
        private Glass.GlassButton btnModulous;
        private Glass.GlassButton btnDiv;
        private Glass.GlassButton btnMultiply;
        private Glass.GlassButton btnSubtract;
        private Glass.GlassButton btnAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox rootsTextBox;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private Glass.GlassButton glassButton7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private Glass.GlassButton glassButton6;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private Glass.GlassButton glassButton8;
        private Glass.GlassButton glassButton9;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
    }
}

