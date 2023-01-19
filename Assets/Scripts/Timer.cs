using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int timeLeft = 9, totalTime = 0;
    Text timerText;
    GameManager gameManager;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(0.5f);
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        timerText.text = "Time: " + timeLeft;
        gameManager = GetComponentInParent<GameManager>();
    }

    public IEnumerator Countdown(int startAmount)
    {
        timeLeft = startAmount;
        while(timeLeft > 0)
        {
            yield return timerDelay;
            timeLeft--;
            totalTime++;
            TimeToRandomizeFruit();
            timerText.text = "Time: " + timeLeft;
        }
        StopCoroutine("Countdown");
        gameManager.TriggerEndgame();
        yield return null;
    }

    void TimeToRandomizeFruit()
    {
        if(totalTime % 8 == 0)
            gameManager.StartRandomiseFruit();
    }

    public void AddBonusTime(int bonusTime)
    {
        timeLeft += bonusTime;
    }

    public int GetTotalTime()
    {
        return totalTime;
    }

    public void ResetTotalTime()
    {
        totalTime = 0;
    }
}
