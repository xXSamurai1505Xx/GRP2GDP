using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    

    public void AddPoints(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
}