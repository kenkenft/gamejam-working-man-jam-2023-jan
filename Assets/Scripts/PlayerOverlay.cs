using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOverlay : MonoBehaviour
{
    public GameObject[] trucks = new GameObject[4];
    void Start()
    {
         
    }


    public void UpdateCorrectTruck(string targetTruck)
    {
        int truckID = GetCorrectTruckID(targetTruck);
        FillTruck(truckID);

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

    void FillTruck(int truckID)
    {
        TextMeshProUGUI truckProgress = trucks[truckID].GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Filling truck ID: " + truckID);
        // truckProgress.SetText()
    }
}
