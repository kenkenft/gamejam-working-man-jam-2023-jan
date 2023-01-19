using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    Canvas titleScreenCanvas, instructionCanvas;
    Button playButton, instructionButton, titleReturnButton;

    UIManager uIManager;
    bool onInstructionScreen = false;

    void Start()
    {
        uIManager = GetComponentInParent<UIManager>();
        Button[] allButtons = GetComponentsInChildren<Button>();
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
        SwitchTitleInstructionScreens();

        Debug.Log(uIManager.gameObject.name);
    }

    public void DisableTitleCanvases()
    {
        Debug.Log("PlayGame Called");
        titleScreenCanvas.enabled = false;
        Debug.Log("titleCanvas disabled");
        instructionCanvas.enabled = false;
        Debug.Log("instructionCanvas disabled");
        onInstructionScreen = false;
        Debug.Log("onInstructionScreen set to false");
    }

    public void SwitchTitleInstructionScreens()
    {
        Debug.Log("SwitchTitleInstructionScreens called!");
        titleScreenCanvas.enabled = !onInstructionScreen;
        instructionCanvas.enabled = onInstructionScreen;
        onInstructionScreen = !onInstructionScreen;

    }
}
