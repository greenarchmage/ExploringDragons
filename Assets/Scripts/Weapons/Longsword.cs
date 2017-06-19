using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Weapons
{
    public class Longsword : IWeapon
    {
        public Longsword()
        {
            DamageRange = 8;
        }

        public int DamageRange
        { get; private set; }
    }
}
