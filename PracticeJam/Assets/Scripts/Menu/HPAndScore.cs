using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPAndScore : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;
    private int currentScore;

    public Image blackOutScreen;
    public Text blackOutText;

    public void Start() {
        blackOutScreen.CrossFadeAlpha(0,0,false);
        blackOutText.CrossFadeAlpha(0,0,false);
    }

    public void setHP(int amount) {
        hpText.text = "HP";
        for (int i = 0; i < amount; i++) {
            hpText.text += "I";
        }
    }

    public void setScore(int amount) {
        currentScore = amount;
        scoreText.text = currentScore.ToString();
    }

    public void removeHP(int damage) {
        for (int i = 0; i < damage; i++) {
            hpText.text = hpText.text.Substring(0, hpText.text.Length - 1);
        }
        
        if (hpText.text == "HP") StartCoroutine(blackOut());
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

    public IEnumerator blackOut() {
        blackOutScreen.CrossFadeAlpha(1,3,false);
        blackOutText.CrossFadeAlpha(1,3,false);
        yield return new WaitForSeconds(2f);
    }
}
