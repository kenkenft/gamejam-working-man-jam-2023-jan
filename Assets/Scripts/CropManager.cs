using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] MainFruitPool;
    public Sprite[] mainFruitSprites;
    public GameObject cropPrefab;
    List<int> cropFruitPool = new List<int>{}, unaddedFruit = new List<int>{};
    CropProperties[] allCropsProperties; 
    int randomIndex;
    void Start()
    {
        SetUpUnaddedFruit();
        AddToCropPool(2);
        
        // foreach(int fruit in cropFruitPool)
        //     Debug.Log("FruitID: " + fruit);

        allCropsProperties = GetComponentsInChildren<CropProperties>();
        //TODO For each cropPrefab, set the cropFruitPool, spritePool
        foreach(CropProperties crop in allCropsProperties)
        {
            crop.UpdateCropPool(cropFruitPool[0]);
            crop.UpdateCropPool(cropFruitPool[1]);
        }
    }

    void SetUpUnaddedFruit()
    {
        MainFruitPool = new int[mainFruitSprites.Length];
        for(int i = 0; i < mainFruitSprites.Length; i++)
        {    
            MainFruitPool[i] = i;
            unaddedFruit.Add(i);
        }
    }

    void AddToCropPool(int amountToAdd)
    {
        for(int i = 0; i < amountToAdd; i++)
        {
            randomIndex = Random.Range(0, unaddedFruit.Count);
            cropFruitPool.Add(unaddedFruit[randomIndex]);
            unaddedFruit.RemoveAt(randomIndex);
        }
    }

    
}
