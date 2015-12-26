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
            this.SuspendLayout();
            // 
            // colorChangeButton
            // 
            this.colorChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorChangeButton.Location = new System.Drawing.Point(256, 12);
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
            this.fontChangeButton.Location = new System.Drawing.Point(12, 12);
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.Size = new System.Drawing.Size(125, 32);
            this.fontChangeButton.TabIndex = 5;
            this.fontChangeButton.Text = "Change Font";
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sampleTextBox
            // 
            this.sampleTextBox.Location = new System.Drawing.Point(12, 50);
            this.sampleTextBox.Multiline = false;
            this.sampleTextBox.Name = "sampleTextBox";
            this.sampleTextBox.Size = new System.Drawing.Size(370, 120);
            this.sampleTextBox.TabIndex = 8;
            this.sampleTextBox.Text = "Sample Text";
            this.sampleTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.sampleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // revertButton
            // 
            this.revertButton.Location = new System.Drawing.Point(225, 176);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(156, 34);
            this.revertButton.TabIndex = 7;
            this.revertButton.Text = "Revert Changes";
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 176);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(156, 34);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply Changes";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 220);
            this.Controls.Add(this.sampleTextBox);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.fontChangeButton);
            this.Controls.Add(this.colorChangeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CustomizeForm";
            this.Text = "CustomizeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button colorChangeButton;
        private System.Windows.Forms.Button fontChangeButton;
        private System.Windows.Forms.RichTextBox sampleTextBox;
        private Glass.GlassButton revertButton;
        private Glass.GlassButton applyButton;

    }
}