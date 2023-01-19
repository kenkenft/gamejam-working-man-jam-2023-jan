using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class PlayerOverlay : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];
    TruckProperties[] trucksProperties = new TruckProperties[4];
    FruitPoolProperties fruitPoolProperties;
    ScoreTextProperties scoreTextProperties;
    Timer timer;
    Canvas playerOverlayCanvas;
    int fillAmount = 100/5;
    List<int> deliveredFruitsList = new List<int>{};

    public void SetUp()
    {
        playerOverlayCanvas = GetComponentInChildren<Canvas>();
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        
        for(int i = 0 ; i< trucks.Length; i++)
        {
            trucksProperties[i] = trucks[i].GetComponentInChildren<TruckProperties>();
            trucksProperties[i].SetFruitPoolPropertiesRef(fruitPoolProperties);
            trucksProperties[i].SetUp();
        }
        scoreTextProperties = GetComponentInChildren<ScoreTextProperties>();
        timer = GetComponentInChildren<Timer>();
        
        int checkListLength = deliveredFruitsList.Count-1;
        // Debug.Log("checkListLength: " + checkListLength);
        for(int i = 0; i < fruitPoolProperties.cropFruitPool.Count; i++)
        {
            // Debug.Log("Is " + fruitPoolProperties.cropFruitPool[i] + " on the list?");
            if(i > checkListLength) //Add to list if new fruit type has been delivered
            {
                deliveredFruitsList.Add(0);
                // Debug.Log("New fruit added to deliveredFruits list: " + i + " " + fruitPoolProperties.cropFruitPool[i]);
            }
        }
    }

    public void ResetOverlay()
    {
        deliveredFruitsList.Clear();
        for(int i = 0 ; i< trucks.Length; i++)
        {
            trucksProperties[i].ClearList();
            trucksProperties[i].ResetTruckProperties();
        }
        scoreTextProperties.UpdateScore(0);
    }

    public void UpdateCorrectTruck(string truckTargetString, int fruitID)
    {
        int truckID = GetCorrectTruckID(truckTargetString);
        LoadAndCheckTruck(truckID, fruitID);
    }

    int GetCorrectTruckID(string truckTargetString)
    {
        // Debug.Log("truckTargetString: " + truckTargetString);
        char targetTruck = ParseHarvestCharacter(truckTargetString);
        
        switch(targetTruck) // Would this be better as a dictionary?
        {
            case 'a':
                return 0;
            case 's':
                return 1;
            case 'd':
                return 2;
            case 'f':
                return 3;
            default:
                {
                    Debug.Log("PlayerOverlay.GetCorrectTruckID() default state triggered. targetTruck string: " + targetTruck);
                    return -1;
                }
        }
    }

    char ParseHarvestCharacter(string stringInput)
    {
        char parsedString = 'a';
        foreach(char letter in stringInput)
        {
            if(letter.Equals('a') || letter.Equals('s') || letter.Equals('d') || letter.Equals('f'))
                parsedString = letter;
        }
        return parsedString;
    }


    void LoadAndCheckTruck(int truckID, int fruitID)
    {
        trucksProperties[truckID].UpdateTruckFullness(fillAmount);
        trucksProperties[truckID].IncrementBonusTracker(fruitID);
        if(trucksProperties[truckID].IsTruckFull())
        {
            scoreTextProperties.UpdateScore(trucksProperties[truckID].CalcTruckScore());
            UpdateTotalDeliveredFruits(truckID);
            trucksProperties[truckID].ResetTruckProperties();
        }
    }

    void UpdateTotalDeliveredFruits(int truckID)
    {
        int checkListLength = deliveredFruitsList.Count-1;
        // Debug.Log("checkListLength: " + checkListLength);
        trucksProperties[truckID].ExpandFruitBonusTrackerList();
        // Debug.Log("fruitPoolProperties.cropFruitPool count:" + (fruitPoolProperties.cropFruitPool.Count-1));
        for(int i = 0; i < fruitPoolProperties.cropFruitPool.Count; i++)
        {
            // Debug.Log("Is " + fruitPoolProperties.cropFruitPool[i] + " on the checklist?");
            if(i > checkListLength) //Add to list if new fruit type has been delivered
            {
                deliveredFruitsList.Add(0);
                // Debug.Log("New fruit added to totalDeliveredFruits list: " + i + " " + fruitPoolProperties.cropFruitPool[i]);
            }
            deliveredFruitsList[i] += trucksProperties[truckID].GetFruitBonusTracker(i);
        }
    }

    public int GetFinalScore()
    {
        return scoreTextProperties.GetCurrentScore();
    }

    public int GetTotalFruit()
    {
        int totalFruit = 0;

        foreach(int tracker in deliveredFruitsList)
            totalFruit += tracker;

        return totalFruit;
    }

    public List<int> GetDeliveredFruit()
    {
        return deliveredFruitsList;
    }

    public void TogglePlayerOverlayCanvas(bool state)
    {
        playerOverlayCanvas.enabled = state;
    }

    public void StartTimer(int startTime)
    {
        StartCoroutine(timer.Countdown(startTime));
    }

    public int GetTotalTime()
    {
        return timer.GetTotalTime();
    }
}
