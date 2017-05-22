using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelController : MonoBehaviour
{
    public SkillController skillFab;
    public SeedSkill SeedSkill
    {
        set
        {
            Clear();
            addSkill(value.attack, SkillTypeEnum.Attack);
            addSkill(value.defense, SkillTypeEnum.Defense);
            addSkill(value.fertility, SkillTypeEnum.Fertility);
            addSkill(value.growth, SkillTypeEnum.Growth);
            addSkill(value.victory, SkillTypeEnum.Victory);
        }
    }

    private void addSkill(int value, SkillTypeEnum skillType)
    {
        if (value != 0)
        {
            var skill = Instantiate(skillFab, this.transform, true);
            skill.Value = value;
            skill.Type = skillType;
        }
    }

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}
