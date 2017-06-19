using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cthulhu_Encrypter
{
    class Decryption  //I thought about using KeyGen as a base class here, but in the end I wasn't sure it actually saved me any effort.
    {

        public string[] characters { get; set; }
        public int[] order { get; set; }
        public string[] binary { get; set; }


        public Decryption(string[] characters, int[] order, string[] binary)
        {
            this.characters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "+", "-", "=", "/", "?", "<", ">", ",", ".", ":", ";", " " };
            int charCount = this.characters.Count();
            int x = 0;
            int[] orderPopulator = new int[charCount];
            string[] binaryPopulator = new string[charCount];
            while (x < charCount)
            {
                orderPopulator[x] = 0;
                binaryPopulator[x] = "na";
                x++;
            }
            this.order = orderPopulator;
            this.binary = binaryPopulator;
        }

        public static Decryption keyGet(string filename)
        {
            string readText = TextHandler.Reader(filename);
            Decryption decryptKey = new Decryption(null, null, null);
            int orderCount = readText.IndexOf("cthulhu");
            int x = 0;
            int[] orders = new int[decryptKey.characters.Count()];
            while (x < orderCount/2)
            {
                string orderString = readText.Substring(0, 2);  //reads next two-digit number from text header
                string tempString = string.Empty;
                int lengthHolder = tempString.Length;
                int addZeros = 0;
                
                if (orderString.IndexOf("0") == 0)  //check for leading zero on order number
                {
                    orderString = orderString.Substring(1);  //if there is a leading zero remove it
                }
                else { }

                decryptKey.order[x] = Convert.ToInt32(orderString);  //converts order above to int

                //create binary value from order int
                tempString = Convert.ToString(decryptKey.order[x], 2);

                //convert tempString (binary equivalent of order) to 6-digit binary with leading zeroes
                if (tempString.Length == 6) { }  //already ok
                
                else if (tempString.Length < 6)  //add leading zeroes
                {
                    lengthHolder = tempString.Length;
                    for (addZeros = 0; addZeros < (6 - lengthHolder); addZeros++)
                    {
                        tempString = "0" + tempString;
                    }
                }
                decryptKey.binary[x] = tempString;
                tempString = string.Empty;
                lengthHolder = 0;                
                x++;
                readText = readText.Substring(2);
            }
            
            return decryptKey;
        }

        public static string[] binaryGet(string filename)
        {
            string readText = TextHandler.Reader(filename);
            //Console.WriteLine("Text is: " + readText);

            //parse the binary portion
            //find start of binary
            int binaryStart = readText.IndexOf("cthulhu") + 7;
            string binaryString = readText.Substring(binaryStart);  //get the binary string from the file text
            int x = binaryString.Length;
            int pos = 0;
            string[] binaryParsed = new string[(x+1)/6];
            while (x > 0)
            {
                string currentBinary = binaryString.Substring(0,6);
                binaryParsed[pos] = currentBinary;
                pos++;
                if (x < 7)
                {
                    break;
                }
                else if (x >= 7)
                {
                    binaryString = binaryString.Substring(binaryString.IndexOf(" ") + 1);
                    x = binaryString.Length;
                }   
            }
                        
            return binaryParsed;
        }

        public static string Decrypt(Decryption decryptKey, string[] binaries)
        {
            string plaintextString = string.Empty;

            for (int x = 0; x < binaries.Count(); x++)
            {
                for (int y = 0; y < decryptKey.binary.Count(); y++)
                {
                    bool testBool = binaries[x] == decryptKey.binary[y];
                    if (binaries[x] == decryptKey.binary[y])
                    {   
                        plaintextString = plaintextString + decryptKey.characters[y];
                        break;
                    }
                    else { }
                }
            }

            return plaintextString;
        }
    }
}
