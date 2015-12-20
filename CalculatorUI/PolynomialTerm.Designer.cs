namespace CalculatorUI
{
    partial class PolynomialTermControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.coeff = new System.Windows.Forms.NumericUpDown();
            this.degree = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(101, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // coeff
            // 
            this.coeff.AutoSize = true;
            this.coeff.DecimalPlaces = 2;
            this.coeff.Location = new System.Drawing.Point(3, 28);
            this.coeff.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.coeff.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.coeff.Name = "coeff";
            this.coeff.Size = new System.Drawing.Size(92, 22);
            this.coeff.TabIndex = 1;
            this.coeff.ValueChanged += new System.EventHandler(this.coeff_ValueChanged);
            // 
            // degree
            // 
            this.degree.AutoSize = true;
            this.degree.DecimalPlaces = 2;
            this.degree.Location = new System.Drawing.Point(105, 1);
            this.degree.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(84, 22);
            this.degree.TabIndex = 2;
            this.degree.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.degree.ValueChanged += new System.EventHandler(this.degree_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Coral;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Free term";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 28);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.delToolStripMenuItem.Text = "Delete Term";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // PolynomialTermControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.degree);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.coeff);
            this.Controls.Add(this.label1);
            this.Name = "PolynomialTermControl";
            this.Size = new System.Drawing.Size(192, 53);
            this.Load += new System.EventHandler(this.PolynomialTermControl_Load);
            this.MouseHover += new System.EventHandler(this.PolynomialTermControl_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PolynomialTermControl_MouseMove);
            this.Resize += new System.EventHandler(this.PolynomialTermControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown degree;
        public System.Windows.Forms.NumericUpDown coeff;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
    }
}
