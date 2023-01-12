using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isHarvesting = false;
    public float harvestCooldown = 2f, lastSuccessfulPressTime = 0f, currButtonPressTime = 0f;
    public int harvestPower = 20, harvestProgress = 0; 

    CropProperties targetCrop;

    public bool Harvest(string harvestKeyInput)
    {
        currButtonPressTime = Time.time;
        if((currButtonPressTime - lastSuccessfulPressTime > harvestCooldown) 
            && targetCrop.CheckHarvestable())
        {
            lastSuccessfulPressTime = currButtonPressTime;
            harvestProgress = targetCrop.HarvestFruit(harvestPower);
            if(harvestProgress >= 100)
            {
                // Debug.Log("Last button press is: " + harvestKeyInput);
                return true;
            }
        }
        // else
        //     Debug.Log("Can't use harvest action yet!");

        return false;
        
    }

    public int CheckHarvestedFruitType()
    {
        return targetCrop.GetCurrentFruitType();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Crop"))
        {
            isHarvesting = true;
            targetCrop = col.GetComponentInParent<CropProperties>();
            // Debug.Log("Entered crop harvest radius");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Crop")
        {
            isHarvesting = false;
            // targetCrop = null;
            // Debug.Log("Exited crop harvest radius");
        }
    }
}
