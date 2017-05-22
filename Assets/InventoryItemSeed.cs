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

    
    public SkillPanelController skillPanelController;   

    public float Id { set { IdText.text = value.ToString(); } }


    void Awake()
    {
        ParentChanged = new ParentChangedEvent();
        //skillPanel = Instantiate(skillPanelPrefab, this.transform, false);
    }

    public Seed Model
    {
        set
        {
            Id = value.id;
            _model = value;
            skillPanelController.SeedSkill = _model.skills;
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
