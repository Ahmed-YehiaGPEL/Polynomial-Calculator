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
            this.label1 = new System.Windows.Forms.Label();
            this.coeff = new System.Windows.Forms.NumericUpDown();
            this.degree = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(96, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // coeff
            // 
            this.coeff.AutoSize = true;
            this.coeff.DecimalPlaces = 2;
            this.coeff.Location = new System.Drawing.Point(-2, 28);
            this.coeff.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.coeff.Name = "coeff";
            this.coeff.Size = new System.Drawing.Size(92, 22);
            this.coeff.TabIndex = 1;
            this.coeff.ValueChanged += new System.EventHandler(this.coeff_ValueChanged);
            // 
            // degree
            // 
            this.degree.AutoSize = true;
            this.degree.DecimalPlaces = 2;
            this.degree.Location = new System.Drawing.Point(127, 3);
            this.degree.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(84, 22);
            this.degree.TabIndex = 2;
            this.degree.ValueChanged += new System.EventHandler(this.degree_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PolynomialTermControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.degree);
            this.Controls.Add(this.coeff);
            this.Controls.Add(this.label1);
            this.Name = "PolynomialTermControl";
            this.Size = new System.Drawing.Size(217, 53);
            this.Load += new System.EventHandler(this.PolynomialTermControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown degree;
        public System.Windows.Forms.NumericUpDown coeff;
        private System.Windows.Forms.Button button1;
    }
}
