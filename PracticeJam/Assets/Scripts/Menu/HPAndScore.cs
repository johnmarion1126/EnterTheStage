using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPAndScore : MonoBehaviour
{
    public int lettersPerSecond;
    public Text hpText;
    public Text scoreText;

    private int currentHP;
    private int currentScore;

    public IEnumerator takeDamage(int damage) {
        hpText.text = "";
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator healHP(int heal) {
        hpText.text = "";
        yield return new WaitForSeconds(1f);
    }

    public IEnumerable increaseScore(int points) {
        scoreText.text = "";
        yield return new WaitForSeconds(1f);
    }

    public IEnumerable decreaseScore(int points) {
        scoreText.text = "";
        yield return new WaitForSeconds(1f);
    }
}
