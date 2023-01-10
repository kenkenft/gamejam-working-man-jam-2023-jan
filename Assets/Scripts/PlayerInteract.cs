using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isHarvesting = false;
    public float harvestCooldown = 2f;

    CropProperties targetCrop;

    void Harvest()
    {
        
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
