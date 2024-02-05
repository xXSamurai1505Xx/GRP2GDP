using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecycleGameObjective : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore = 0;
    private int maxScore = 7;

    private void Start()
    {
        updateScoreText();
    }


    private void Update()
    {
        updateScoreText();
    }

    public void updateScoreText()
    {
        scoreText.text = currentScore + "/" + maxScore;
    }



}
