using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    private Stats stats;

    [SerializeField]
    private Text hpText;

    [SerializeField]
    private GameObject blackScreen;
    private BlackScreen screen;

    void Awake() {
        screen = blackScreen.GetComponent<BlackScreen>();
        stats = playerObject.GetComponent<Stats>();
    }

    public void setHP() {
        int amount = getPlayerHP();
        hpText.text = "HP";
        for (int i = 0; i < amount; i++) {
            if (hpText.text.Length == 10) break;
            hpText.text += "I";
        }
    }

    public void removeHP(int damage) {
        if (hpText.text.Length - damage < 2) {
            hpText.text = "HP";
        }
        else {
            for (int i = 0; i < damage; i++) {
                hpText.text = hpText.text.Substring(0, hpText.text.Length - 1);
            }
        }
        
        setPlayerHP(hpText.text.Length-2);
        if (hpText.text == "HP") StartCoroutine(screen.blackOut());
    }

    public IEnumerator healHP(int amount) {
        for (int i = 0; i < amount; i++) {
            if (hpText.text.Length == 10) break;
            hpText.text += "I";
            yield return new WaitForSeconds(0.1f);
        }
        setPlayerHP(hpText.text.Length);
    }

    public void setPlayerHP(int amount) {
        PlayerPrefs.SetInt("hp", amount);
    }

    public int getPlayerHP() {
        int hp = PlayerPrefs.GetInt("hp");
        return hp;
    }

}