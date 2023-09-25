using System;

namespace EncryptDecrypt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EncryptDecrypt q = new EncryptDecrypt();
            int s = 'A' ^ 'U';
            Console.WriteLine("sifrovano" + (char)s + ':'+s);
            Console.WriteLine("desifrovano"+(s^'A'));
            Console.WriteLine();
            string value = "Pepa";
            string key = "Josef";
            string crypted = q.Encrypt(value, key);
            Console.WriteLine(crypted);
            Console.WriteLine(q.Decrypt(crypted,key));
        }
    }

    class EncryptDecrypt
    {
        
        public string Encrypt(string input, string key)
        {
            string output = "";
            input = input.Replace(" ","");
            input = input.ToUpper();
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (j>=key.Length)
                {
                    j = 0;
                }
                output += (char)(input[i]^key[j]);
                j++;
            }
            
            return output;
        }

        public string Decrypt(string input, string key)
        {
            string output = "";
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (j>=key.Length)
                {
                    j = 0;
                }
                output += (char)(input[i]^key[j]);
                j++;
            }
            return output;
        }
    }
}
