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
        uIEndgame.ToggleEndgameCanvas(false);
    }

    public void UpdateTruck(string truckTargetString, int fruitID)
    {
        // Debug.Log("Truck Progress updated! " + truckTarget);
        playerOverlay.UpdateCorrectTruck(truckTargetString, fruitID);
    }

    public void TriggerEndgame(int totalTime)
    {
        uIEndgame.ToggleEndgameCanvas(true);
        uIEndgame.SetPlayerScoreText(playerOverlay.GetFinalScore());
        uIEndgame.SetTotalTime(totalTime);
        // uIEndgame.SetTotalFruitText(playerOverlay.GetTotalFruit());
        uIEndgame.SetFruitText(playerOverlay.GetDeliveredFruit());
    }

}
