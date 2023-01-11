using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverlay : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];
    TruckProperties[] trucksProperties = new TruckProperties[4];
    int fillAmount = 20;
    void Start()
    {
        for(int i = 0 ; i< trucks.Length; i++)
        {
            trucksProperties[i] = trucks[i].GetComponentInChildren<TruckProperties>();
        }
    }


    public void UpdateCorrectTruck(string targetTruck)
    {
        int truckID = GetCorrectTruckID(targetTruck);
        LoadAndCheckTruck(truckID);
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
                return -1;
        }
    }

    void LoadAndCheckTruck(int truckID)
    {
        trucksProperties[truckID].UpdateTruckFullness(fillAmount);
        // if(trucksProperties[truckID].IsTruckFull())
    }
}
