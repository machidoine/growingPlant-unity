using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlantService : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("connecting....");
        GameObject go = GameObject.Find("SocketIO");
        var socket = go.GetComponent<SocketIOComponent>();
        socket.Connect();
        socket.On("updateInventory", onUpdateInvotory);
        socket.Emit("removeSeed"); // TODO : does not work !
        Debug.Log("seed removed");
    }

    private void onUpdateInvotory(SocketIOEvent obj)
    {
        var stock = obj.data.GetField("stock").list;
        foreach(var item in stock)
        {
            Debug.Log(item.GetField("id"));
            foreach(var skill in item.GetField("skills").list)
            {
                Debug.Log(skill);
            }
        }        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
