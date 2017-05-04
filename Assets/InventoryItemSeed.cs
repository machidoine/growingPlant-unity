using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemSeed : InventoryItem
{
    public ParentChangedEvent ParentChanged { get; set; }
    public Text IdText;
    private Seed _model;

    public Transform skillPanel;
    public SkillColor[] skillColors;
    public SkillInventoryCounter skillFab;

    public float Id { set { IdText.text = value.ToString(); } }


    void Awake()
    {
        ParentChanged = new ParentChangedEvent();
    }

    public Seed Model
    {
        set
        {
            Id = value.id;
            _model = value;

            addSkill(value.skills.attack, SkillTypeEnum.Attack);
            addSkill(value.skills.defense, SkillTypeEnum.Defense);
            addSkill(value.skills.fertility, SkillTypeEnum.Fertility);
            addSkill(value.skills.growth, SkillTypeEnum.Growth);
            addSkill(value.skills.victory, SkillTypeEnum.Victory);
        }
        get
        {
            return _model;
        }
    }

    public void DroppedOn(LaboratorySeeds laboratorySeeds)
    {
        this.transform.SetParent(laboratorySeeds.transform);
        ParentChanged.Invoke(this);
    }

    public void DroppedOn(GardenDropper laboratorySeeds)
    {
        ParentChanged.Invoke(this);
    }

    private void addSkill(int value, SkillTypeEnum skillType)
    {
        if (value != 0)
        {
            var skill = Instantiate(skillFab, skillPanel);
            skill.Value = value;

            var skillC = Array.Find(skillColors, skillColor => skillColor.skillType == skillType);
            skill.Color = skillC.color;
        }
    }

    [Serializable]
    public class ParentChangedEvent : UnityEvent<InventoryItemSeed> { };
}

[Serializable]
public class SkillColor
{
    public SkillTypeEnum skillType;
    public Color color;
}

public enum SkillTypeEnum
{
    Attack,
    Defense,
    Growth,
    Victory,
    Fertility
}
