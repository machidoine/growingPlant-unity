using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItemSeed> items;
    public InventoryItemSeed inventoryItemSeed;

    public void AddItem(Seed seed)
    {
        var seedUI = Instantiate(inventoryItemSeed, this.transform, false);
        seedUI.Model = seed;
        seedUI.ParentChanged.AddListener(SeedParentChanged);
        items.Add(seedUI);
    }

    public void AddItem(InventoryItemSeed seedItem)
    {
        seedItem.transform.SetParent(this.transform);
        seedItem.ParentChanged.AddListener(SeedParentChanged);
        items.Add(seedItem);
    }

    public void Clear()
    {
        foreach(var item in items) {
            Destroy(item.gameObject);
        }
        items.Clear();
    }

    private void SeedParentChanged(InventoryItemSeed seed)
    {
        items.Remove(seed);
        seed.ParentChanged.RemoveListener(SeedParentChanged);
    }
}
