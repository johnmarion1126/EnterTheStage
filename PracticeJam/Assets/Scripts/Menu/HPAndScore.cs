using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPAndScore : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;
    private int currentScore;

    public GameObject player;
    PlayerStats playerStats;

    void Awake() {
        playerStats = player.GetComponent<PlayerStats>();

        hpText.text = "HP";
        for (int i = 0; i < playerStats.playerMaxHP; i++) {
            hpText.text += "I";
        }
        scoreText.text = "0";
        currentScore = 0;
    }

    public void takeDamage(int damage) {
        for (int i = 0; i < damage; i++) {
            hpText.text.Remove(hpText.text.Length-1);
        }
    }

    public IEnumerator healHP(int amount) {
        for (int i = 0; i < amount; i++) {
            hpText.text += "I";
            yield return new WaitForSeconds(0.1f);
        }
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
