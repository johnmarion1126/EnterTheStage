using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{
    public GameObject title;
    public GameObject playText;
    public Image fade;
    public string scene;
    private bool inScene = false;
    private bool delay = false;

    void Awake() {
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

        if(Input.GetKey("z")) StartCoroutine(fadeOut());
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
        yield return new WaitForSeconds(5f);
        title.SetActive(true);
        yield return new WaitForSeconds(5f);
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
