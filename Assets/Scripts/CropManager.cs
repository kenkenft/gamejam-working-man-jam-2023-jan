using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    int varIndex = 0, randomIndex=0;
    int[] mainFruitPool;
    public GameObject cropPrefab;
    FruitPoolProperties fruitPoolProperties;
    CropProperties[] allCropsProperties; 

    WaitForSecondsRealtime[] fruitChange = {
                                            new WaitForSecondsRealtime(2.5f),
                                            new WaitForSecondsRealtime(2f),
                                            new WaitForSecondsRealtime(1.5f),
                                            new WaitForSecondsRealtime(0.5f)
                                            };
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

    public IEnumerator RegrowRandomFruit()
    {
        // varIndex = Random.Range(0, fruitChange.Length);
        // yield return fruitChange[varIndex];

        foreach(CropProperties crop in allCropsProperties)
        {
            randomIndex = Random.Range(0, 100);
            if(randomIndex > 80)
                crop.GrowRandomFruit();
        }
        yield return null;
    }
    
}
