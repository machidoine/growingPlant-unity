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

    public void RemoveItem(Seed seed)
    {
        var itemToRemove = items.Find(item => item.Model.id == seed.id);
        items.Remove(itemToRemove);
        Destroy(itemToRemove);
    }

    public void Clear()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items.Clear();

        Debug.Log("Inventory Clear");
    }

    private void SeedParentChanged(InventoryItemSeed seed)
    {
        // TODO déplacer ce remove au moment où la seed est planté (sinon, lors d'un updateInventory, pendant le drag, elle ré-apparait dans l'inventaire)
        items.Remove(seed);
        seed.ParentChanged.RemoveListener(SeedParentChanged);
    }

    public void mergeWith(List<Seed> seeds)
    {
        Merger.Merge(items.ConvertAll(item => item.Model), seeds, new SeedIdComparer(),
            (addedSeed) =>
            {
                AddItem(addedSeed);
                Debug.Log("Add seed with ID : " + addedSeed.id);
            },
            (removedSeed) =>
            {
                RemoveItem(removedSeed);
                Debug.Log("Remove seed with ID : " + removedSeed.id);
            }
       );
    }
}

class SeedIdComparer : IEqualityComparer<Seed>
{
    public bool Equals(Seed x, Seed y)
    {
        return x.id == y.id;
    }

    public int GetHashCode(Seed obj)
    {
        return obj.id.GetHashCode();
    }
}
