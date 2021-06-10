using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Ammos;
using System.Threading.Tasks;

/* Enhanced Ship */

// Shoots using enhanced bullet
// 1 canon only
// HP = 150

namespace SpaceInvaders.AllShipTypes
{
    class EnemyShip_Type_2 : EnemyShipTypes
    {
        public EnemyShip_Type_2()
        {
            Appearance = "  ▲   ▲  \n {[o0o]} \nXs ─── sX\n   \\ /\n";
            HealthPoints = 150;

            ShipWidth = 9;
            ShipHeight = 4;

            ShipMainMovingDirection = ConsoleKey.DownArrow;

            ShipArmament.Add(new EnhancedBullet(ConsoleKey.DownArrow));

            SecondsToMove = 1;
            ShipTimeToShoot = 3;
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 4, ShipY + 4);
        }
    }
}
