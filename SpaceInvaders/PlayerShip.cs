using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Interfaces;
using System.Collections.Generic;
using SpaceInvaders.AllShipTypes;

namespace SpaceInvaders
{
    class PlayerShip : Ship, IFriendly, IShootable
    {
        // max = 5
        public int Mobility { get; set; }  // speed along X (number of position / click)

        public PlayerShipTypes ShipType { get; set; }

        
        #region Consturctor


        public PlayerShip(PlayerShipTypes shipType) : base(shipType.ShipWidth, shipType.ShipHeight, shipType.HealthPoints) 
        {
            Mobility = shipType.ShipMobility;
            ShipType = shipType;
        }

        public PlayerShip() : base() { Mobility = 0; }


        #endregion


        
        #region Moving Ship


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


        public override void Move(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.UpArrow)
            {
                if (PosY > 1) PosY--;
            }

            else if (consoleKey == ConsoleKey.DownArrow)
            {
                if (PosY < 39 - Height)  PosY++; 
            }

            else if (consoleKey == ConsoleKey.LeftArrow)
            {
                if (PosX > (35 + Mobility)) PosX -= Mobility;
                else if (PosX > 35) PosX -= (PosX - 35);
            }

            else if (consoleKey == ConsoleKey.RightArrow)
            {
                if (PosX < 135 - (Width + 1) - Mobility) PosX += Mobility;
                else if (PosX < 135 - (Width + 1)) PosX += (135 - PosX - Width);
            }
        }


        public override void ClearAppearance()
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


        #endregion




        // Returns true if Player Ship hits enemy ship
        // Use after each Move()
        public bool CheckForShipHit(EnemyShip enemyShip)
        {
            // top left
            if (PosX >= enemyShip.PosX && PosX <= enemyShip.PosX + enemyShip.Width)
                if (PosY >= enemyShip.PosY && PosY <= enemyShip.PosY + enemyShip.Height)
                    return true;


            // top right
            if (PosX + Width >= enemyShip.PosX && PosX + Width <= enemyShip.PosX + enemyShip.Width)
                if ((PosY >= enemyShip.PosY) && (PosY <= enemyShip.PosY + enemyShip.Height))
                    return true;
            

            // bottom left
            if ((PosX >= enemyShip.PosX) && (PosX <= enemyShip.PosX + enemyShip.Width))
                if (((PosY + Height) >= enemyShip.PosY) && ((PosY + Height) <= enemyShip.PosY + enemyShip.Height))
                    return true;


            // bottom right
            if (((PosX + Width) >= enemyShip.PosX) && ((PosX + Width) <= enemyShip.PosX + enemyShip.Width))
                if (((PosY + Height) >= enemyShip.PosY) && ((PosY + Height) <= enemyShip.PosY + enemyShip.Height))
                    return true;

            return false;
        }



        public void Shoot()
        {
            ShipType.SpawnAllAmmo(PosX, PosY);
        }
    }
}
