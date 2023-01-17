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
        if((Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J)) 
        && playerInteract.isHarvesting) // Need a cooldown between E-key keystrokes
        {
            isHarvested = playerInteract.Harvest();
            if(isHarvested)
            {
                // Debug.Log("Crop harvested! Sending to Truck: " + Input.inputString);
                // TODO method to parse Input.inputString because if player is moving and interacting, it gets 2 keys!
                uiManager.UpdateTruck(Input.inputString, playerInteract.CheckHarvestedFruitType());
                // Call method that updates the specific truck progress in UIManager   
            }
            
        }

        playerMove.VelocityDecay();
    }
}
