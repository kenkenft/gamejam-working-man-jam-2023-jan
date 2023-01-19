using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    bool isHarvested = false;
    PlayerMove playerMove;
    UIManager uiManager;
    PlayerInteract playerInteract;
    Vector3 playerStartPos = new Vector3(1f, -4.5f, 1f);
    bool isPaused = false, isPlaying = false;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInteract = GetComponent<PlayerInteract>();
        uiManager = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        if(!isPaused && isPlaying)
        {
            if(Input.GetKey("space"))
            playerMove.Jump();

            if(Input.GetAxis("Horizontal") !=0 )
                playerMove.Move(Input.GetAxis("Horizontal"));
            
            playerMove.VelocityDecay();

            // Need to figure out how to allow for 4 separate OR cases efficiently for the 4 trucks
            if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            ||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F) 
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
        }
    }

    public void SetPlayerStartPos()
    {
        gameObject.transform.position = playerStartPos;
    }

    public void SetIsPlaying(bool state)
    {
        isPlaying = state;
    }
}
