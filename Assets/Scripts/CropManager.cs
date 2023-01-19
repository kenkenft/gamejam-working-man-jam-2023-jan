using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int[] mainFruitPool;
    public GameObject cropPrefab;
    FruitPoolProperties fruitPoolProperties;
    CropProperties[] allCropsProperties; 
    WaitForSecondsRealtime addFruitDelay = new WaitForSecondsRealtime(10.0f);
    void Start()
    {
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        fruitPoolProperties.SetUpUnaddedFruit();
        fruitPoolProperties.AddToCropPool(2);
        
        // foreach(int fruit in fruitPoolProperties.cropFruitPool)
        //     Debug.Log("FruitID: " + fruit + ". Fruit name: " + fruitPoolProperties.mainFruitSprites[fruit]);

        allCropsProperties = GetComponentsInChildren<CropProperties>();
        foreach(CropProperties crop in allCropsProperties)
        {
            crop.SetFruitPoolPropertiesRef(fruitPoolProperties);
            crop.SetUpSprites();
            crop.GrowRandomFruit();
        }

        // StartCoroutine("AddFruitToPool",fruitPoolProperties.unaddedFruit.Count);
    }

    public IEnumerator AddFruitToPool(int unaddedFruitLeft)
    {
        while(unaddedFruitLeft !=0)
        {
            yield return addFruitDelay;
            fruitPoolProperties.AddToCropPool(1);
            unaddedFruitLeft--;
            // Debug.Log("Coroutine AddFruitToPool: Fruit Added to pool! Fruit unadded: "+ unaddedFruitLeft);
        }
        StopCoroutine("AddFruitToPool");
        yield return null;
    }
    
}
