using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rig;
    float playerSpeedBase = 8f, 
          playerJumpForceBase = 8f,
          speedDecayMultiplier = 0.95f,
          jumpVelDecayHigh = 1.4f, 
          jumpVelDecayLow = 1.9f;
    Vector2 mask, spriteSize;
    Vector3 maskX, maskY;
    Ray2D[] rays;
    public LayerMask groundLayerMask;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        spriteSize =  GetComponent<SpriteRenderer>().bounds.size;
        maskX = new Vector3(spriteSize.x / 2f, 0, 0);
        maskY = new Vector3(0,spriteSize.y / 2f, 0);
    }


    public void Jump()
    {
        if(IsGrounded())
            rig.velocity = Vector2.up * playerJumpForceBase;
    }

    public void Move(float playerDir)
    {
        mask[0] = playerDir * playerSpeedBase;
        mask[1] = rig.velocity.y;
        rig.velocity = mask;
    }
    
    bool IsGrounded()
    {
        Ray2D[] jumpRays = CreateRays();
        foreach(Ray2D ray in jumpRays)
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, groundLayerMask);
        if (hit.collider != null) 
            return true;
        }
        return false;

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayerMask);
        // if (hit.collider != null) 
        //     return true;
        // return false;
    }//// End of IsGrounded()

    public Ray2D[] CreateRays()
    {
        // Construct 3 rays at the bottom of the player's sprite.
        return rays = new Ray2D[3]
        {
            // Create raycast at position clickedTiles's origin + tile's bounding area + tile margin offset
            new Ray2D(transform.position - maskX, Vector2.down),             // Sends raycast 0.1m above tile
            new Ray2D(transform.position + maskX, Vector2.down),             // Sends raycast 0.1m below tile
            new Ray2D(transform.position, Vector2.down),             // Sends raycast 0.1m to the right of the tile
        };
    }

    public void VelocityDecay()
    {
        float x = rig.velocity.x;
        Vector3 mask = rig.velocity;

        if( x !=0.0f )              // Gradually reduce x-axis velocity (Unless being boosted by ramps)
        {
            mask.x *= speedDecayMultiplier;
            rig.velocity = mask;
        }

        if(rig.velocity.y < 0)              // Reduces floatiness of jumps
            rig.velocity += Vector2.up * Physics2D.gravity.y * jumpVelDecayHigh * Time.deltaTime;    
        else if(rig.velocity.y > 0 && !Input.GetButton("Jump"))     // For low jumps
            rig.velocity += Vector2.up * Physics2D.gravity.y * jumpVelDecayLow  * Time.deltaTime;                // Start increasing downward velocity once player lets go of jump input
        
    }//// End of VelocityDecay()
}
