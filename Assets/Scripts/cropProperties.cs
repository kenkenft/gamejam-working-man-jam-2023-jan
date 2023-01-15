using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperties : MonoBehaviour
{
    bool isHarvestable = true;
    Collider2D stalkCol;
    SpriteRenderer fruitSpriteRenderer;
    Sprite fruitSprite;
    public List<Sprite> mainFruitSprites = new List<Sprite>{};
    List<int> cropFruitPool = new List<int>{};
    int harvestProgress = 80, currFruitID = -1;
    // List<int> validFruitPool = new List<int>{};
    float timeToGrow = 2.5f;
    WaitForSecondsRealtime delay = new WaitForSecondsRealtime(2.5f);
    
    void Start()
    {
        stalkCol = GetComponentInChildren<Collider2D>();
        // delay = new WaitForSeconds(timeToGrow);
    }

    public int HarvestFruit(int harvestPower)
    {
        harvestProgress += harvestPower;
        // Debug.Log("Harvest Progress remaining: " + harvestProgress);
        if(harvestProgress >=100)
        {
            // Debug.Log("Fruit Harvested!");
            isHarvestable = false;
            fruitSpriteRenderer.enabled = false;
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

    public void SetUpSprites()
    {
        SpriteRenderer[] cropSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in cropSprites)
        {
            // Debug.Log("Sprite name: " + sprite.name);
            if(spriteRenderer.name == "FruitPosition")
            {
                fruitSpriteRenderer = spriteRenderer;
                // Debug.Log("Fruit Position Found! " + fruitSpriteRenderer.name);
                // fruitSprite = spriteRenderer.sprite;
            }
        }
    }

    public void UpdateCropPool(int newFruitID)
    {
        cropFruitPool.Add(newFruitID);
        Debug.Log("Fruit Added! ID: " + cropFruitPool[cropFruitPool.Count-1]);
    }

    public void GrowRandomFruit()
    {
        bool isNewFruitSelected = false;
        int randomIndex;
        
        if(!isNewFruitSelected)
        {
            randomIndex = Random.Range(0, cropFruitPool.Count);
            if(randomIndex != currFruitID || cropFruitPool.Count == 1)
            {
                currFruitID = cropFruitPool[randomIndex];
                fruitSpriteRenderer.sprite = mainFruitSprites[currFruitID];
                // fruitSprite = mainFruitSprites[currFruitID];
                isNewFruitSelected = true;
            }
        }
    }

    IEnumerator RegrowCrop(float cropGrowingTime)
    {
        // Debug.Log("RegrowCrop Coroutine started. Waiting.");
        // yield return new WaitForSecondsRealtime(cropGrowingTime);
        yield return delay;
        // Debug.Log("Plant is growing");
        harvestProgress = 80;
        isHarvestable = true;
        GrowRandomFruit();
        fruitSpriteRenderer.enabled = true;
        // Debug.Log("Plant has finished growing!");
        yield return null;
    }
}
