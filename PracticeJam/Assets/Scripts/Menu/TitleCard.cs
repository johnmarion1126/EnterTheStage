using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject playText;
    [SerializeField]
    private Image fade;
    [SerializeField]
    private string scene;

    [SerializeField]
    private GameObject soundManager;
    private SoundManager sound;
    
    private bool inScene = false;
    private bool delay = false;
    private int inputs = 0;

    void Awake() {
        sound = soundManager.GetComponent<SoundManager>();
        fade.canvasRenderer.SetAlpha(1.0f);
        fadeIn();
    }

    void Start() {
        StartCoroutine(startSequence());
    }

    void Update() {

        if(title.activeInHierarchy && inScene == false && delay == true) {
            StartCoroutine(startPlay());
        }

        if(Input.GetKey("z") && inputs < 1) {
            inputs += 1;
            sound.playSound("start");
            StartCoroutine(fadeOut());
        }
    }

    void fadeIn() {
        fade.CrossFadeAlpha(0,2,false);
    }

    IEnumerator fadeOut() {
        fade.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }

    IEnumerator startSequence() {
        yield return new WaitForSeconds(5.5f);
        title.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        delay = true;
    }

    IEnumerator startPlay() {
        inScene = true;
        playText.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        playText.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        inScene = false;
    }

}
