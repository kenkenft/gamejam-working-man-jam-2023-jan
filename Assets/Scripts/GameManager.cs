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
        fruitPoolProperties.SetUp();
        cropManager = GetComponentInChildren<CropManager>();
        cropManager.SetUp();
        uIManager = GetComponentInChildren<UIManager>();
        uIManager.SetUpUIRefs();
        uIManager.ReturnToTitle();
    }

    public void SetUpGame()
    {
        playerMain.SetIsPlaying(true);
        playerMain.SetPlayerStartPos();
        fruitPoolProperties.SetUp();
        cropManager.SetUpCropProperties();
        StartCoroutine(fruitPoolProperties.AddFruitToPool());
        uIManager.SetUpGameUI(60);
    }

    public void TriggerEndgame()
    {
        StopAllCoroutines();
        playerMain.SetIsPlaying(false);
        uIManager.TriggerEndgameUI();
    }

    public void StartRandomiseFruit()
    {
        StartCoroutine(cropManager.RegrowRandomFruit());
    }
}
