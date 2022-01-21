using System.Security.Cryptography;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptFile(object sender, EventArgs e)
        {
            var dialogResult = encryptDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
                return;

            byte[] encrypted;
            var rfc = new Rfc2898DeriveBytes(textBoxPassword.Text, 8, 1024);
            var aes = Aes.Create();
            aes.Key = rfc.GetBytes(16);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(textBoxContents.Text);
                    }
                    encrypted = ms.ToArray();
                }
            }

            byte[] toWrite = (new byte[] { (byte)rfc.Salt.Length }).Concat(rfc.Salt)
                .Concat(new byte[] { (byte)aes.IV.Length }).Concat(aes.IV)
                .Concat(encrypted).ToArray();
            File.WriteAllBytes(encryptDialog.FileName, toWrite);
        }

        private void DecryptFile(object sender, EventArgs e)
        {
            var dialogResult = decryptDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
                return;

            byte[] toRead = File.ReadAllBytes(decryptDialog.FileName);
            try
            {
                string decrypted;

                using (var ms = new MemoryStream(toRead))
                {
                    int saltLength = ms.ReadByte();
                    byte[] salt = new byte[saltLength];
                    ms.Read(salt, 0, saltLength);
                    int ivLength = ms.ReadByte();
                    byte[] iv = new byte[ivLength];
                    ms.Read(iv, 0, ivLength);
                    var rfc = new Rfc2898DeriveBytes(textBoxPassword.Text, salt, 1024);
                    var aes = Aes.Create();
                    aes.Key = rfc.GetBytes(16);
                    aes.IV = iv;

                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            decrypted = sr.ReadToEnd();
                        }
                    }
                }

                textBoxContents.Text = decrypted;
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Password is not valid.");
            }
        }
    }
}
