using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Ammos;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    class PlayerShip_Type_3 : PlayerShipTypes
    {
        public PlayerShip_Type_3() : base()
        {
            Appearance = "      \\^/      \n   ^  /╫\\  ^   \n({=VoX0V0XoV=})\n (I(=I|=|I=)I) \n  ▼  ▼   ▼  ▼  \n";

            HealthPoints = 500;

            ShipWidth = 15;
            ShipHeight = 5;

            ShipMobility = 1;

            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
            ShipArmament.Add(new EnhancedBullet(ConsoleKey.UpArrow));
            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 3, ShipY);
            ShipArmament[1].SetAmmoSpawnPosition(ShipX + 7, ShipY - 1);
            ShipArmament[2].SetAmmoSpawnPosition(ShipX + 11, ShipY);
        }
    }
}
