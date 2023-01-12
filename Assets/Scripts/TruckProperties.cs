using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TruckProperties : MonoBehaviour
{
    
    int truckFullness = 0;
    List<int> validFruitPool = new List<int>{0};
    int[] fruitBonusTracker;
    TextMeshProUGUI truckProgressText;
    void Start()
    {
        truckProgressText = GetComponentInChildren<TextMeshProUGUI>();
        fruitBonusTracker = new int[validFruitPool.Count];
        ResetBonusTracker();
    }

    public void UpdateTruckFullness(int amount)
    {
        truckFullness += amount;
        UpdateProgressText();
    }

    void UpdateProgressText()
    {
        truckProgressText.SetText(truckFullness + "%");
    }

    public bool IsTruckFull()
    {
        bool isTruckFull = (truckFullness >= 100) ? true : false; 
        return isTruckFull;
    }

    public void IncrementBonusTracker(int fruitID)
    {
        for(int i = 0; i < validFruitPool.Count; i++)
        {
            if(validFruitPool[i] == fruitID)
                fruitBonusTracker[i]++;
        }

        for(int i = 0; i< fruitBonusTracker.Length; i++)
        {
            Debug.Log("Fruit id: " + validFruitPool[i] + ". Counter number: " + fruitBonusTracker[i]);
        }
    }

    public int CalcTruckScore()
    {
        Debug.Log("UpdateTruckScore called!");
        // TODO Calculate score based on contents of truck
        return 1000;
    }

    void ResetBonusTracker()
    {
        for(int i = 0; i < fruitBonusTracker.Length; i++)
            fruitBonusTracker[i] = 0;
    }

}
