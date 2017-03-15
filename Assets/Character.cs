using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public int Hitpoints { get; set; }
  public int Damage { get; set; }
  public Owner Owner { get; set; }
  public List<int> Skills { get; set; }

  public void UseSkill(int? selectedSkill, Character charac)
  {
    charac.Hitpoints -= Skills[selectedSkill.Value] * Damage;
    if (charac.Hitpoints < 0)
    {
      Destroy(charac.gameObject);
    }
  }
}