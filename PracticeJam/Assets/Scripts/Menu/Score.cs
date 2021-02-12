using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int currentScore;

    public void setScore(int amount) {
        currentScore = amount;
        scoreText.text = currentScore.ToString();
    }

    public void increaseScore(int points) {
        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    public void decreaseScore(int points) {
        currentScore -= points;
        scoreText.text = currentScore.ToString();
    }
}
