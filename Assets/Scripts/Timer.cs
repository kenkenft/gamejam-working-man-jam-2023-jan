using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int startValue = 5;
    TextMeshProUGUI timerText;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(1.0f);
    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        timerText.SetText("Time: " + startValue);
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        while(startValue > 0)
        {
            yield return timerDelay;
            startValue--;
            timerText.SetText("Time: " + startValue);
        }
        StopCoroutine("Countdown");
        yield return null;
    }
}
