using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProperties : MonoBehaviour
{
    Collider2D stalkCol;
    int harvestProgress = 100;
    
    void Start()
    {
        stalkCol = GetComponentInChildren<Collider2D>();
    }

    public int HarvestFruit(int harvestPower)
    {
        harvestProgress -= harvestPower;
        Debug.Log("Harvest Progress remaining: " + harvestProgress);
        if(harvestProgress <=0)
        {
            Debug.Log("Fruit Harvested!");
        }
        return harvestProgress;
    }
}
