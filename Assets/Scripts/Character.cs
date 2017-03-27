using System;
using System.Collections.Generic;
using Assets.Scripts.Character;
using UnityEngine;

public class Character : MonoBehaviour
{
  public CharacterObj CharObj { get; set; }
  public void UseSkill(int? selectedSkill, CharacterObj target)
  {
    CharObj.Skills[selectedSkill.Value].Excute(CharObj, target);
  }
}