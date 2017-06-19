using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Cthulhu_Encrypter
{
    public partial class Encryptor : Form
    {
        string encryptedString = string.Empty;
        public Encryptor()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            KeyGen NewEncryptor = new KeyGen(null, null, null);
            string encryptedString = string.Empty;
            NewEncryptor = KeyGen.EncryptRand(NewEncryptor);

            for (int x = 0; x < NewEncryptor.characters.Count(); x++)
            {
                //Console.WriteLine(NewEncryptor.characters[x] + " " + NewEncryptor.order[x] + " " + NewEncryptor.binary[x]);
            }

            List<string> testListString = TextHandler.ParseString(tb_Input.Text);
            encryptedString = TextHandler.EncryptString(testListString, NewEncryptor);
            tb_Input.Clear();
            //Console.WriteLine(encryptedString);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "cthulhu Files (*.cthulhu)|*.cthulhu";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, encryptedString);
            }
            else { }

        }
    }
}
