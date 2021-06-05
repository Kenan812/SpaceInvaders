using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Interfaces;
using System.Collections.Generic;
using System.Threading;
using SpaceInvaders.AllShipTypes;

namespace SpaceInvaders
{
    class EnemyShip : Ship, IEnemy, IShootable
    {


        /* Used to identify moving direction */

        public ConsoleKey MainMovingDirection { get; set; }

        public ConsoleKey AdditionalMovingDirection { get; set; }


        public EnemyShipTypes ShipType { get; set; }


        public double TimeToShoot { get; set; }

        public DateTime PreviousMoveTime { get; set; }

        public DateTime PreviousShootTime { get; set; }

        #region Constructers


        public EnemyShip(EnemyShipTypes shipType) : base(shipType.ShipWidth, shipType.ShipHeight, shipType.HealthPoints) 
        {
            ShipType = shipType;
            MainMovingDirection = shipType.ShipMainMovingDirection;
            TimeToShoot = shipType.ShipTimeToShoot;
            PreviousMoveTime = DateTime.Now;
            PreviousShootTime = DateTime.Now;
        }

        public EnemyShip() : base() { }


        #endregion


        #region Moving Ship


        public override void ClearAppearance()
        {
            if (PosX != -1 && PosY != -1)
            {
                    
                Console.SetCursorPosition(PosX, PosY);
                for (int j = 0; j < Width; j++)
                    Console.Write(" ");
                    
            }
        }


        public override void Move(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.DownArrow)
            {
                if (PosY + Height < 39) PosY++;
            }

            else if (consoleKey == ConsoleKey.UpArrow)
            {
                if (PosY > 1) PosY--;
            }

            else if (consoleKey == ConsoleKey.LeftArrow)
            {
                if (PosX > 35) PosX--;
            }

            else if (consoleKey == ConsoleKey.RightArrow)
            {
                if (PosX < 135 - Width - 1) PosX++;
            }
        }


        public override void PrintShip()
        {
            if (PosX != -1 && PosY != -1)
            {
                if (HP <= 33)
                    Console.ForegroundColor = ConsoleColor.Red;


                string[] s = ShipType.Appearance.Split('\n');

                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(PosX, PosY + i);
                    Console.Write(s[i]);
                }

                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        
        #endregion


        // NEEDS tO BE REWRITTEN
        // Spawns ship and make it appear on the board
        public void Appear()
        {
            List<int> pos = GenerateStartPostion();
            SpawnShip(pos[0], pos[1]);

           // DateTime time = DateTime.Now;
           //
           // if (PosX != -1 && PosY != -1)
           // {
           //     string[] s = ShipType.Appearance.Split('\n');
           //     int idx;
           //     for (int i = Height - 1; i >= 0; i-- )
           //     {
           //         if (time.Subtract(prevTime).TotalSeconds >= ShipType.SecondsToMove)
           //         {
           //             idx = i;
           //             for (int j = 0; j < Height - i; j++)
           //             {
           //                 Console.SetCursorPosition(PosX, j + 1);
           //                 Console.Write(s[idx]);
           //                 idx++;
           //             }
           //         }
           //     }
           // }
           //
           //
           // return false;

            //Console.SetCursorPosition(PosX, 1);
            //Console.Write("   -");
            //Thread.Sleep(500);


            //Console.SetCursorPosition(PosX, 1);
            //Console.Write("  ---");
            //Console.SetCursorPosition(PosX, 2);
            //Console.Write("   -");
            //Thread.Sleep(500);


            //Console.SetCursorPosition(PosX, 1);
            //Console.Write(" -----");
            //Console.SetCursorPosition(PosX, 2);
            //Console.Write("  ---");
            //Console.SetCursorPosition(PosX, 3);
            //Console.Write("   -");
            //Thread.Sleep(500);


            //Console.SetCursorPosition(PosX, 1);
            //Console.Write("-------");
            //Console.SetCursorPosition(PosX, 2);
            //Console.Write(" -----");
            //Console.SetCursorPosition(PosX, 3);
            //Console.Write("  ---");
            //Console.SetCursorPosition(PosX, 4);
            //Console.Write("   -");
            //Thread.Sleep(500);

        }



        // When reaches the lower bound of the board
        public void Disappear()
        {
            if (PosX != -1 && PosY != -1)
            {
                for (int i = PosY; i <= PosY + Height; i++)
                {
                    Console.SetCursorPosition(PosX, i);
                    for (int j = 0; j < Width; j++)
                        Console.Write(" ");
                }
            }
        }


        // Generates start(top left) position of enemy ship
        // Returns list of positions
        public List<int> GenerateStartPostion()
        {
            List<int> pos = new List<int>();

            Random rnd = new Random();

            // Generate start x 
            pos.Add(rnd.Next(35, 135 - Width));


            // Generate start y
            pos.Add(1);

            return pos;
        }




        public void Shoot()
        {
            ShipType.SpawnAllAmmo(PosX, PosY);
        }




    }
}
