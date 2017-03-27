using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using Assets.Scripts.Skills;
using UnityEngine;

public class GameController : MonoBehaviour {
  public GameObject Skillpanel;

  private Character currentChar;
  private int? selectedSkill;

    private float enemyTurnCooldown = 3;
    private float nextEnemyTurn = 3;
    private Character currentEnemy;

	// Use this for initialization
	void Start () {
    

    // shit initialization
    // Player init
    Owner player = new Owner() { Type = Owner.OwnerType.Player };
    CharacterObj playerChar = new CharacterObj() { Strength = 10, Intelligence = 10, MaxHitpoints = 80, CharacterOwner = player, CurrentHitpoints = 80,
      Skills = new List<Assets.Scripts.Skills.ISkill>() { new BaseAttack(), new CureLightWounds() } };
    GameObject.Find("Character").GetComponent<Character>().CharObj = playerChar;
    currentChar = GameObject.Find("Character").GetComponent<Character>();
    Skillpanel.GetComponent<SkillPanel>().SetCharacterSkills(playerChar);

    // Monsters init
    Owner monsters = new Owner() { Type = Owner.OwnerType.Monster };
    CharacterObj enemyMonster = new CharacterObj() { Strength = 5, MaxHitpoints = 44, CharacterOwner = monsters, CurrentHitpoints = 44,
      Skills = new List<Assets.Scripts.Skills.ISkill>() { new BaseAttack() }
    };
        currentEnemy = GameObject.Find("EnemyModel").GetComponent<Character>();
        currentEnemy.CharObj = enemyMonster;
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
        Character hitCharac = hit.collider.gameObject.GetComponent<Character>();
        if (selectedSkill != null && hitCharac != null)
        {
          currentChar.UseSkill(selectedSkill, hitCharac.CharObj);
          // TODO better system for checking for skill effect
          if(hitCharac.CharObj.CurrentHitpoints <= 0)
          {
            Destroy(hit.collider.gameObject);
          }
        }
      }
        }
        if (nextEnemyTurn <= 0) {
            nextEnemyTurn = enemyTurnCooldown;
            currentEnemy.UseSkill(0, currentChar.CharObj);
        }
        else { nextEnemyTurn -= Time.deltaTime; }
    }
  /// <summary>
  /// UI method
  /// </summary>
  /// <param name="skillIndex">Index of selected skill</param>
  public void SetActiveAttack(int skillIndex)
  {
    // should set more parameters, depending if it is a skill that can be targeted on players or monsters
    // might be fixed by the internal skill system
    Debug.Log("Skill selected " + skillIndex);
    selectedSkill = skillIndex;
  }

}
