using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Skills
{
  public class CureLightWounds : ISkill
  {
    public void Excute(CharacterObj executor, CharacterObj target)
    {
      // Do something with healing, like intelligence
      if (target.CharacterOwner == executor.CharacterOwner)
      {
        Debug.Log("Healing character for " + executor.Intelligence / 2);
        target.CurrentHitpoints += executor.Intelligence / 2;
      }
    }
  }
}
