using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cthulhu_Decryption_2
{
    public partial class Decryptor : Form
    {
        public Decryptor()
        {
            InitializeComponent();
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "cthulhu Files (*.cthulhu)|*.cthulhu";
            string openFileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
            }

            Decryption decryptKey = Decryption.keyGet(openFileName);
            string[] binaryString = Decryption.binaryGet(openFileName);
            tb_Output.Text = Decryption.Decrypt(decryptKey,binaryString);
            //Console.WriteLine(Decryption.Decrypt(decryptKey, binaryString));
        }
    }
}
