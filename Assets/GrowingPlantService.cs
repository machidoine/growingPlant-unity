using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlantService : MonoBehaviour
{
    public Inventory inventory;
    public LaboratorySeeds labo;
    public Garden garden;

    SocketIOComponent socket;

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

    public void PlantSeed(GardenDroppedEventArg gardenArg)
    {
        Debug.Log("plant seed " + gardenArg);
        socket.Emit("addSeed", new JSONObject(JsonUtility.ToJson(new AddSeed
        {
            seedId = gardenArg.id,
            direction = "up",
            position = gardenArg.position
        })));
    }

    private void onGridUpdate(SocketIOEvent obj)
    {
        Debug.Log("Grid receive : " + obj.data.ToString());
        var seedContainer = JsonUtility.FromJson<SeedContainer<Seed>>(obj.data.ToString());
        garden.MergeGrid(seedContainer.seeds);
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
    [Serializable]
    class AddSeed
    {
        public int seedId;
        public Position position;
        public string direction;
    }

    private void onUpdateInventory(SocketIOEvent obj)
    {
        var seedContainer = JsonUtility.FromJson<SeedContainer<Seed>>(obj.data.ToString());

        inventory.mergeWith(seedContainer.seeds);
    }

}
