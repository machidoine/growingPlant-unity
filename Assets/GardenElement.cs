using System.Collections.Generic;
using UnityEngine;

public class GardenElement : MonoBehaviour
{
    private Dictionary<string, Color> teamColor = new Dictionary<string, Color>()
    {
        {"team1",Color.blue },
        {"team2",Color.grey },
        {"team3",Color.magenta },
        {"team4",Color.cyan }
    };

    private Seed _seed;
    public Garden garden;
    public Seed Seed {get { return _seed; } set {
            _seed = value;
            this.GetComponent<SpriteRenderer>().color = teamColor[_seed.team];
        } }



    private void OnMouseDown()
    {
        Debug.Log("on mouse down !! " + this.Seed.id);
        garden.ShowPlantInfo(this.Seed);
    }


}