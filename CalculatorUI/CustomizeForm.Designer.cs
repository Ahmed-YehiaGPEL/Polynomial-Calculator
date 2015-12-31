namespace CalculatorUI
{
    partial class CustomizeForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorChangeButton = new System.Windows.Forms.Button();
            this.fontChangeButton = new System.Windows.Forms.Button();
            this.sampleTextBox = new System.Windows.Forms.RichTextBox();
            this.revertButton = new Glass.GlassButton();
            this.applyButton = new Glass.GlassButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblPoly1 = new System.Windows.Forms.Label();
            this.lblPoly2 = new System.Windows.Forms.Label();
            this.lblPoly3 = new System.Windows.Forms.Label();
            this.btnColorChng1 = new System.Windows.Forms.Button();
            this.btnColorChng2 = new System.Windows.Forms.Button();
            this.btnColorChng3 = new System.Windows.Forms.Button();
            this.minNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // colorChangeButton
            // 
            this.colorChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorChangeButton.Location = new System.Drawing.Point(322, 54);
            this.colorChangeButton.Name = "colorChangeButton";
            this.colorChangeButton.Size = new System.Drawing.Size(125, 32);
            this.colorChangeButton.TabIndex = 4;
            this.colorChangeButton.Text = "Change Color";
            this.colorChangeButton.UseVisualStyleBackColor = true;
            this.colorChangeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // fontChangeButton
            // 
            this.fontChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fontChangeButton.Location = new System.Drawing.Point(12, 54);
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.Size = new System.Drawing.Size(125, 32);
            this.fontChangeButton.TabIndex = 5;
            this.fontChangeButton.Text = "Change Font";
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sampleTextBox
            // 
            this.sampleTextBox.Location = new System.Drawing.Point(12, 92);
            this.sampleTextBox.Multiline = false;
            this.sampleTextBox.Name = "sampleTextBox";
            this.sampleTextBox.Size = new System.Drawing.Size(435, 47);
            this.sampleTextBox.TabIndex = 8;
            this.sampleTextBox.Text = "Sample Text";
            this.sampleTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.sampleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // revertButton
            // 
            this.revertButton.Location = new System.Drawing.Point(291, 370);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(156, 34);
            this.revertButton.TabIndex = 7;
            this.revertButton.Text = "Revert Changes";
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 370);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(156, 34);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply Changes";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(324, 24);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Ask me every time I want to exit.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblPoly1
            // 
            this.lblPoly1.AutoSize = true;
            this.lblPoly1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoly1.Location = new System.Drawing.Point(12, 149);
            this.lblPoly1.Name = "lblPoly1";
            this.lblPoly1.Size = new System.Drawing.Size(240, 22);
            this.lblPoly1.TabIndex = 10;
            this.lblPoly1.Text = "Polynomial 1 Plot Color";
            // 
            // lblPoly2
            // 
            this.lblPoly2.AutoSize = true;
            this.lblPoly2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoly2.Location = new System.Drawing.Point(12, 197);
            this.lblPoly2.Name = "lblPoly2";
            this.lblPoly2.Size = new System.Drawing.Size(240, 22);
            this.lblPoly2.TabIndex = 11;
            this.lblPoly2.Text = "Polynomial 2 Plot Color";
            // 
            // lblPoly3
            // 
            this.lblPoly3.AutoSize = true;
            this.lblPoly3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoly3.Location = new System.Drawing.Point(12, 244);
            this.lblPoly3.Name = "lblPoly3";
            this.lblPoly3.Size = new System.Drawing.Size(290, 22);
            this.lblPoly3.TabIndex = 12;
            this.lblPoly3.Text = "Result Polynomial Plot Color";
            // 
            // btnColorChng1
            // 
            this.btnColorChng1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorChng1.Location = new System.Drawing.Point(322, 145);
            this.btnColorChng1.Name = "btnColorChng1";
            this.btnColorChng1.Size = new System.Drawing.Size(125, 32);
            this.btnColorChng1.TabIndex = 13;
            this.btnColorChng1.Text = "Change Color";
            this.btnColorChng1.UseVisualStyleBackColor = true;
            this.btnColorChng1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnColorChng2
            // 
            this.btnColorChng2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorChng2.Location = new System.Drawing.Point(322, 193);
            this.btnColorChng2.Name = "btnColorChng2";
            this.btnColorChng2.Size = new System.Drawing.Size(125, 32);
            this.btnColorChng2.TabIndex = 14;
            this.btnColorChng2.Text = "Change Color";
            this.btnColorChng2.UseVisualStyleBackColor = true;
            this.btnColorChng2.Click += new System.EventHandler(this.btnColorChng2_Click);
            // 
            // btnColorChng3
            // 
            this.btnColorChng3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorChng3.Location = new System.Drawing.Point(322, 240);
            this.btnColorChng3.Name = "btnColorChng3";
            this.btnColorChng3.Size = new System.Drawing.Size(125, 32);
            this.btnColorChng3.TabIndex = 15;
            this.btnColorChng3.Text = "Change Color";
            this.btnColorChng3.UseVisualStyleBackColor = true;
            this.btnColorChng3.Click += new System.EventHandler(this.btnColorChng3_Click);
            // 
            // minNumeric
            // 
            this.minNumeric.Location = new System.Drawing.Point(322, 294);
            this.minNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minNumeric.Name = "minNumeric";
            this.minNumeric.Size = new System.Drawing.Size(125, 22);
            this.minNumeric.TabIndex = 16;
            this.minNumeric.ValueChanged += new System.EventHandler(this.minNumeric_ValueChanged);
            // 
            // maxNumeric
            // 
            this.maxNumeric.Location = new System.Drawing.Point(322, 333);
            this.maxNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.maxNumeric.Name = "maxNumeric";
            this.maxNumeric.Size = new System.Drawing.Size(125, 22);
            this.maxNumeric.TabIndex = 17;
            this.maxNumeric.ValueChanged += new System.EventHandler(this.maxNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Plotter Min.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Plotter Max";
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxNumeric);
            this.Controls.Add(this.minNumeric);
            this.Controls.Add(this.btnColorChng3);
            this.Controls.Add(this.btnColorChng2);
            this.Controls.Add(this.btnColorChng1);
            this.Controls.Add(this.lblPoly3);
            this.Controls.Add(this.lblPoly2);
            this.Controls.Add(this.lblPoly1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sampleTextBox);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.fontChangeButton);
            this.Controls.Add(this.colorChangeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CustomizeForm";
            this.Tag = "cstForm";
            this.Text = "CustomizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.minNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button colorChangeButton;
        private System.Windows.Forms.Button fontChangeButton;
        private System.Windows.Forms.RichTextBox sampleTextBox;
        private Glass.GlassButton revertButton;
        private Glass.GlassButton applyButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblPoly1;
        private System.Windows.Forms.Label lblPoly2;
        private System.Windows.Forms.Label lblPoly3;
        private System.Windows.Forms.Button btnColorChng1;
        private System.Windows.Forms.Button btnColorChng2;
        private System.Windows.Forms.Button btnColorChng3;
        private System.Windows.Forms.NumericUpDown minNumeric;
        private System.Windows.Forms.NumericUpDown maxNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}