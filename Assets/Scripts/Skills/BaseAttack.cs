using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Skills
{
	public class BaseAttack : ISkill
	{
		public void Excute(CharacterObj executor, CharacterObj target)
		{
			// Do something with attacking, like strength
			if (target.CharacterOwner != executor.CharacterOwner)
			{
				Debug.Log("Hitting with base attack for " + executor.Strength / 2);
				target.CurrentHitpoints -= executor.Strength / 2;
			}
		}
	}
}
