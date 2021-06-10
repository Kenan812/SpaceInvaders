using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Ammos;
using System.Threading.Tasks;


/* Standart ship type */

// Shoots using standart bullet
// HP = 100
// 1 canon only

namespace SpaceInvaders.AllShipTypes
{
    class EnemyShip_Type_1 : EnemyShipTypes
    {
        public EnemyShip_Type_1() : base()
        {
            Appearance = "-/(0)\\-\n<=-Y-=>\n   v\n";
            HealthPoints = 100;

            ShipWidth = 7;
            ShipHeight = 3;

            ShipMainMovingDirection = ConsoleKey.DownArrow;

            ShipArmament.Add(new StandardBullet(ConsoleKey.DownArrow));

            SecondsToMove = 0.5;
            ShipTimeToShoot = 3;
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 3, ShipY + 3);
        }
    }
}
