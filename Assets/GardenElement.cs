using UnityEngine;

public class GardenElement : MonoBehaviour
{
    public Seed Seed {get;set;}

    private void OnMouseDown()
    {
        Debug.Log("on mouse down !! " + this.Seed.id);
    }
}