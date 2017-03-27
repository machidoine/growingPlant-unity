using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        this.transform.SetParent(this.transform.parent, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
