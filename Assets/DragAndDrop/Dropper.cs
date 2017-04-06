using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropper : MonoBehaviour, IDropHandler
{
    public DropEvent onDropAction;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropper OnDrop");       

        var dragger = eventData.pointerDrag.GetComponent<Dragger>();

        onDropAction.Invoke(new DropEventArg
        {
            from = dragger.from.gameObject,
            to = this.gameObject,
            target = eventData.pointerDrag
        });


        dragger.DroppedOn(this);
    }
}
