using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    
    /*   Common for all player ships    */


    abstract class PlayerShipTypes : ShipType
    {
        public int ShipMobility { get; set; }  // speed along X (number of position / click)


        public PlayerShipTypes() : base() { }
    }
}
