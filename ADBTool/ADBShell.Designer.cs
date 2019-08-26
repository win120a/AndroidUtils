namespace AC.AndroidUtils.GUI
{
    partial class ADBShell
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
            this.shellText = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.runasroot = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shellText
            // 
            this.shellText.Location = new System.Drawing.Point(12, 38);
            this.shellText.Multiline = true;
            this.shellText.Name = "shellText";
            this.shellText.Size = new System.Drawing.Size(661, 299);
            this.shellText.TabIndex = 0;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(407, 349);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(130, 41);
            this.execute.TabIndex = 1;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(543, 349);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(130, 41);
            this.close.TabIndex = 2;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // runasroot
            // 
            this.runasroot.AutoSize = true;
            this.runasroot.Location = new System.Drawing.Point(12, 359);
            this.runasroot.Name = "runasroot";
            this.runasroot.Size = new System.Drawing.Size(133, 22);
            this.runasroot.TabIndex = 3;
            this.runasroot.Text = "Run as root";
            this.runasroot.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please do NOT enter the command that needs interaction.    Command:";
            // 
            // ADBShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(685, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runasroot);
            this.Controls.Add(this.close);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.shellText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ADBShell";
            this.Text = "ADB Shell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shellText;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.CheckBox runasroot;
        private System.Windows.Forms.Label label1;
    }
}