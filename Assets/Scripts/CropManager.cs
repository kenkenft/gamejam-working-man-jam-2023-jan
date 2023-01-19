using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] mainFruitPool;
    public GameObject cropPrefab;
    FruitPoolProperties fruitPoolProperties;
    CropProperties[] allCropsProperties; 
    public void SetUp()
    {
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        allCropsProperties = GetComponentsInChildren<CropProperties>();
        SetUpCropProperties();

        // StartCoroutine("AddFruitToPool",fruitPoolProperties.unaddedFruit.Count);
    }

    public void SetUpCropProperties()
    {
        foreach(CropProperties crop in allCropsProperties)
        {
            crop.SetFruitPoolPropertiesRef(fruitPoolProperties);
            crop.SetUpSprites();
            crop.GrowRandomFruit();
        }
    }
    
}
