using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cthulhu_Decryption_2
{
    class TextHandler
    {
        public static List<string> ParseString(string inputString)
        {
            List<string> parsedString = new List<string>(inputString.Length);
            int x = 1;
            inputString = inputString.ToUpper();

            foreach (char c in inputString)
            {
                string testString = Convert.ToString(c);
                parsedString.Add(Convert.ToString(c));
                x++;
            }

            return parsedString;
        }


        public static string EncryptString(List<string> parsedString, KeyGen encKey)
        {
            string encryptedString = string.Empty;
            string orderString = string.Empty;

            //Create the order lead tag
            for (int y = 0; y < encKey.order.Count(); y++)
            {
                if (Convert.ToString(encKey.order[y]).Length < 2)
                {
                    orderString = "0" + Convert.ToString(encKey.order[y]);
                }
                else if (Convert.ToString(encKey.order[y]).Length == 2)
                {
                    orderString = Convert.ToString(encKey.order[y]);
                }
                else
                {
                    //Console.WriteLine("Bad order length");
                    break;
                }
                encryptedString = encryptedString + orderString;
                orderString = string.Empty;
            }

            //Create the message start tag
            encryptedString = encryptedString + "cthulhu";

            //Encrypt the characters in the parsed string
            foreach (string c in parsedString)
            {
                for (int x = 0; x < encKey.order.Count(); x++)
                {
                    if (c == encKey.characters[x])
                    {
                        encryptedString = encryptedString + encKey.binary[x] + " ";
                        break;
                    }
                    else
                    {
                    }
                }
            }

            return encryptedString;

        }

        public static string Reader(string filePath) //Does not read...
        {
            string readText = File.ReadAllText(filePath);
            return readText;

        }

    }
}
