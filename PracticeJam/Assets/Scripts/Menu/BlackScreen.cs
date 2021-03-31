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

    [SerializeField]
    private GameObject MusicManager;
    private FadeAudioSource music;


    private bool isGamePaused = false;

    public void Awake() {
        blackScreen.canvasRenderer.SetAlpha(1.0f);
        music = MusicManager.GetComponent<FadeAudioSource>();
    }

    public void Start() {
        blackScreen.CrossFadeAlpha(0,1,false);
        gameOverText.CrossFadeAlpha(0,0,false);
    }

    public void Update() {
        if (isGamePaused) {
            if (Input.GetKey("z")) {
                PlayerPrefs.SetInt("score", 0);
                PlayerPrefs.SetInt("hp", 8);
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
        music.fadeSourceOut(0.0001f);
        blackScreen.CrossFadeAlpha(1,1,false);
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
