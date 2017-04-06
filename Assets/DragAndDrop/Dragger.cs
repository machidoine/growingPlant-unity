using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public DropEvent onDropAction;
    public Transform from;

    public void DroppedOn(Dropper dropper)
    {
        Debug.Log("Dragger DroppedOn");
        this.transform.SetParent(dropper.transform);

        DropEventArg eventArg = new DropEventArg
        {
            from = from.gameObject,
            to = dropper.gameObject,
            target = this.gameObject
        };

        onDropAction.Invoke(eventArg);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragger Begin Drag");
        from = this.transform.parent;
        this.transform.SetParent(this.transform.parent, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //this.transform.SetParent(eventData.pointerDrag.gameObject.transform);
    }

}