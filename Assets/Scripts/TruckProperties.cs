using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckProperties : MonoBehaviour
{
    
    int truckFullness = 0, deliveryBonusScore = 0, fullnessLimit = 6;
    FruitPoolProperties fruitPoolProperties;
    int[] deliveryBonusMultiplier = {0, 100, 103, 106, 109, 115, 124, 139, 163, 202, 265};
    // int[] deliveryBonusMultiplier = {0, 100, 103, 106, 109, 115, 124, 139, 163, 202, 265},
    //     fruitBonusTracker = new int[0];
    public List<int> fruitBonusTracker = new List<int>{};
    Text truckProgressText;
    Image[] spritePositions = new Image[6];
    public void SetUp()
    {
        truckProgressText = GetComponentInChildren<Text>();
        SetUpSpritePositions();
    }

    void SetUpSpritePositions()
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        // Debug.Log(allTransforms.Length);

        foreach(Transform transform in allTransforms)
        {
            // Debug.Log(transform.name);
            switch(transform.name)
            {
                case "00":
                {
                    // Debug.Log("IMAGE 0 FOUND");
                    spritePositions[0] = transform.GetComponent<Image>();
                    break;
                }
                case "01":
                {
                    // Debug.Log("IMAGE 1 FOUND");
                    spritePositions[1] = transform.GetComponent<Image>();
                    break;
                }
                case "02":
                {
                    // Debug.Log("IMAGE 2 FOUND");
                    spritePositions[2] = transform.GetComponent<Image>();
                    break;
                }
                case "03":
                {
                    // Debug.Log("IMAGE 3 FOUND");
                    spritePositions[3] = transform.GetComponent<Image>();
                    break;
                }
                case "04":
                {
                    // Debug.Log("IMAGE 4 FOUND");
                    spritePositions[4] = transform.GetComponent<Image>();
                    break;
                }
                case "05":
                {
                    // Debug.Log("IMAGE 5 FOUND");
                    spritePositions[5] = transform.GetComponent<Image>();
                    break;
                }

                default:
                    break;
            } 
        }
        for(int i = 0; i < spritePositions.Length; i++)
                spritePositions[i].enabled = false;
    }
    public void ClearList()
    {
        fruitBonusTracker.Clear();
    }

    public void UpdateTruckFullness(int amount)
    {
        truckFullness += amount;
        truckFullness = Mathf.Clamp(truckFullness,0, fullnessLimit);
        UpdateProgressElement();
    }

    void UpdateProgressElement()
    {
        truckProgressText.text = (100 * truckFullness/fullnessLimit) + "%";
    }

    public bool IsTruckFull()
    {
        bool isTruckFull = (truckFullness >= fullnessLimit) ? true : false; 
        return isTruckFull;
    }

    public void IncrementBonusTracker(int fruitID)
    {

        for(int i = 0; i < fruitPoolProperties.cropFruitPool.Count; i++)
        {
            if(fruitPoolProperties.cropFruitPool[i] == fruitID)
            {    
                ExpandFruitBonusTrackerList();
                fruitBonusTracker[i]++;
            }
        }

        // for(int i = 0; i< fruitBonusTracker.Length; i++)
        // {
        //     Debug.Log("Fruit id: " + validFruitPool[i] + ". Counter number: " + fruitBonusTracker[i]);
        // }
    }

    public void ShowHarvestedFruit(int fruitID)
    {
        spritePositions[truckFullness].enabled = true;
        spritePositions[truckFullness].sprite = fruitPoolProperties.mainFruitSprites[fruitID];
    }

    public void ExpandFruitBonusTrackerList()
    {
        int trackerLength = fruitBonusTracker.Count-1; 
        for(int i = 0; i < fruitPoolProperties.cropFruitPool.Count; i++)
        {
            if(i > trackerLength)
                fruitBonusTracker.Add(0);
        }
    }

    public int GetFruitBonusTracker(int index)
    {
        ExpandFruitBonusTrackerList();
        return fruitBonusTracker[index];
    }

    public int CalcTruckScore()
    { 
        // Debug.Log("CalcTruckScore called!");
        foreach(int tracker in fruitBonusTracker)
        {
            // Debug.Log("tracker value: " + tracker);
            // Debug.Log("deliveryBonusMultiplier value: " + deliveryBonusMultiplier[tracker]);
            deliveryBonusScore += (100 * tracker * deliveryBonusMultiplier[tracker] / 100);
        }
        Debug.Log(deliveryBonusScore);
        return deliveryBonusScore;
    }

    public void ResetTruckProperties()
    {
        deliveryBonusScore = 0;
        UpdateTruckFullness(-100);
        ResetBonusTracker();
        ResetSprites();
    }

    void ResetBonusTracker()
    {
        for(int i = 0; i < fruitBonusTracker.Count; i++)
            fruitBonusTracker[i] = 0;
    }

    void ResetSprites()
    {
        for(int i = 0; i < spritePositions.Length; i++)
            spritePositions[i].enabled = false;
    }

    public void SetFruitPoolPropertiesRef(FruitPoolProperties fruitPoolPropertiesRef)
    {
        fruitPoolProperties = fruitPoolPropertiesRef;
    }

}
