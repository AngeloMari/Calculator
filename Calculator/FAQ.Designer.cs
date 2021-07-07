
namespace Calculator
{
    partial class FAQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAQ));
            this.lblFAQ = new System.Windows.Forms.Label();
            this.txtboxFAQ = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblFAQ
            // 
            this.lblFAQ.AutoSize = true;
            this.lblFAQ.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFAQ.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFAQ.Location = new System.Drawing.Point(13, 13);
            this.lblFAQ.Name = "lblFAQ";
            this.lblFAQ.Size = new System.Drawing.Size(160, 23);
            this.lblFAQ.TabIndex = 0;
            this.lblFAQ.Text = "Calculator: FAQ";
            // 
            // txtboxFAQ
            // 
            this.txtboxFAQ.BackColor = System.Drawing.SystemColors.Control;
            this.txtboxFAQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxFAQ.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtboxFAQ.Location = new System.Drawing.Point(12, 46);
            this.txtboxFAQ.Name = "txtboxFAQ";
            this.txtboxFAQ.Size = new System.Drawing.Size(459, 403);
            this.txtboxFAQ.TabIndex = 1;
            this.txtboxFAQ.Text = resources.GetString("txtboxFAQ.Text");
            // 
            // FAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.txtboxFAQ);
            this.Controls.Add(this.lblFAQ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFAQ;
        private System.Windows.Forms.RichTextBox txtboxFAQ;
    }
}