using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Weapons
{
    public class Spear : IWeapon
    {
        public Spear()
        {
            DamageRange = 6;
        }

        public int DamageRange
        { get; private set; }
    }
}
