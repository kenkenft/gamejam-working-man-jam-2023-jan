using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int timeLeft = 9, totalTime = 0;
    Text timerText;
    GameManager gameManager;
    WaitForSecondsRealtime timerDelay = new WaitForSecondsRealtime(0.9f);
    WaitForSecondsRealtime addTimerDelay = new WaitForSecondsRealtime(0.4f);
    AudioManager audioManager;
    Color defaultColor = Color.white, addColor = Color.green, currColor;
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        timerText.text = "Time: " + timeLeft;
        currColor = timerText.color;
        gameManager = GetComponentInParent<GameManager>();
        audioManager = GetComponentInParent<AudioManager>();
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
            // timerText.color = currColor;
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

    public void AddBonusTime(bool isAdding, int bonusTime)
    {
        if(isAdding)
        {
            
            audioManager.Play("TimerAdd");
            for(int i = 0; i < bonusTime; i++)
            {
                timeLeft += 1;
                timerText.text = "Time: " + timeLeft;
                timerText.color = addColor;
                WaitAddTimer();
            }
            timerText.color = defaultColor;
        }  

    }

    IEnumerator WaitAddTimer()
    {
        yield return addTimerDelay;
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
