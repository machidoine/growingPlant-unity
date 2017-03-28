using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LaboratorySeeds : MonoBehaviour, IDropHandler
{
    public List<InventoryItemSeed> items;
    public Inventory inventory;

    public CombineSeedEvent OnCombineSeed { get; set; }

    void Awake()
    {
        OnCombineSeed = new CombineSeedEvent();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject target = eventData.pointerDrag.gameObject;

        var seedItem = target.GetComponent<InventoryItemSeed>();
        seedItem.DroppedOn(this);

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

