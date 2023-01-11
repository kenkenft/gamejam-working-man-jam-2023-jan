using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    bool isHarvested = false;
    PlayerMove playerMove;
    UIManager uiManager;
    PlayerInteract playerInteract;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInteract = GetComponent<PlayerInteract>();
        uiManager = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        if(Input.GetKey("space"))
            playerMove.Jump();

        if(Input.GetAxis("Horizontal") !=0 )
            playerMove.Move(Input.GetAxis("Horizontal"));
        
        // Need to figure out how to allow for 4 separate OR cases efficiently for the 4 trucks
        if((Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.J)) 
        && playerInteract.isHarvesting) // Need a cooldown between E-key keystrokes
        {
            isHarvested = playerInteract.Harvest(Input.inputString);
            if(isHarvested)
            {
                Debug.Log("Crop harvested! Sending to Truck: " + Input.inputString);
                uiManager.FillTruck(Input.inputString);
                // Call method that updates the specific truck progress in UIManager   
            }
            
        }
    }
}
