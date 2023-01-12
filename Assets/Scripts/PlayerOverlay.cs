using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class PlayerOverlay : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];
    TruckProperties[] trucksProperties = new TruckProperties[4];
    ScoreTextProperties scoreTextProperties;
    int fillAmount = 20, truckScore;
    void Start()
    {
        for(int i = 0 ; i< trucks.Length; i++)
        {
            trucksProperties[i] = trucks[i].GetComponentInChildren<TruckProperties>();
        }
        scoreTextProperties = GetComponentInChildren<ScoreTextProperties>();
    }


    public void UpdateCorrectTruck(string targetTruck, int fruitID)
    {
        int truckID = GetCorrectTruckID(targetTruck);
        LoadAndCheckTruck(truckID, fruitID);
    }

    int GetCorrectTruckID(string targetTruck)
    {
        switch(targetTruck) // Would this be better as a dictionary?
        {
            case "h":
                return 0;
            case "j":
                return 1;
            case "k":
                return 2;
            case "l":
                return 3;
            default:
                {
                    Debug.Log("PlayerOverlay.GetCorrectTruckID() default state triggered. targetTruck string: " + targetTruck);
                    return -1;
                }
        }
    }

    void LoadAndCheckTruck(int truckID, int fruitID)
    {
        trucksProperties[truckID].UpdateTruckFullness(fillAmount);
        trucksProperties[truckID].IncrementBonusTracker(fruitID);
        if(trucksProperties[truckID].IsTruckFull())
        {
            truckScore = trucksProperties[truckID].CalcTruckScore();
            scoreTextProperties.UpdateScore(truckScore);
        }
    }
}
