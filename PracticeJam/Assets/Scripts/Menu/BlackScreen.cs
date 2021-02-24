using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    [SerializeField]
    private Image blackScreen;
    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private string sceneLevel;
    [SerializeField]
    private string startMenu;

    private bool isGamePaused = false;

    public void Awake() {
        blackScreen.canvasRenderer.SetAlpha(1.0f);
    }

    public void Start() {
        blackScreen.CrossFadeAlpha(0,2,false);
        gameOverText.CrossFadeAlpha(0,0,false);
    }

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

    public IEnumerator blackOut() {
        StartCoroutine(fadeOutScreen());
        StartCoroutine(showOptions());
        yield return new WaitForSeconds(3.0f);
        PauseGame();
        
    }

    public IEnumerator fadeOutScreen() {
        blackScreen.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator showOptions() {
        gameOverText.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(1.0f);
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
