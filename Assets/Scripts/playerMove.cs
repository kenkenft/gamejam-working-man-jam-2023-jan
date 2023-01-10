using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody2D rig;
    float playerSpeedBase = 2f, playerJumpForceBase = 10f;
    Vector2 mask;
    bool isHarvesting = false;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
            Jump();

        if(Input.GetAxis("Horizontal") !=0 )
            Move(Input.GetAxis("Horizontal"));

        if(Input.GetKey(KeyCode.E) && isHarvesting) // Need a cooldown between E-key keystrokes
            Debug.Log("Attempting to harvest"!);

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Crop"))
        {
            isHarvesting = true;
            Debug.Log("Entered crop harvest radius");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Crop")
        {
            isHarvesting = false;
            Debug.Log("Exited crop harvest radius");
        }
    }
}
