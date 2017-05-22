using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPanelController : MonoBehaviour {
    public SkillPanelController skillPanelController;

    public GrowingPlantService growingPlantService;
    
    public Seed seed { get; set; }

    public void goLeft()
    {
        growingPlantService.changeDirection(seed.id, Directions.LEFT);
    }

    public void goRight()
    {
        growingPlantService.changeDirection(seed.id, Directions.RIGHT);
    }

    public void goUp()
    {
        growingPlantService.changeDirection(seed.id, Directions.UP);
    }

    public void goBottom()
    {
        growingPlantService.changeDirection(seed.id, Directions.DOWN);
    }

    public void removePlant()
    {
        this.hide();
        growingPlantService.RemovePlant(seed.id);
    }

    internal void show(Seed seed)
    {
        this.seed = seed;
        skillPanelController.SeedSkill = seed.skills;
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }
}
