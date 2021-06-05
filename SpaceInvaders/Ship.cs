using SpaceInvaders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 Board Length: 100
 
 Possible ship placement 
 
 X:   Start: 35
      End: 135

 Y:   Start: 1
      End: 39

 */


namespace SpaceInvaders
{
    abstract class Ship
    {
        public int Width { get; set; }
        public int Height { get; set; }


        // Points at top left position of ship hit box
        public int PosX { get; set; }
        public int PosY { get; set; }


        public int HP { get; set; }


        #region Constucters

        // Pos = -1: means no ship on board

        public Ship(int width, int height, int hp)
        {
            Width = width;
            Height = height;
            PosX = -1;  
            PosY = -1;
            HP = hp;
        }


        public Ship()
        {
            HP = 1;
            Width = 0;
            Height = 0;
            PosX = -1;
            PosY = -1;
        }


        #endregion



        // Spawns ship at provided position(x, y) - position of top left
        // Assignes (PosX, PosY) = (x, y)
        // Doesn't print ship
        public void SpawnShip(int x, int y)
        {
            try
            {
                if ((x >= 35 && x <= 135 - Width + 1) && (y >= 1 && y <= 39 - Height + 1))
                {
                    PosX = x;
                    PosY = y;
                }

                else
                {
                    Console.SetCursorPosition(0, 50);
                    Console.WriteLine("Unable to place ship");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine("Wrong position provided");
                Console.WriteLine($"\nError: {e.Message}");
                Console.WriteLine($"\nStack Trace: {e.StackTrace}");
                Console.BufferWidth = 200;
                throw;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"\nUnhadled Error: {e.Message}");
                Console.WriteLine($"\nStack Trace: {e.StackTrace}");
                throw;
            }
        }



        #region Moving Ship


        /* 
             Moving order: ClearAppearance, Move, PrintShip
         */


        // Clears previous appearance of ship(all hit box)
        // Used before Move()
        abstract public void ClearAppearance();

        
        // Moves the ship according to pressed key
        abstract public void Move(ConsoleKey consoleKey);


        // Prints ship according to its type at position (PosX, PosY)
        abstract public void PrintShip();


        #endregion


    }
}
