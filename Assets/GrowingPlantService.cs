using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlantService : MonoBehaviour
{
    public Inventory inventory;
    public LaboratorySeeds labo;
    public GardenElementFactory gardenElementFactory;

    SocketIOComponent socket;

    private Dictionary<string, int> directions = new Dictionary<string, int>()
    {
        {"up",0 },
        {"down",-180 },
        {"left",90 },
        {"right",-90 },
    };

    // Use this for initialization
    void Start()
    {
        labo.OnCombineSeed.AddListener(CombineSeed);

        Debug.Log("connecting....");
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.Connect();
        socket.On("updateInventory", onUpdateInventory);
        socket.On("gridElementReceive", onGridUpdate);
    }

    private void onGridUpdate(SocketIOEvent obj)
    {
        Debug.Log("Grid receibe : " + obj.data.ToString());
        var seedContainer = JsonUtility.FromJson<SeedContainer<Seed>>(obj.data.ToString());
        
        seedContainer.seeds.ForEach(s =>
        {
            var gardenElement = gardenElementFactory.createGardenElement(s.type);
            gardenElement.transform.position = new Vector2(s.position.x, s.position.y);
            gardenElement.transform.Rotate(0, 0, directions[s.direction]);
        });
    }

    public void CombineSeed(List<Seed> seed)
    {
        List<int> seedId = seed.ConvertAll(s => s.id);

        socket.Emit("combineSeeds", new JSONObject(JsonUtility.ToJson(new SeedContainer<int>(seedId))));
    }

    [Serializable]
    class SeedContainer<T>
    {
        public List<T> seeds;

        public SeedContainer(List<T> seeds)
        {
            this.seeds = seeds;
        }
    }

    private void onUpdateInventory(SocketIOEvent obj)
    {
        var seedContainer = JsonUtility.FromJson<SeedContainer<Seed>>(obj.data.ToString());

        inventory.Clear();

        foreach (Seed seed in seedContainer.seeds)
        {
            inventory.AddItem(seed);
        }

    }

}
