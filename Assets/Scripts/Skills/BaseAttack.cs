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
                int damageDealt = executor.Equiped != null ? UnityEngine.Random.Range(0, executor.Equiped.DamageRange) + 1 + executor.Strength / 2 : 1 + executor.Strength / 2;
                Debug.Log("Hitting with base attack for " + damageDealt);
                target.CurrentHitpoints -= damageDealt;
            }
		}
	}
}
