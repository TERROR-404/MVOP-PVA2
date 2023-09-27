using System;
using System.IO;

namespace EncryptDecrypt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //uloha 6
            
            /*int s = 'A' ^ 'U';
            Console.WriteLine("sifrovano" + (char)s + ':'+s);
            Console.WriteLine("desifrovano"+(s^'A'));
            Console.WriteLine();*/
            EncryptDecrypt q = new EncryptDecrypt();
            
            Console.Write("Zadejte text: ");
            string value = Console.ReadLine();
            Console.Write("Zadejte klíč: ");
            string key = Console.ReadLine();
            Console.WriteLine(q.Encrypt(value, key));
            Console.WriteLine(q.Decrypt(key));
        }
    }

    class EncryptDecrypt
    {
        public string Encrypt(string input, string key)
        {
            File.Create("crypted.cry").Close(); // soubor se nachazi na C:\Users\cmerd\RiderProjects\EncryptDecrypt\EncryptDecrypt\bin\Debug
            
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
            
            using(StreamWriter sw = new StreamWriter("crypted.cry"))
            {
                sw.WriteLine(output);
            }
            
            return output;
        }

        public string Decrypt(string key)
        {
            string input = "";
            using(StreamReader sr = new StreamReader("crypted.cry"))
            {
                input = sr.ReadLine();
            }
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
