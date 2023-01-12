using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerOverlay playerOverlay;
    void Start()
    {
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
    }

    public void UpdateTruck(string truckTarget, int fruitID)
    {
        // Debug.Log("Truck Progress updated! " + truckTarget);
        playerOverlay.UpdateCorrectTruck(truckTarget, fruitID);
    }

}
