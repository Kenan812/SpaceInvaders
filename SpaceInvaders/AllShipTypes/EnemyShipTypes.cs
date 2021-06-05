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

        public EnemyShipTypes() : base() { }
    }
}
