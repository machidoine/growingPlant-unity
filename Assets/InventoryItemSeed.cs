using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemSeed : InventoryItem
{
    public Text IdText;
    private Seed _model;
    public float Id { set { IdText.text = value.ToString(); } }
    
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

    [Serializable]
    public class ParentChangedEvent : UnityEvent<InventoryItemSeed> { };
}
