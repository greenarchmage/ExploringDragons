using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using Assets.Scripts.Skills;
using UnityEngine;
using Assets.Scripts.Weapons;

public class GameController : MonoBehaviour
{
	public GameObject Skillpanel;
	public GameObject SampleEnemy;

	private Character playerChar; // TODO: Move to some sort of AI or targeting system
	private Character currentChar;
	private Character nextChar;
	private int? selectedSkill;

	// Use this for initialization
	void Start()
	{

		// shit initialization
		// Player init
		Owner player = new Owner() { Type = Owner.OwnerType.Player };
		CharacterObj playerCharObj = new CharacterObj()
		{
			Strength = 10,
			Intelligence = 10,
			MaxHitpoints = 80,
			CharacterOwner = player,
			CurrentHitpoints = 80,
			Skills = new List<Assets.Scripts.Skills.ISkill>() { new BaseAttack(), new CureLightWounds() }
		};
        playerCharObj.Equiped = new Longsword();

		playerChar = GameObject.Find("Character").GetComponent<Character>();
		playerChar.CharObj = playerCharObj;
		Skillpanel.GetComponent<SkillPanel>().SetCharacterSkills(playerCharObj);

		// Monsters init
		NextBattle();

		// Turn start
		nextChar = playerChar;
		NextTurn();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentChar.Owner.Type == Owner.OwnerType.Player)
		{
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
						if (hitCharac.CharObj.CurrentHitpoints <= 0)
						{
							Destroy(hit.collider.gameObject);
							NextBattle();
						}
						NextTurn();
					}
				}
			}
		}
		else
		{
			// TODO: Move to AI or targeting system
			currentChar.UseSkill(0, playerChar.CharObj);
			if (playerChar.CharObj.CurrentHitpoints <= 0)
				Debug.Log("You Dead homie!!");
			NextTurn();
		}
	}

	public void NextTurn()
	{
		currentChar = nextChar;
		nextChar = TurnManager.Instance.NextCharacter();
	}

	public void NextBattle()
	{
		// Monsters init
		Owner monsters = new Owner() { Type = Owner.OwnerType.Monster };
		CharacterObj enemyMonster = new CharacterObj()
		{
			Strength = 5,
			MaxHitpoints = 44,
			CurrentHitpoints = 44,
			CharacterOwner = monsters,
			Skills = new List<Assets.Scripts.Skills.ISkill>() { new BaseAttack() }
		};
        enemyMonster.Equiped = new Spear();
        Character enemyCharacter = Instantiate(SampleEnemy).GetComponent<Character>();
		enemyCharacter.gameObject.SetActive(true);

		enemyCharacter.CharObj = enemyMonster;
		TurnManager.Instance.Renew();
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
