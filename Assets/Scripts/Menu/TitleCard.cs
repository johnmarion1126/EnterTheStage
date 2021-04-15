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
    protected GameObject dialogBox;
    protected DialogBox dialog;
    [SerializeField]
    private GameObject soundManager;
    private SoundManager sound;
    [SerializeField]
    private GameObject Music;
    private FadeAudioSource music;
    
    private bool inScene = false;
    private bool delay = false;
    private int inputs = 0;

    void Awake() {
        sound = soundManager.GetComponent<SoundManager>();
        dialog = dialogBox.GetComponent<DialogBox>();
        music = Music.GetComponent<FadeAudioSource>();
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
            music.fadeSourceOut(0.0001f);
            inputs += 1;
            sound.playSound("start");
            PlayerPrefs.SetInt("score",0);
            PlayerPrefs.SetInt("hp", 8);
            StartCoroutine(fadeOut());
        }
    }

    void fadeIn() {
        fade.CrossFadeAlpha(0,2,false);
    }

    IEnumerator fadeOut() {
        fade.CrossFadeAlpha(1,2,false);
        yield return new WaitForSeconds(3f);
        dialog.addDialog("They stole my car...");
        yield return new WaitForSeconds(4f);
        dialog.addDialog("Destroyed my house...");
        yield return new WaitForSeconds(4f);
        dialog.addDialog("But this time...");
        yield return new WaitForSeconds(4f);
        dialog.addDialog("This time they went too far...");
        yield return new WaitForSeconds(3f);
        dialog.addDialog("");
        yield return new WaitForSeconds(1f);
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
