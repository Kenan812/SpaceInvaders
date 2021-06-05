using SpaceInvaders.Ammos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    abstract class ShipType
    {
        // To Display
        // Set Cursor position to (PosX, PosY)
        // Read until "\n", Print 
        // Set Cursor Position (PosX, PosY + 1)
        // Read until "\n", Print 
        // Repeat
        public string Appearance { get; set; }



        // Different for each ship type

        public int ShipWidth { get; set; }   

        public int ShipHeight { get; set; }


        public int HealthPoints { get; set; }  // Represent HP of each type of ship


        // List of all ammos ship can use
        public List<Ammo> ShipArmament { get; set; }  // Sets in each Ship Type respectively


        public ShipType() 
        {
            Appearance = "";
            ShipArmament = new List<Ammo>();
        }


        // Basically spawns all ammo that ship can shoot
        // ShipX, ShipY - (PosX, PosY) if the ship
        // Used in Ship.PlayerShip||EnemyShip.Shoot()
        abstract public void SpawnAllAmmo(int ShipX, int ShipY);

    }
}
