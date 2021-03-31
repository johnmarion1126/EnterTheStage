using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int currentScore;

    public void setScore() {
        currentScore = PlayerPrefs.GetInt("score");
        scoreText.text = currentScore.ToString();
    }

    public void increaseScore(int points) {
        currentScore += points;
        setPlayerScore(currentScore);
        scoreText.text = currentScore.ToString();
    }

    public void decreaseScore(int points) {
        currentScore -= points;
        setPlayerScore(currentScore);
        scoreText.text = currentScore.ToString();
    }

    public void setPlayerScore(int amount) {
        PlayerPrefs.SetInt("score", amount);
    }

    public int getPlayerHP() {
        int amount = PlayerPrefs.GetInt("score");
        return amount;
    }
}
