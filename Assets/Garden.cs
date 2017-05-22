using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    public GardenElementFactory gardenElementFactory;
    public PlantPanelController plantPanel;

    private List<GardenElement> elementPresent = new List<GardenElement>();
    private Dictionary<string, int> directions = new Dictionary<string, int>()
    {
        {"up",0 },
        {"down",-180 },
        {"left",90 },
        {"right",-90 },
    };

    public void ShowPlantInfo(Seed seed)
    {
        plantPanel.show(seed);
    }

    internal void MergeGrid(List<Seed> seeds)
    {
        Merger.Merge(elementPresent.ConvertAll(e => e.Seed), seeds, new HashSeedComparer(),
            (addedSeed) =>
            {
                var gardenElement = gardenElementFactory.createGardenElement(addedSeed.type);
                gardenElement.Seed = addedSeed;
                gardenElement.garden = this;

                gardenElement.transform.position = new Vector2(addedSeed.position.x, addedSeed.position.y);
                gardenElement.transform.Rotate(0, 0, directions[addedSeed.direction]);

                elementPresent.Add(gardenElement);
                Debug.Log("Add seed with hash " + addedSeed.hash);
            },
            (removedSeed) =>
            {
                var element = elementPresent.Find(e => e.Seed.hash == removedSeed.hash);
                Debug.Log("elemnt to delete " + element);
                elementPresent.Remove(element);
                Destroy(element.gameObject);
                Debug.Log("Remove seed with hash " + removedSeed.hash);
            }
        );
    }
}

internal class HashSeedComparer : IEqualityComparer<Seed>
{
    bool IEqualityComparer<Seed>.Equals(Seed x, Seed y)
    {
        return x.hash.Equals(y.hash);
    }

    int IEqualityComparer<Seed>.GetHashCode(Seed obj)
    {
        return obj.hash.GetHashCode();
    }
}
