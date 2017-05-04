using System;
using System.Collections.Generic;
using Assets.Scripts.Skills;
using UnityEngine;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.Character
{
	public class CharacterObj
	{
		// Should have a constructor that takes all the parameters to ensure all gets set correctly
		public int MaxHitpoints { get; set; }
		public Owner CharacterOwner { get; set; }
		public List<ISkill> Skills { get; set; }
		public int Strength { get; set; }
		public int Intelligence { get; set; }
		public int CurrentHitpoints { get; set; }

        public IWeapon Equiped { get; set; }
	}
}