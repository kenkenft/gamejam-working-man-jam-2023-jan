using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isHarvesting = false;
    public float harvestCooldown = 2f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;
    public int harvestPower = 20;

    CropProperties targetCrop;

    public void Harvest()
    {
        currButtonPressTime = Time.time;
        if(currButtonPressTime - lastSuccessfulPressTime > harvestCooldown)
        {
            lastSuccessfulPressTime = currButtonPressTime;
            targetCrop.HarvestFruit(harvestPower);
        }
        else
            Debug.Log("Can't use harvest action yet!");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Crop"))
        {
            isHarvesting = true;
            targetCrop = col.GetComponentInParent<CropProperties>();
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
