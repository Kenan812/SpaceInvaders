using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Ammos;

/* Dangerous ship type */

// Shoots using NRC_131_ox
// HP = 300
// 1 canon only


namespace SpaceInvaders.AllShipTypes
{
    class EnemyShip_Type_3 : EnemyShipTypes
    {
        public EnemyShip_Type_3() : base()
        {
            Appearance = " ▲  ▲   ▲  ▲ \n<=WM=>O<=MW=>\n {[o0▬O▬0o]} \n  <|==0==|>  \n   \\\\\\O///   \n    \\\\ //    \n     \\ /     \n";
            HealthPoints = 300;

            ShipWidth = 13;
            ShipHeight = 7;

            ShipMainMovingDirection = ConsoleKey.DownArrow;

            ShipArmament.Add(new NRC_131_ox(ConsoleKey.DownArrow));

            SecondsToMove = 1;
            ShipTimeToShoot = 2;
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 6, ShipY + 8);
        }
    }
}

