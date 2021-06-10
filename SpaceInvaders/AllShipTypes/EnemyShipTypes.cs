using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{

    /*   Common for all enemy ships    */

    abstract class EnemyShipTypes : ShipType
    {
        public ConsoleKey ShipMainMovingDirection { get; set; }

        public double SecondsToMove { get; set; }  // Indicates number of seconds before each move

        public double ShipTimeToShoot { get; set; }


        public static int TotalNumberOfEnemyShipTypes { get; set; }  // Change each time new enemy ship type added 

        public EnemyShipTypes() : base() { TotalNumberOfEnemyShipTypes = 3; }

        
        // Should be modified each time enemy ship type added
        public static EnemyShipTypes GetRandomEnemyShip()
        {
            Random rnd = new Random();

            int i = rnd.Next(1, TotalNumberOfEnemyShipTypes + 1);


            switch (i)
            {
                case 1:
                    return new EnemyShip_Type_1();

                case 2:
                    return new EnemyShip_Type_2();

                case 3:
                    return new EnemyShip_Type_3();


                default:
                    break;
            }

            return new EnemyShip_Type_0();
        }


    }
}
