using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int timeLeft = 30, totalTime = 0;
    UIManager uIManager;
    TextMeshProUGUI timerText;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(1.0f);
    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        uIManager = GetComponentInParent<UIManager>();
        timerText.SetText("Time: " + timeLeft);
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        while(timeLeft > 0)
        {
            yield return timerDelay;
            timeLeft--;
            totalTime++;
            timerText.SetText("Time: " + timeLeft);
        }
        StopCoroutine("Countdown");
        uIManager.TriggerEndgame(totalTime);
        yield return null;
    }

    public void AddBonusTime(int bonusTime)
    {
        timeLeft += bonusTime;
    }
}
