using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerOverlay playerOverlay;
    UIEndgame uIEndgame;
    void Start()
    {
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
        uIEndgame = GetComponentInChildren<UIEndgame>();
    }

    public void UpdateTruck(string truckTarget, int fruitID)
    {
        // Debug.Log("Truck Progress updated! " + truckTarget);
        playerOverlay.UpdateCorrectTruck(truckTarget, fruitID);
    }

    public void TriggerEndgame()
    {
        Debug.Log("Time Up! Game is over!");
        uIEndgame.ToggleEndgameCanvas(true);
    }

}
