using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    int timeLeft = 5;
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
            timerText.SetText("Time: " + timeLeft);
        }
        StopCoroutine("Countdown");
        uIManager.TriggerEndgame();
        yield return null;
    }

    public void AddBonusTime(int bonusTime)
    {
        timeLeft += bonusTime;
    }
}
