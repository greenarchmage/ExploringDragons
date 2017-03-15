using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  private Owner currentOwner;
  private Character currentChar;

  private int? selectedSkill;
	// Use this for initialization
	void Start () {
    // shit initialization
    Owner player = new Owner() { Type = Owner.OwnerType.Player };
    currentOwner = player;
    Owner monsters = new Owner() { Type = Owner.OwnerType.Monster };
    GameObject.Find("Character").GetComponent<Character>().Owner = player;
    GameObject.Find("Character").GetComponent<Character>().Damage = 5;
    GameObject.Find("Character").GetComponent<Character>().Hitpoints =15;
    GameObject.Find("Character").GetComponent<Character>().Skills = new List<int>() { 1,2,3,4 };
    currentChar = GameObject.Find("Character").GetComponent<Character>();

    GameObject.Find("EnemyModel").GetComponent<Character>().Owner = monsters;
    GameObject.Find("EnemyModel").GetComponent<Character>().Damage = 5;
    GameObject.Find("EnemyModel").GetComponent<Character>().Hitpoints = 15;
  }
	
	// Update is called once per frame
	void Update () {
    // Target skills
    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0));
      if (hit)
      {
        Debug.Log(hit.collider);
        Character charac = hit.collider.gameObject.GetComponent<Character>();
        if (selectedSkill != null && charac != null && currentOwner != charac.Owner)
        {
          currentChar.UseSkill(selectedSkill, charac);
        }
      }
    }
	}

  /// <summary>
  /// UI method
  /// </summary>
  public void SetActiveAttack(int skillIndex)
  {
    // should set more parameters, depending if it is a skill that can be targeted on players or monsters
    Debug.Log("Skill selected " + skillIndex);
    selectedSkill = skillIndex;
  }

}
