using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] mainFruitPool;
    public GameObject cropPrefab;
    FruitPoolProperties fruitPoolProperties;
    CropProperties[] allCropsProperties; 
    void Start()
    {
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        fruitPoolProperties.SetUpUnaddedFruit();
        fruitPoolProperties.AddToCropPool(2);
        
        // foreach(int fruit in fruitPoolProperties.cropFruitPool)
        //     Debug.Log("FruitID: " + fruit + ". Fruit name: " + fruitPoolProperties.mainFruitSprites[fruit]);

        allCropsProperties = GetComponentsInChildren<CropProperties>();
        //TODO For each cropPrefab, set the cropFruitPool, spritePool
        foreach(CropProperties crop in allCropsProperties)
        {
            crop.SetFruitPoolPropertiesRef(fruitPoolProperties);
            crop.SetUpSprites();
            crop.GrowRandomFruit();
        }
    }
    
}
