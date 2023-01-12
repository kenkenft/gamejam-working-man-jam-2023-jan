using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperties : MonoBehaviour
{
    bool isHarvestable = true;
    Collider2D stalkCol;
    SpriteRenderer fruitSprite;
    int harvestProgress = 80, currFruitID = 0;
    // List<int> validFruitPool = new List<int>{};
    float timeToGrow = 2.5f;
    WaitForSecondsRealtime delay = new WaitForSecondsRealtime(2.5f);
    
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

        // delay = new WaitForSeconds(timeToGrow);
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
            StartCoroutine(RegrowCrop(timeToGrow)); 
        }
        return harvestProgress;
    }

    public bool CheckHarvestable()
    {
        return isHarvestable;
    }

    public int GetCurrentFruitType()
    {
        return currFruitID;
    }

    IEnumerator RegrowCrop(float cropGrowingTime)
    {
        Debug.Log("RegrowCrop Coroutine started. Waiting.");
        // yield return new WaitForSecondsRealtime(cropGrowingTime);
        yield return delay;
        Debug.Log("Plant is growing");
        harvestProgress = 80;
        isHarvestable = true;
        // TODO Method that changes the crop's fruit type 
        fruitSprite.enabled = true;
        Debug.Log("Plant has finished growing!");
        yield return null;
    }
}
