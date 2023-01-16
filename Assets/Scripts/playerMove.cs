using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rig;
    float playerSpeedBase = 4f, 
          playerJumpForceBase = 10f;
    Vector2 mask;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        //TODO Method to check player is on ground
        rig.velocity = Vector2.up * playerJumpForceBase;
    }

    public void Move(float playerDir)
    {
        mask[0] = playerDir * playerSpeedBase;
        mask[1] = rig.velocity.y;
        rig.velocity = mask;
    }
    

    
}
