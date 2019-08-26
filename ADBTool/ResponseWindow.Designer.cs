namespace AC.AndroidUtils.GUI
{
    partial class ResponseWindow
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
            this.response = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // response
            // 
            this.response.Location = new System.Drawing.Point(13, 13);
            this.response.Multiline = true;
            this.response.Name = "response";
            this.response.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.response.Size = new System.Drawing.Size(1066, 542);
            this.response.TabIndex = 0;
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(455, 563);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(165, 50);
            this.close.TabIndex = 1;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ResponseWindow
            // 
            this.AcceptButton = this.close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(1091, 625);
            this.Controls.Add(this.close);
            this.Controls.Add(this.response);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResponseWindow";
            this.Text = "ResponseWindow";
            this.Load += new System.EventHandler(this.ResponseWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox response;
        private System.Windows.Forms.Button close;
    }
}