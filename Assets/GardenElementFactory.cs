using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenElementFactory : MonoBehaviour {

    public Garden garden;
    public List<Sprite> sprites;
    public GameObject gardenElementPrefab;
    
    public GameObject createGardenElement(string name)
    {
        GameObject gardenElement = Instantiate(gardenElementPrefab);
        var spriteRender = gardenElement.GetComponent<SpriteRenderer>();
        spriteRender.sprite = sprites.Find(s => s.name == name);
        gardenElement.transform.SetParent(garden.transform);
        return gardenElement;
    }
}
