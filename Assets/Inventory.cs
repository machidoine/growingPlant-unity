using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;
    public InventoryItemSeed inventoryItemSeed;

    public void AddItem(Seed seed)
    {
        var seedUI = Instantiate(inventoryItemSeed, this.transform, false);
        seedUI.Model = seed;
        seedUI.ParentChanged.AddListener(SeedParentChanged);
        items.Add(seedUI);
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
    }
}
