using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class Oryx3 : World
    {
        public Oryx3()
        {
            Name = "Oryx The Guardian";
            ClientWorldName = "Oryx The Guardian";
            Background = 0;
            Difficulty = 5;
            AllowTeleport = false;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.Oryx3.jm", MapType.Json);
        }
    }
}
