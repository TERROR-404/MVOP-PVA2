using System.Security.Cryptography;
using System.Text;

namespace PassMNG
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Cypher.Auth())
            {
                return;
            }
            if (args.Length == 0)
            {
                Cypher.PrintAll();
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                string service = args[i];
                Cypher.New(service);
            }
        }
    }

    class Cypher
    {
        private static byte[] mainHash = SHA256.HashData(Encoding.UTF8.GetBytes("MasterPassword"));

        public static bool Auth()
        {
            Console.Write("Enter the password: ");
            try
            {
                string? word = Console.ReadLine();
                if (word == null)
                {
                    return false;
                }
                byte[] passwordHash = SHA256.HashData(Encoding.UTF8.GetBytes(word));
                using (
                    var reader = new StreamReader(
                        Environment.CurrentDirectory + $"/pwds/{Convert.ToHexString(mainHash)}.txt"
                    )
                )
                {
                    string? line = reader.ReadLine();
                    if (line == null)
                    {
                        return false;
                    }
                    byte[] masterHash = Convert.FromHexString(line);
                    if (masterHash.SequenceEqual(passwordHash))
                    {
                        return true;
                    }
                    reader.Close();
                }
                if (mainHash.SequenceEqual(passwordHash))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid input.");
                Console.ResetColor();
            }
            return false;
        }

        public static void New(string service)
        {
            string pwd =
                $"J{service[service.Length - 3]}jbsl{service[service.Length - 2]}42{Char.ToUpper(service[service.Length - 1])}73";
            byte[] pwdBytes = Encoding.UTF8.GetBytes(pwd);
            byte[] pwdHash = SHA256.HashData(pwdBytes);
            string path =
                Environment.CurrentDirectory + $"/pwds/{Convert.ToHexString(pwdHash)}.txt";
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    Console.Write($"{service}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(reader.ReadLine());
                    Console.ResetColor();
                    reader.Close();
                }
            }
            else
            {
                using (var writer = new StreamWriter(path, true))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(service);
                    Console.ResetColor();
                    Console.Write(" new password: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(pwd);
                    Console.ResetColor();
                    writer.WriteLine(pwd);
                    writer.Close();
                }
            }
        }

        public static void PrintAll()
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory + "/pwds");
            foreach (string filei in files)
            {
                if (
                    Path.GetFileName(filei)
                    == "73567E977FBEB14CB66974484E2CF1AE7596B8744BDB7DDFD33457A0A44D5E44.txt"
                )
                {
                    continue;
                }
                using (var reader = new StreamReader(filei))
                {
                    string? line = reader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }
                    Console.Write($"{line[1]}{line[6]}{Char.ToLower(line[9])}: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(line);
                    Console.ResetColor();
                    reader.Close();
                }
            }
        }
    }
}
