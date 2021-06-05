using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Ammos
{
    abstract class Ammo : ICloneable
    {
        public string Name { get; set; }

        public string Appearance { get; set; }  // covers 1 console cell
        
        public int Damage { get; set; }

        public double SecondsToMove { get; set; }  // Represents number of seconds before each move


        public int X { get; set; }

        public int Y { get; set; }


        public ConsoleKey AmmoMovingDirection { get; set; }



        public void SetAmmoSpawnPosition(int x, int y)
        {
            X = x;
            Y = y;
        }



        #region Moving an Ammo

        /*  
           Order to use:
                1) AmmoClearAppearance
                2) AmmoMove
                3) AmmoPrint
         */


        // Moves ammo after being shot
        abstract public void AmmoMove();


        abstract public void AmmoPrint();


        abstract public void AmmoClearAppearance();



        #endregion


        public object Clone()
        {
            Ammo clone = (Ammo)this.MemberwiseClone();

            return clone;
        }




    }
}
