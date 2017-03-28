using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Character;

namespace Assets.Scripts.Skills
{
	public interface ISkill
	{
		void Excute(CharacterObj executor, CharacterObj target);
	}
}
