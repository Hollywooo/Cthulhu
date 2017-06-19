namespace Cthulhu_Decryption_2
{
    partial class Decryptor
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
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.tb_Output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.Location = new System.Drawing.Point(302, 69);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(110, 30);
            this.btn_Decrypt.TabIndex = 0;
            this.btn_Decrypt.Text = "Decrypt";
            this.btn_Decrypt.UseVisualStyleBackColor = true;
            this.btn_Decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
            // 
            // tb_Output
            // 
            this.tb_Output.Location = new System.Drawing.Point(12, 30);
            this.tb_Output.Name = "tb_Output";
            this.tb_Output.Size = new System.Drawing.Size(400, 22);
            this.tb_Output.TabIndex = 1;
            // 
            // Decryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.tb_Output);
            this.Controls.Add(this.btn_Decrypt);
            this.Name = "Decryptor";
            this.Text = "Decryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.TextBox tb_Output;
    }
}

