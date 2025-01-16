using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassLight
{   

    public partial class Form1 : Form
    {
        private Dictionary<string, string> passwordCache = new Dictionary<string, string>();
        private readonly string secretKey = SecretKey.Get_the_secretKey(); 

        public Form1()
        {
            InitializeComponent();
            SetupNumericUpDown();
            LoadExistingPasswords();
            ApplyCustomTheme();
            this.ActiveControl = txtCommand;

            // Add double-click event handler for the ListBox
            //Pass_listBox.DoubleClick += Pass_listBox_DoubleClick;

        }
        private void Pass_listBox_DoubleClick(object sender, EventArgs e)
        {
            if (Pass_listBox.SelectedItem == null) return;

            string selectedEntry = Pass_listBox.SelectedItem.ToString();
            string commandName = selectedEntry.Split(':')[0].Trim();

            try
            {
                string directoryPath = @"C:\Passwords";
                string[] matchingFiles = Directory.GetFiles(directoryPath, "*.txt")
                    .Where(file => file.Contains(commandName))
                    .ToArray();

                if (matchingFiles.Length > 0)
                {
                    string filePath = matchingFiles[0];
                    string[] lines = File.ReadAllLines(filePath);

                    // Get the encrypted password from the file
                    string encryptedPassword = lines[1].Replace("pass: ", "").Trim();

                    // Decrypt the password
                    string decryptedPassword = AesOperation.DecryptString(encryptedPassword, secretKey);

                    using (PassView passViewForm = new PassView())
                    {
                        passViewForm.name_textBox.Text = commandName;
                        passViewForm.Password_textBox.Text = "Password : " + decryptedPassword;

                        // Add copy functionality to the Copy button
                        passViewForm.Copy_button.Click += (s, ev) =>
                        {
                            Clipboard.SetText(decryptedPassword);
                            passViewForm.Copy_button.Text = "Copied !";

                        };

                        // Set Close button DialogResult
                        passViewForm.Close_button.DialogResult = DialogResult.OK;

                        passViewForm.ShowDialog(this);
                    }
                }
                else
                {
                    MessageBox.Show("No matching password files found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            txtCommand.Focus();

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.Enter:
                    btnGenerate.PerformClick();
                    e.Handled = true;
                    break;
            }
        }

        private void ApplyCustomTheme()
        {
            // Form background
            this.BackColor = ColorTranslator.FromHtml("#121212");

            // Dark elements (background color #202020)
            Pass_listBox.BackColor = ColorTranslator.FromHtml("#202020");
            txtCommand.BackColor = ColorTranslator.FromHtml("#202020");
            txtPassword.BackColor = ColorTranslator.FromHtml("#202020");
            numericUpDown1.BackColor = ColorTranslator.FromHtml("#202020");

            // White text (#FFFFFF)
            Pass_listBox.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            txtCommand.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            txtPassword.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            numericUpDown1.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            lblStatus.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            // Generate button purple (#BB86FC)
            btnGenerate.BackColor = ColorTranslator.FromHtml("#BB86FC");
            btnGenerate.FlatStyle = FlatStyle.Flat;
            //btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            // Optional: Remove white border from NumericUpDown
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;

            // Optional: Remove white border from TextBoxes
            txtCommand.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetupNumericUpDown()
        {
            // Configure NumericUpDown initial settings
            numericUpDown1.Minimum = 12;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 25;    // Default value
        }


        //private readonly string secretKey = Guid.NewGuid().ToString(); // Generate unique key per session



        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string command = txtCommand.Text.Trim();
                if (string.IsNullOrEmpty(command))
                {
                    MessageBox.Show("Please enter a Title First!\nFill the Title Field.", "Error empty Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string directoryPath = @"C:\Passwords";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Check if a file with this name already exists
                string[] existingFiles = Directory.GetFiles(directoryPath, "*.txt")
                    .Where(file => Path.GetFileName(file).StartsWith(command + "_"))
                    .ToArray();

                if (existingFiles.Length > 0)
                {
                    MessageBox.Show("A password with this name already exists. Please use a different name.",
                                    "Duplicate Name",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                int passwordLength = (int)numericUpDown1.Value;
                string randomString = GenerateRandomString(passwordLength);

                // Pass the secretKey when encrypting
                string encryptedPassword = AesOperation.EncryptString(randomString, secretKey);

                string fileName = Path.Combine(directoryPath, $"{command}_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                string fileContent = $"name: {command}\npass: {encryptedPassword}\n--------------------------------";
                File.WriteAllText(fileName, fileContent);

                Pass_listBox.Items.Insert(0, $"{command}: [Double-click to view]");
                Clipboard.SetText(randomString);
                txtPassword.Text = randomString;
                lblStatus.Text = $"Copied !";
                lblStatus.ForeColor = Color.Cyan;  
                txtCommand.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadExistingPasswords()
        {
            string directoryPath = @"C:\Passwords";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Pass_listBox.Items.Clear();
            string[] files = Directory.GetFiles(directoryPath, "*.txt");
            foreach (string file in files)
            {
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    if (lines.Length >= 2)
                    {
                        string name = lines[0].Replace("name: ", "").Trim();
                        Pass_listBox.Items.Add($"{name}: [Double-click to view]");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading file {file}: {ex.Message}");
                }
            }
        }

        //private void LoadExistingPasswords()
        //{
        //    string directoryPath = @"C:\Passwords";
        //    if (Directory.Exists(directoryPath))
        //    {
        //        string[] files = Directory.GetFiles(directoryPath, "*.txt");
        //        foreach (string file in files)
        //        {
        //            string[] lines = File.ReadAllLines(file);
        //            if (lines.Length >= 2)
        //            {
        //                string name = lines[0].Replace("name: ", "");
        //                Pass_listBox.Items.Add($"{name}: [Protected]");
        //            }
        //        }
        //    }
        //}


        private string GenerateRandomString(int length)
        {
            string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string specialCharacters = "@#$%^-+.)_;+:'&*.,/?!(){}[]";
            string specialCharacters2 = "@#$%^-+.;:'&*.,/?_!(){+}=-)[]";

            string allCharacters = upperCaseLetters + lowerCaseLetters + numbers + specialCharacters2 + specialCharacters;
            Random random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = allCharacters[random.Next(allCharacters.Length)];
            }

            return new string(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/mahziyar-azz/Pass-Light",
                UseShellExecute = true
            });
        }

    }


    public class AesOperation
    {
        private static readonly byte[] Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private const int KeySize = 256;
        private const int IterationCount = 50000;

        public static string EncryptString(string plainText, string secretKey)
        {
            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                using (Aes aes = Aes.Create())
                {
                    using (var key = new Rfc2898DeriveBytes(secretKey, Salt, IterationCount, HashAlgorithmName.SHA256))
                    {
                        aes.KeySize = KeySize;
                        aes.Key = key.GetBytes(aes.KeySize / 8);
                        aes.IV = key.GetBytes(aes.BlockSize / 8);
                        aes.Mode = CipherMode.CBC;
                        aes.Padding = PaddingMode.PKCS7;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(plainBytes, 0, plainBytes.Length);
                                cs.FlushFinalBlock();
                            }
                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Encryption failed", ex);
            }
        }


        public static string DecryptString(string cipherText, string secretKey)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    using (var key = new Rfc2898DeriveBytes(secretKey, Salt, IterationCount, HashAlgorithmName.SHA256))
                    {
                        aes.KeySize = KeySize;
                        aes.Key = key.GetBytes(aes.KeySize / 8);
                        aes.IV = key.GetBytes(aes.BlockSize / 8);
                        aes.Mode = CipherMode.CBC;
                        aes.Padding = PaddingMode.PKCS7;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.FlushFinalBlock();
                            }
                            return Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Decryption failed", ex);
            }
        }


    }

}
