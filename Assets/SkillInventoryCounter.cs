using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventoryCounter : MonoBehaviour {
    public Text value;
    public Image image;
    public Color Color { set { image.color = value; } }



    public int Value
    {
        set
        {
            this.value.text = value.ToString();
        }
    }
}
