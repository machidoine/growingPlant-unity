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

    [Serializable]
    public class ParentChangedEvent : UnityEvent<InventoryItemSeed> { };
}
