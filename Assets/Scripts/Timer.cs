using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int timeLeft = 100, totalTime = 0;
    UIManager uIManager;
    Text timerText;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(1.0f);
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        uIManager = GetComponentInParent<UIManager>();
        timerText.text = "Time: " + timeLeft;
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        while(timeLeft > 0)
        {
            yield return timerDelay;
            timeLeft--;
            totalTime++;
            timerText.text = "Time: " + timeLeft;
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
