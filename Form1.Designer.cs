namespace PasswordManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            decryptDialog = new OpenFileDialog ();
            encryptDialog = new SaveFileDialog ();
            textBoxPassword = new TextBox ();
            label1 = new Label ();
            buttonEncrypt = new Button ();
            buttonDecrypt = new Button ();
            textBoxContents = new TextBox ();
            SuspendLayout ();
            // 
            // decryptDialog
            // 
            decryptDialog.FileName = "openFileDialog1";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point (16, 800);
            textBoxPassword.Margin = new Padding (5);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size (1152, 48);
            textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point (16, 736);
            label1.Margin = new Padding (5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size (116, 32);
            label1.TabIndex = 1;
            label1.Text = "Password:";
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point (1184, 736);
            buttonEncrypt.Margin = new Padding (5);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size (256, 48);
            buttonEncrypt.TabIndex = 1;
            buttonEncrypt.Text = "Encrypt File";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += EncryptFile;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point (1184, 800);
            buttonDecrypt.Margin = new Padding (5);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size (256, 48);
            buttonDecrypt.TabIndex = 2;
            buttonDecrypt.Text = "Decrypt File";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += DecryptFile;
            // 
            // textBoxContents
            // 
            textBoxContents.Location = new Point (0, 0);
            textBoxContents.Margin = new Padding (5);
            textBoxContents.Multiline = true;
            textBoxContents.Name = "textBoxContents";
            textBoxContents.ScrollBars = ScrollBars.Vertical;
            textBoxContents.Size = new Size (1440, 720);
            textBoxContents.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF (13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (1440, 900);
            Controls.Add (textBoxContents);
            Controls.Add (buttonDecrypt);
            Controls.Add (buttonEncrypt);
            Controls.Add (label1);
            Controls.Add (textBoxPassword);
            Margin = new Padding (5);
            Name = "Form1";
            Text = "Password Manager";
            ResumeLayout (false);
            PerformLayout ();
        }

        #endregion

        private OpenFileDialog decryptDialog;
        private SaveFileDialog encryptDialog;
        private TextBox textBoxPassword;
        private Label label1;
        private Button buttonEncrypt;
        private Button buttonDecrypt;
        private TextBox textBoxContents;
    }
}