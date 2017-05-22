using UnityEngine;

public class GardenElement : MonoBehaviour
{
    public Garden garden;
    public Seed Seed {get;set;}

    private void OnMouseDown()
    {
        Debug.Log("on mouse down !! " + this.Seed.id);
        garden.ShowPlantInfo(this.Seed);
    }


}