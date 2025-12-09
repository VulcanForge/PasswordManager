using System.Security.Cryptography;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent ();
        }

        private void EncryptFile (object sender, EventArgs e)
        {
            var dialogResult = encryptDialog.ShowDialog ();

            if (dialogResult != DialogResult.OK)
                return;


            using (var aes = Aes.Create ())
            {
                byte[] salt = RandomNumberGenerator.GetBytes (64);
                aes.Key = Rfc2898DeriveBytes.Pbkdf2 (textBoxPassword.Text, salt, 300000, HashAlgorithmName.SHA512, 32);
                byte[] encrypted;

                using (var ms = new MemoryStream ())
                {
                    using (var cs = new CryptoStream (ms, aes.CreateEncryptor (), CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter (cs))
                        {
                            sw.Write (textBoxContents.Text);
                        }
                        encrypted = ms.ToArray ();
                    }
                }

                byte[] toWrite = (new byte[] { (byte)salt.Length }).Concat (salt)
                    .Concat ([(byte)aes.IV.Length]).Concat (aes.IV)
                    .Concat (encrypted).ToArray ();
                File.WriteAllBytes (encryptDialog.FileName, toWrite);
            }
        }

        private void DecryptFile (object sender, EventArgs e)
        {
            var dialogResult = decryptDialog.ShowDialog ();

            if (dialogResult != DialogResult.OK)
                return;

            byte[] toRead = File.ReadAllBytes (decryptDialog.FileName);

            try
            {
                string decrypted;

                using (var ms = new MemoryStream (toRead))
                {
                    int saltLength = ms.ReadByte ();
                    byte[] salt = new byte[saltLength];
                    ms.Read (salt, 0, saltLength);
                    int ivLength = ms.ReadByte ();
                    byte[] iv = new byte[ivLength];
                    ms.Read (iv, 0, ivLength);

                    using (var aes = Aes.Create ())
                    {
                        aes.Key = Rfc2898DeriveBytes.Pbkdf2 (textBoxPassword.Text, salt, 300000, HashAlgorithmName.SHA512, 32);
                        aes.IV = iv;

                        using (var cs = new CryptoStream (ms, aes.CreateDecryptor (), CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader (cs))
                            {
                                decrypted = sr.ReadToEnd ();
                            }
                        }
                    }
                }

                textBoxContents.Text = decrypted;
            }
            catch (CryptographicException)
            {
                MessageBox.Show ("Password is not valid.");
            }
        }
    }
}
