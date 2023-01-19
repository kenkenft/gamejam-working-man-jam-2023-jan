using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    Canvas titleScreenCanvas, instructionCanvas;
    Button playButton, instructionButton, titleReturnButton;
    Button[] allButtons;

    bool onInstructionScreen = false;

    public void SetUp()
    {
        allButtons = GetComponentsInChildren<Button>();
        foreach(Button button in allButtons)
        {
            switch(button.name)
            {
                case "PlayButton":
                {
                    playButton = button;
                    break;
                }
                case "InstructionButton":
                {
                    instructionButton = button;
                    break;
                }
                case "ReturnButton":
                {
                    titleReturnButton = button;
                    break;
                }
                default:
                    break;
            }
        }

        Canvas[] allCanvases = GetComponentsInChildren<Canvas>();
        foreach(Canvas canvas in allCanvases)
        {
            if(canvas.name == "TitleScreenCanvas")
                titleScreenCanvas = canvas;
            else
                instructionCanvas = canvas;
        }
    }

    public void DisableTitleCanvases()
    {
        titleScreenCanvas.enabled = false;
        instructionCanvas.enabled = false;
        onInstructionScreen = false;
    }

    public void SwitchTitleInstructionScreens()
    {
        // Debug.Log("SwitchTitleInstructionScreens called!");
        titleScreenCanvas.enabled = !onInstructionScreen;
        instructionCanvas.enabled = onInstructionScreen;
        onInstructionScreen = !onInstructionScreen;

    }

    public void ToggleButtonEnabled(bool state)
    {
        foreach(Button button in allButtons)
        {
            button.interactable = state;
        }
    }
}
