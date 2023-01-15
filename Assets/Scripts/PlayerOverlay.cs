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
    int fillAmount = 20;
    void Start()
    {
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        for(int i = 0 ; i< trucks.Length; i++)
        {
            trucksProperties[i] = trucks[i].GetComponentInChildren<TruckProperties>();
            trucksProperties[i].SetFruitPoolPropertiesRef(fruitPoolProperties);
        }
        scoreTextProperties = GetComponentInChildren<ScoreTextProperties>();
        timer = GetComponentInChildren<Timer>();
    }


    public void UpdateCorrectTruck(string targetTruck, int fruitID)
    {
        int truckID = GetCorrectTruckID(targetTruck);
        LoadAndCheckTruck(truckID, fruitID);
    }

    int GetCorrectTruckID(string targetTruck)
    {
        Debug.Log("target truck:" + targetTruck);
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
            scoreTextProperties.UpdateScore(trucksProperties[truckID].CalcTruckScore());
            trucksProperties[truckID].ResetTruckProperties();
        }
    }
}
