using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using SpaceInvaders.AllShipTypes;
using SpaceInvaders.Ammos;



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


            // Playing game

            Game game = new Game();

            game.Play();



            

        }
    
    }
}

