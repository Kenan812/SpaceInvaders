using SpaceInvaders.Ammos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    class PlayerShip_Type_0 : PlayerShipTypes
    {
        public PlayerShip_Type_0() : base()
        {
            Appearance = "   -\n  ---\n -----\n-------\n";
            HealthPoints = 100;
            ShipWidth = 7;
            ShipHeight = 4;
            ShipMobility = 5;
            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
        }


        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 3, ShipY);
        }
    }
}
