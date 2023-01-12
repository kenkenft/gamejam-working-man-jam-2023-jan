using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperties : MonoBehaviour
{
    bool isHarvestable = true;
    Collider2D stalkCol;
    SpriteRenderer fruitSprite;
    int harvestProgress = 80;
    
    void Start()
    {
        stalkCol = GetComponentInChildren<Collider2D>();
        SpriteRenderer[] cropSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sprite in cropSprites)
        {
            Debug.Log("Sprite name: " + sprite.name);
            if(sprite.name == "FruitPosition")
                fruitSprite = sprite;
        }
    }

    public int HarvestFruit(int harvestPower)
    {
        harvestProgress += harvestPower;
        Debug.Log("Harvest Progress remaining: " + harvestProgress);
        if(harvestProgress >=100)
        {
            Debug.Log("Fruit Harvested!");
            isHarvestable = false;
            fruitSprite.enabled = false;
        }
        return harvestProgress;
    }

    public bool CheckHarvestable()
    {
        return isHarvestable;
    }
}
