using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LaboratorySeeds : MonoBehaviour
{
    public List<InventoryItemSeed> items;
    public Inventory inventory;

    public CombineSeedEvent OnCombineSeed { get; set; }

    void Awake()
    {
        OnCombineSeed = new CombineSeedEvent();
    }

    public void ElementDropped(DropEventArg dropEventData)
    {
        GameObject target = dropEventData.target;

        var seedItem = target.GetComponent<InventoryItemSeed>();

        items.Add(seedItem);
    }

    public void CombineSeed()
    {
        OnCombineSeed.Invoke(items.ConvertAll(item => item.Model));
        Clear();
    }

    public void ResetLaboratory()
    {
        items.ForEach(i => inventory.AddItem(i));
        items.Clear();
    }

    public void Clear()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items.Clear();
    }

    [Serializable]
    public class CombineSeedEvent : UnityEvent<List<Seed>> { }
}

