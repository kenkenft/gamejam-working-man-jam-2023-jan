using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    bool isHarvested = false,isPaused = false, isPlaying = false, isFacingRight = true;
    PlayerMove playerMove;
    UIManager uiManager;
    PlayerInteract playerInteract;
    Vector3 playerStartPos = new Vector3(1f, -4.5f, 1f);
    SpriteRenderer playerSpriteRenderer;
    float horizontalSpeed = 0f;

    public Animator animator;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInteract = GetComponent<PlayerInteract>();
        uiManager = FindObjectOfType<UIManager>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(!isPaused && isPlaying)
        {
            if(Input.GetKeyDown("space"))
            {    
                playerMove.Jump();
                if(playerMove.GetPlayerVerticalVel() > 0f)
                    animator.SetBool("IsJumping", true);
            }

            horizontalSpeed = Input.GetAxis("Horizontal");
            if(horizontalSpeed !=0 )
            {    
                playerMove.Move(horizontalSpeed);
                animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

                if(horizontalSpeed > 0f && !isFacingRight)
                    FlipSprite(); 
                else if(horizontalSpeed < 0f && isFacingRight) 
                    FlipSprite();
                
            }
            
            playerMove.VelocityDecay();

            // Need to figure out how to allow for 4 separate OR cases efficiently for the 4 trucks
            if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            ||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F) 
            && playerInteract.isHarvesting)
            {
                isHarvested = playerInteract.Harvest();
                if(isHarvested)
                {
                    // Debug.Log("Crop harvested! Sending to Truck: " + Input.inputString);
                    uiManager.UpdateTruck(Input.inputString, playerInteract.CheckHarvestedFruitType());
                }
            }
        }
    }

    // public void OnLanding()
    // {
    //     animator.SetBool("IsJumping", false);
    // }

    void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetPlayerStartPos()
    {
        gameObject.transform.position = playerStartPos;
    }

    public void SetIsPlaying(bool state)
    {
        isPlaying = state;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.contacts[0].normal == Vector2.up)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
