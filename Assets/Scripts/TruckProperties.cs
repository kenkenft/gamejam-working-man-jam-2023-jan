using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckProperties : MonoBehaviour
{
    
    int truckFullness = 0, deliveryBonusScore = 0;
    FruitPoolProperties fruitPoolProperties;
    int[] deliveryBonusMultiplier = {0, 100, 103, 106, 109, 115, 124, 139, 163, 202, 265};
    // int[] deliveryBonusMultiplier = {0, 100, 103, 106, 109, 115, 124, 139, 163, 202, 265},
    //     fruitBonusTracker = new int[0];
    public List<int> fruitBonusTracker = new List<int>{};
    Text truckProgressText;
    void Start()
    {
        truckProgressText = GetComponentInChildren<Text>();
    }

    public void UpdateTruckFullness(int amount)
    {
        truckFullness += amount;
        UpdateProgressText();
    }

    void UpdateProgressText()
    {
        truckProgressText.text = truckFullness + "%";
    }

    public bool IsTruckFull()
    {
        bool isTruckFull = (truckFullness >= 100) ? true : false; 
        return isTruckFull;
    }

    public void IncrementBonusTracker(int fruitID)
    {
        // if(fruitBonusTracker.Length == 0)
        // {
        //     fruitBonusTracker = new int[fruitPoolProperties.cropFruitPool.Count];
        //     ResetBonusTracker();
        // }
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
    }

    void ResetBonusTracker()
    {
        // for(int i = 0; i < fruitBonusTracker.Length; i++)
        for(int i = 0; i < fruitBonusTracker.Count; i++)
            fruitBonusTracker[i] = 0;
    }

    public void SetFruitPoolPropertiesRef(FruitPoolProperties fruitPoolPropertiesRef)
    {
        fruitPoolProperties = fruitPoolPropertiesRef;
    }

}
