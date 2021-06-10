using System;
using System.Text;
using SpaceInvaders.AllShipTypes;


namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting of Encoding, Buffer Size, Console Color

            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BufferWidth = 200;


            // Choosing game difficulty
            int diff = ChooseGameDifficulty();

            Console.ForegroundColor = ConsoleColor.White;


            // Playing game

            Game game = new Game(diff);

            game.Play();





        }


        // Returns 1 if diff is easy
        // Returns 2 if diff is medium
        // Returns 3 if diff is hard
        static int ChooseGameDifficulty()
        {
            int c = 1;

            Console.WriteLine("Use '↓' or '↑' to navigate\nPress 'Enter' to confirm chioce\nPress 'esc' to quit playing\n");

            Console.WriteLine("Choose game difficulty:");


            Console.WriteLine("  Easy");
            Console.WriteLine("  Medium");
            Console.WriteLine("  Hard");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 5);
            Console.Write("►");

            while (true)
            {
                ConsoleKeyInfo k =  Console.ReadKey();

                if (k.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (k.Key == ConsoleKey.DownArrow && c < 3)
                {
                    Console.SetCursorPosition(0, c + 4);
                    Console.Write(" ");
                    c++;
                    Console.SetCursorPosition(0, c + 4);
                    Console.Write("►");
                }
                else if (k.Key == ConsoleKey.UpArrow && c > 1)
                {
                    Console.SetCursorPosition(0, c + 4);
                    Console.Write(" ");
                    c--;
                    Console.SetCursorPosition(0, c + 4);
                    Console.Write("►");
                }
                else if (k.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, c + 5);
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.SetCursorPosition(1, c + 4);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            return c;
        }



    }
}

