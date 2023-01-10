using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    PlayerMove playerMove;
    PlayerInteract playerInteract;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInteract = GetComponent<PlayerInteract>();
    }
    void Update()
    {
        if(Input.GetKey("space"))
            playerMove.Jump();

        if(Input.GetAxis("Horizontal") !=0 )
            playerMove.Move(Input.GetAxis("Horizontal"));

        if((Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.J)) 
        && playerInteract.isHarvesting) // Need a cooldown between E-key keystrokes
            playerInteract.Harvest(Input.inputString);
    }
}
