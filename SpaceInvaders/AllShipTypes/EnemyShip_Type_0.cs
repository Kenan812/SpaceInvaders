using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Ammos;

namespace SpaceInvaders.AllShipTypes
{
    class EnemyShip_Type_0 : EnemyShipTypes
    {
        public EnemyShip_Type_0() : base()
        {
            Appearance = "-------\n -----\n  ---\n   -\n";
            HealthPoints = 100;
            
            ShipWidth = 7;
            ShipHeight = 4;
            
            ShipMainMovingDirection = ConsoleKey.DownArrow;
            
            ShipArmament.Add(new StandardBullet(ConsoleKey.DownArrow));

            SecondsToMove = 0.5;
            ShipTimeToShoot = 2;
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 3, ShipY + 4);
        }
    }
}
