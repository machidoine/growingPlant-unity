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
        items.Add(seedUI);
    }

    public void AddItem(InventoryItemSeed seedItem)
    {
        seedItem.transform.SetParent(this.transform);
        items.Add(seedItem);
    }

    public void Clear()
    {
        Debug.Log("Clear Inventory");
        Debug.Log(items.Count);
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items.Clear();
    }

    public void ItemDropped(DropEventArg dropEventData)
    {
        // BUG l'instance est celle de la prefab, ou pas, en tout cas items est vide.
        Debug.Log("Item dropped");
        var i = dropEventData.from.GetComponent<Inventory>();
        Debug.Log(i.items.Count); // ici c'est la bonne instance...
        var seed = dropEventData.target.GetComponent<InventoryItemSeed>();
        Debug.Log(items.Count);
        items.Remove(seed);
        Debug.Log(items.Count);
    }
}
