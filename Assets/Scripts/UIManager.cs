using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    PlayerOverlay playerOverlay;
    UIEndgame uIEndgame;
    UITitle uITitle;
    PlayerMain playerMain;
    void Start()
    {
        playerMain = FindObjectOfType<PlayerMain>();
        playerMain.SetIsPlaying(false);
        playerOverlay = GetComponentInChildren<PlayerOverlay>();
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame = GetComponentInChildren<UIEndgame>();
        uIEndgame.ToggleEndgameCanvas(false);
        uITitle = GetComponentInChildren<UITitle>();
    }

    public void UpdateTruck(string truckTargetString, int fruitID)
    {
        // Debug.Log("Truck Progress updated! " + truckTarget);
        playerOverlay.UpdateCorrectTruck(truckTargetString, fruitID);
    }

    public void TriggerEndgame(int totalTime)
    {
        playerMain.SetIsPlaying(false);
        playerOverlay.TogglePlayerOverlayCanvas(false);
        uIEndgame.ToggleEndgameCanvas(true);
        uIEndgame.SetPlayerScoreText(playerOverlay.GetFinalScore());
        uIEndgame.SetTotalTime(totalTime);
        // uIEndgame.SetTotalFruitText(playerOverlay.GetTotalFruit());
        uIEndgame.SetFruitText(playerOverlay.GetDeliveredFruit());
    }

    public void SetUpGame()
    {
        Debug.Log("SetUpGame called");
        // playerMain.SetPlayerStartPos();
        // Debug.Log("Player position set");
        playerMain.SetIsPlaying(true);
        Debug.Log("PlayerMain.IsPlaying set to True");
        uIEndgame.ToggleEndgameCanvas(false);
        playerOverlay.TogglePlayerOverlayCanvas(true);
        Debug.Log("PlayerOverlayCanvas enabled");
        playerOverlay.StartTimer(9);
        uITitle.DisableTitleCanvases();
    }

    public void ReturnToTitle()
    {
        uIEndgame.ToggleEndgameCanvas(false);
        uITitle.SwitchTitleInstructionScreens();
    }

}
