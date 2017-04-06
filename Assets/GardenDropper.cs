using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GardenDropper : MonoBehaviour, IDropHandler
{
    public GardenDroppedEvent gardenDroppedEvent;

    public void OnDrop(PointerEventData eventData)
    {
        var itemSeed = eventData.pointerDrag.GetComponent<InventoryItemSeed>();
        itemSeed.DroppedOn(this);

        gardenDroppedEvent.Invoke(new GardenDroppedEventArg
        {
            id = itemSeed.Model.id,
            position = gardenPositionMap(eventData.position)
        });

        Destroy(itemSeed.gameObject);
    }

    private Position gardenPositionMap(Vector2 position)
    {
       ;
        return new Position
        {
            x = (int)Camera.main.ScreenToWorldPoint(position).x,
            y = (int)Camera.main.ScreenToWorldPoint(position).y
        };
    }

}

