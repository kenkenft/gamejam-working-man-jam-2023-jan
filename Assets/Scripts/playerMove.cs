using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody2D rig;
    float playerSpeedBase = 2f, playerJumpForceBase = 10f;
    Vector2 mask;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            Jump();
        }
        if(Input.GetAxis("Horizontal") !=0 )
        {
            Move(Input.GetAxis("Horizontal"));
        }
    }

    void Jump()
    {
        //TODO Method to check player is on ground
        rig.velocity = Vector2.up * playerJumpForceBase;
    }

    void Move(float playerDir)
    {
        mask[0] = playerDir * playerSpeedBase;
        mask[1] = rig.velocity.y;
        rig.velocity = mask;
    }
}
