namespace CalculatorUI
{
    partial class LogPanel
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.countLabel = new System.Windows.Forms.ToolStripLabel();
            this._rbox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(749, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogPanel_KeyPress);
            // 
            // countLabel
            // 
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(83, 22);
            this.countLabel.Text = "N Log item";
            // 
            // _rbox
            // 
            this._rbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rbox.Location = new System.Drawing.Point(0, 25);
            this._rbox.Name = "_rbox";
            this._rbox.ReadOnly = true;
            this._rbox.Size = new System.Drawing.Size(749, 209);
            this._rbox.TabIndex = 1;
            this._rbox.Text = "";
            this._rbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogPanel_KeyPress);
            // 
            // LogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 234);
            this.Controls.Add(this._rbox);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LogPanel";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogPanel_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel countLabel;
        private System.Windows.Forms.RichTextBox _rbox;
    }
}