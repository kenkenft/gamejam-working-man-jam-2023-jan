using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int timeLeft = 9, totalTime = 0;
    UIManager uIManager;
    Text timerText;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(0f);
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        uIManager = GetComponentInParent<UIManager>();
        timerText.text = "Time: " + timeLeft;
        // StartCoroutine("Countdown");
    }

    public IEnumerator Countdown(int startAmount)
    {
        timeLeft = startAmount;
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
