using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetCharacterSkills(CharacterObj charObj)
	{
		for (int i = 0; i < charObj.Skills.Count; i++)
		{
			transform.GetChild(i).GetChild(0).GetComponent<Text>().text = charObj.Skills[i].GetType().Name;
			transform.GetChild(i).gameObject.SetActive(true);
		}
		for (int i = charObj.Skills.Count; i < 4; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}
