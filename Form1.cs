using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MD5_Salt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = MD5(MD5(textBox1.Text + textBox2.Text));
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "Type Something";
                label4.ForeColor = Color.Red;
                textBox3.Text = (String.Empty);
            }
            else
            {
                label4.Text = "Succesfully Hash";
                label4.ForeColor = Color.Green;
            }
        }

        string MD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(input));
            string output = BitConverter.ToString(bytes);
            return output.ToLower().Replace("-", String.Empty);
        }

        [STAThread]
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }
    }
}
