using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Ammos
{
    class NRC_131_ox : Ammo
    {
        // (x, y) = initial position of the bullet(when it was shot)
        public NRC_131_ox(ConsoleKey movingDirection)
        {
            Name = "NRC_131_ox";
            Appearance = "֎";

            Damage = 100;

            SecondsToMove = 0.05;

            AmmoMovingDirection = movingDirection;
        }

        #region Moving Bullet


        public override void AmmoClearAppearance()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }


        public override void AmmoMove()
        {
            if (AmmoMovingDirection == ConsoleKey.UpArrow)
                Y--;

            else if (AmmoMovingDirection == ConsoleKey.DownArrow)
                Y++;

        }


        public override void AmmoPrint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Appearance);
        }


        #endregion


    }
}
