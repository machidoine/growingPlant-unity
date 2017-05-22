using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public SkillColor[] skillColors;

    public Text value;
    public Image image;

    public int Value
    {
        set
        {
            this.value.text = value.ToString();
        }
    }

    public SkillTypeEnum Type
    {
        set
        {
            var color = Array.Find(skillColors, skillColor => skillColor.skillType == value);
            image.color = color.color;
        }
    }
}
