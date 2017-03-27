using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlantService : MonoBehaviour {
    public Inventory inventory;
    public LaboratorySeeds labo;

    SocketIOComponent socket;

    // Use this for initialization
    void Start () {
        labo.OnCombineSeed.AddListener(CombineSeed);

        Debug.Log("connecting....");
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.Connect();
        socket.On("updateInventory", onUpdateInventory);
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

        foreach (Seed seed in seedContainer.seeds) {
            inventory.AddItem(seed);
        }
    
    }

}
