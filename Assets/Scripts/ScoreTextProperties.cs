using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextProperties : MonoBehaviour
{
    int currentScore = 0;
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateScore(int truckScore)
    {
        currentScore += truckScore;
        scoreText.SetText("Score: " + currentScore);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
