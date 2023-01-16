using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class UIEndgame : MonoBehaviour
{
    
    Canvas uIEndgameCanvas;
    TextMeshProUGUI playerScoreText, totalTimeText, totalFruitText;
    FruitPoolProperties fruitPoolProperties;
    Button restartButton, mainMenuButton;
    public GameObject fruitInfo, fruitDeliveredBreakdown;
    
    void Start()
    {
        uIEndgameCanvas = GetComponentInChildren<Canvas>();
        fruitPoolProperties = FindObjectOfType<FruitPoolProperties>();
        ToggleEndgameCanvas(false);

        SetUpTextRefs();
        SetUpButtonRefs();
    }

    void SetUpTextRefs()
    {
        TextMeshProUGUI[] allTexts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI text in allTexts)
        {
            switch(text.name)
            {
                case "PlayerScoreText":
                {
                    playerScoreText = text;
                    break;
                }
                case "TotalTimeText":
                {
                    totalTimeText = text;
                    break;
                }
                case "TotalFruitText":
                {
                    totalFruitText = text;
                    break;
                }
                default: 
                    break;
            }
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

    public void SetTotalTime(int totalTime)
    {
        string[] buffers = {"", ":", ":"};
        // Using integer division and discarding the remainder for hours and minutes, whereas seconds keeps the remainder instead.
        int hours = totalTime/3600,
            tempIntA = totalTime - (hours * 3600), 
            minutes = tempIntA / 60,
            seconds = tempIntA % 60;
        
        if(hours < 10)
            buffers[0] = "0";
        if(minutes < 10)
            buffers[1] = ":0";
        if(seconds < 10)
            buffers[2] = ":0";

        string tempString;
        if(totalTime >= 86400)
            tempString = "Far too long";
        else
            tempString = buffers[0] + hours + buffers[1] + minutes + buffers[2] + seconds;
        totalTimeText.SetText(tempString);
    }

    public void SetTotalFruitText(int totalFruit)
    {
        string tempString = totalFruit + "";
        totalFruitText.SetText(tempString);
    }

    public void SetFruitText(List<int> deliveredFruits)
    {
        int totalDeliveredFruit = 0, amountFruitTypes = deliveredFruits.Count;

        for(int i = 0; i < deliveredFruits.Count; i++)
        {    
            totalDeliveredFruit += deliveredFruits[i];
            GameObject fruitInfoInstance = Instantiate(fruitInfo, fruitInfo.transform.position, fruitInfo.transform.rotation, fruitDeliveredBreakdown.transform);
            fruitInfoInstance.GetComponentInChildren<Image>().sprite = fruitPoolProperties.mainFruitSprites[fruitPoolProperties.cropFruitPool[i]];
            fruitInfoInstance.GetComponentInChildren<TextMeshProUGUI>().SetText("x" + deliveredFruits[i]);
        }
        
        string tempString = totalDeliveredFruit + "";
        totalFruitText.SetText(tempString);
    }
}
