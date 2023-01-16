using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class UIEndgame : MonoBehaviour
{
    
    Canvas uIEndgameCanvas;
    TextMeshProUGUI playerScoreText;
    
    Button restartButton, mainMenuButton;
    

    // Start is called before the first frame update
    void Start()
    {
        uIEndgameCanvas = GetComponentInChildren<Canvas>();
        ToggleEndgameCanvas(false);

        SetUpTextRefs();
        SetUpButtonRefs();
    }

    void SetUpTextRefs()
    {
        TextMeshProUGUI[] allTexts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI text in allTexts)
        {
            if(text.name == "PlayerScoreText")
                playerScoreText = text;
        }
    }

    void SetUpButtonRefs()
    {
        Button[] allButtons = GetComponentsInChildren<Button>();
        foreach(Button button in allButtons)
        {
            if(button.name == "RestartButton")
                restartButton = button;
            else
                mainMenuButton = button;
        }
    }

    public void ToggleEndgameCanvas(bool state)
    {
        uIEndgameCanvas.enabled = state;
    }

    public void SetPlayerScoreText(int finalScore)
    {
        string tempString = finalScore + " points";
        playerScoreText.SetText(tempString);
    }
}
