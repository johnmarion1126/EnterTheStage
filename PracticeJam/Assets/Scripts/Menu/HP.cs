using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Image blackOutScreen;
    [SerializeField]
    private Text blackOutText;

    [SerializeField]
    private string sceneLevel;
    [SerializeField]
    private string startMenu;

    private bool isGamePaused = false;

    public void Update() {
        if (isGamePaused) {
            if (Input.GetKey("z")) {
                ContinueGame();
                SceneManager.LoadScene(sceneLevel);
            }
            else if (Input.GetKey("x")) {
                ContinueGame();
                SceneManager.LoadScene(startMenu);
            }
        }
    }

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

    public IEnumerator blackOut() {
        blackOutScreen.CrossFadeAlpha(1,2,false);
        blackOutText.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(3f);
        PauseGame();
        
    }

    private void PauseGame() {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    private void ContinueGame() {
        Time.timeScale = 1;
        isGamePaused = false;
    }
}