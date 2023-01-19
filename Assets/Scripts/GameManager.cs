using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    PlayerMain playerMain;
    FruitPoolProperties fruitPoolProperties;
    CropManager cropManager;
    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMain = GetComponentInChildren<PlayerMain>();
        playerMain.SetUp();
        playerMain.SetIsPlaying(false);
        // playerMain.SetPlayerStartPos();
        fruitPoolProperties = GetComponentInChildren<FruitPoolProperties>();
        cropManager = GetComponentInChildren<CropManager>();
        uIManager = GetComponentInChildren<UIManager>();
        uIManager.SetUpUIRefs();
        uIManager.ReturnToTitle();
    }

    public void SetUpGame()
    {
        playerMain.SetIsPlaying(true);
        // playerMain.SetPlayerStartPos();
        uIManager.SetUpGameUI();
    }

    public void TriggerEndgame()
    {
        playerMain.SetIsPlaying(false);
        uIManager.TriggerEndgameUI();
    }

    
}
