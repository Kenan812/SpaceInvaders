using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Ammos;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    class PlayerShip_Type_2 : PlayerShipTypes
    {
        public PlayerShip_Type_2() : base()
        {
            Appearance = "     ^     \n  ^  ║  ^  \n  ║ XxX ║  \n<==░0Y0░==>\n  <▓OoO▓>  \n   ▼   ▼   \n";

            HealthPoints = 250;

            ShipWidth = 11;
            ShipHeight = 6;
            ShipMobility = 3;

            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 5, ShipY - 1);
            ShipArmament[1].SetAmmoSpawnPosition(ShipX + 2, ShipY);
            ShipArmament[2].SetAmmoSpawnPosition(ShipX + 8, ShipY);
        }
    }
}
