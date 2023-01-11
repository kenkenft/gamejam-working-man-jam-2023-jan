using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TruckProperties : MonoBehaviour
{
    
    int truckFullness = 0;
    TextMeshProUGUI truckProgressText;
    void Start()
    {
        truckProgressText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateTruckFullness(int amount)
    {
        truckFullness += amount;
        UpdateProgressText();
    }

    void UpdateProgressText()
    {
        truckProgressText.SetText(truckFullness + "%");
    }

    public bool IsTruckFull()
    {
        bool isTruckFull = (truckFullness >= 100) ? true : false; 
        return isTruckFull;
    }
}
