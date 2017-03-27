using System;
using System.Collections.Generic;
using Assets.Scripts.Character;
using UnityEngine;

public class Character : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public CharacterObj CharObj { get; set; }
    public Owner Owner { get { return CharObj.CharacterOwner; } }

    public void UseSkill(int? selectedSkill, CharacterObj target)
    {
        CharObj.Skills[selectedSkill.Value].Excute(CharObj, target);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.color = new Color(
            1,
            ((float)CharObj.CurrentHitpoints / (float)CharObj.MaxHitpoints),
            ((float)CharObj.CurrentHitpoints / (float)CharObj.MaxHitpoints)
            );
    }
}