using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] mainFruitPool;
    // public Sprite[] mainFruitSprites;
    public GameObject cropPrefab;
    FruitPoolProperties fruitPoolProperties;
    // List<int> cropFruitPool = new List<int>{}, unaddedFruit = new List<int>{};
    CropProperties[] allCropsProperties; 
    // int randomIndex;
    void Start()
    {
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        // SetUpUnaddedFruit();
        // AddToCropPool(2);
        fruitPoolProperties.SetUpUnaddedFruit();
        fruitPoolProperties.AddToCropPool(2);
        
        foreach(int fruit in fruitPoolProperties.cropFruitPool)
            Debug.Log("FruitID: " + fruit + ". Fruit name: " + fruitPoolProperties.mainFruitSprites[fruit]);

        allCropsProperties = GetComponentsInChildren<CropProperties>();
        //TODO For each cropPrefab, set the cropFruitPool, spritePool
        foreach(CropProperties crop in allCropsProperties)
        {
            crop.UpdateCropPool(fruitPoolProperties.cropFruitPool[0]);
            crop.UpdateCropPool(fruitPoolProperties.cropFruitPool[1]);
            for(int i = 0; i < fruitPoolProperties.mainFruitSprites.Length; i++)
            {
                crop.mainFruitSprites.Add(fruitPoolProperties.mainFruitSprites[i]);
            }
            crop.SetUpSprites();
            crop.GrowRandomFruit();
        }
    }

    // void SetUpUnaddedFruit()
    // {
    //     // mainFruitPool = new int[mainFruitSprites.Length];
    //     // FruitPoolProperties.mainFruitPool = new int[mainFruitSprites.Length]
    //     for(int i = 0; i < mainFruitSprites.Length; i++)
    //     {    
    //         mainFruitPool[i] = i;
    //         unaddedFruit.Add(i);
    //     }
    // }

    // void AddToCropPool(int amountToAdd)
    // {
    //     for(int i = 0; i < amountToAdd; i++)
    //     {
    //         randomIndex = Random.Range(0, unaddedFruit.Count);
    //         cropFruitPool.Add(unaddedFruit[randomIndex]);
    //         unaddedFruit.RemoveAt(randomIndex);
    //     }
    // }

    
}
