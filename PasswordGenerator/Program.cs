using System;
using System.Security.Cryptography;
using System.Threading;
using System.Text;

/*

This small program is mine.
You can copy the code and make from this your own program.

*/




class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine("\n  Password Generator Service\n");
        bool hashing = false;

        while (true)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\r  Use hashing (y/n): ");
            Console.ForegroundColor = ConsoleColor.Blue;

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Y)
            {
                // clear line and continue
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  Random bytes will be hashed!");
                Thread.Sleep(1100);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));
                hashing = true;
                break;
            }
            else if (key == ConsoleKey.N)
            {
                // clear line and continue
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("  No hashing will be used!");
                Thread.Sleep(1100);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));
                break;
            }

        }


        int len = 0;

        if (!hashing)
        {

            string inp = GetInput("Length: ");
            Console.WriteLine("\n");

            if (!int.TryParse(inp, out len)) len = 18;

            if (len < 5 || len > 60) len = 18; // invalid length
            // parsing value to integer

        }

        for (int i = 0; i <= 9; i++)
        {
            if (!hashing)
            {
                string chars = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!?,.-:_<>/*+=\%;~";
                byte[] data = new byte[len];
                using (RandomNumberGenerator crypto = RandomNumberGenerator.Create())
                {
                    crypto.GetBytes(data);
                }

                string result = null;
                foreach (byte b in data) result += chars[b % (chars.Length)];

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"   {i}. ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(result);
            }
            else
            {
                // using hashing

                byte[] bytes = new byte[1024];
                var rng = RandomNumberGenerator.Create();
                rng.GetBytes(bytes);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"   {i}. ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(BitConverter.ToString(SHA1.Create().ComputeHash(bytes)).Replace("-", "").ToLower());
                //Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }

            Thread.Sleep(100);
        }


        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n\n  Job has been finished!");
        Environment.Exit(0);
    }

    private static string GetInput(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("  " + prompt);
        Console.ForegroundColor = ConsoleColor.Blue;
        return Console.ReadLine();
    }

}
