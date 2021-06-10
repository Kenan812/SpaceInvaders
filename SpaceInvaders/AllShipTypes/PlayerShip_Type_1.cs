using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Ammos;
using System.Threading.Tasks;

namespace SpaceInvaders.AllShipTypes
{
    class PlayerShip_Type_1 : PlayerShipTypes
    {
        public PlayerShip_Type_1() : base()
        {
            Appearance = "   ^   \n  /=\\  \n /OoO\\ \n<Tw=wT>\n ▼   ▼ \n";

            HealthPoints = 200;

            ShipWidth = 7;
            ShipHeight = 5;
            ShipMobility = 5;
            ShipArmament.Add(new StandardBullet(ConsoleKey.UpArrow));
        }

        public override void SpawnAllAmmo(int ShipX, int ShipY)
        {
            ShipArmament[0].SetAmmoSpawnPosition(ShipX + 3, ShipY - 1);
        }
    }
}
