using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cthulhu_Encrypter
{
    class KeyGen
    {
        public string[] characters { get; set; }
        public int[] order { get; set; }
        public string[] binary { get; set; }

        public KeyGen(string[] characters, int[] order, string[] binary)
        {
            this.characters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#","$","%","^","&","*","(",")","_","+","-","=","/","?","<",">",",",".",":",";"," "};
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

        public static KeyGen EncryptRand(KeyGen target)
        {
            int charCount = target.characters.Count();
            Random rng = new Random();
            int x = 0;
            
            while (x < charCount)
            {
                bool orderCheck = true;
                string tempString = string.Empty;
                int addZeros = 0;
                int lengthHolder = 0;
                if (x == 0)
                {
                    target.order[x] = rng.Next(1, charCount + 1);
                    tempString = Convert.ToString(target.order[x], 2);

                    if (tempString.Length == 6)
                    {
                        
                    }
                    else if (tempString.Length < 6)
                    {
                        lengthHolder = tempString.Length;
                        for (addZeros = 0; addZeros < (6 - lengthHolder); addZeros++)
                        {
                            tempString = "0" + tempString;
                        }
                    }
                    target.binary[x] = tempString;
                    tempString = string.Empty;
                    lengthHolder = 0;                    
                    x++;
                }
                else if (x > 0)
                {
                    int nextValue = rng.Next(1, charCount + 1);                    
                    for (int y = 0; y < charCount; y++)
                    {
                        if (target.order[y] == nextValue)
                        {
                            orderCheck = false;
                            break;
                        }
                        else { }
                    }

                    if (orderCheck == true)
                    {
                        target.order[x] = nextValue;
                        tempString = Convert.ToString(target.order[x], 2);

                        if (tempString.Length == 6)
                        {

                        }
                        else if (tempString.Length < 6)
                        {
                            lengthHolder = tempString.Length;
                            for (addZeros = 0; addZeros < (6 - lengthHolder); addZeros++)
                            {
                                tempString = "0" + tempString;
                            }
                        }
                        target.binary[x] = tempString;
                        tempString = string.Empty;
                        lengthHolder = 0;
                        x++;
                    }
                    else { }
                }
                
            }
            
            return target;
        }

        public static KeyGen ExistingKey(int[] keyOrder)
        {
            KeyGen completedKey = new KeyGen(null, null, null);
            int charCount = completedKey.characters.Count();
            if (keyOrder.Count() != charCount)
            {
                throw new IndexOutOfRangeException();
            }

            for (int x = 0; x < charCount; x++)
            {
                completedKey.order[x] = keyOrder[x];
                completedKey.binary[x] = Convert.ToString(keyOrder[x], 2);
            }

            return completedKey;
        }

    }
}
