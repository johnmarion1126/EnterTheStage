using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private GameObject dogObject;
    [SerializeField]
    private string scene;

    private GameObject dialogBox;
    private DialogBox dialog;
    private GameObject soundManager;
    private SoundManager sound;
    private GameObject screenImage;
    private BlackScreen screen;
    private GameObject MusicManager;
    private FadeAudioSource music;

    void Awake() {
        dialogBox = GameObject.Find("DialogBox");
        dialog = dialogBox.GetComponent<DialogBox>();
        soundManager = GameObject.Find("SoundManager");
        sound = soundManager.GetComponent<SoundManager>();
        screenImage = GameObject.Find("/HP&Score/BlackScreen");
        screen = screenImage.GetComponent<BlackScreen>();
        MusicManager = GameObject.Find("Music");
        music = MusicManager.GetComponent<FadeAudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            music.fadeSourceOut(0.0001f);
            sound.playSound("pick");
            dogObject.GetComponent<SpriteRenderer>().enabled = false;
            dogObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(transitionToEnd());
        }
    }

    private IEnumerator transitionToEnd() {
        dialog.addDialog("You saved your dog!");
        yield return new WaitForSeconds(4.0f);
        dialog.addDialog("Time to go home :D");
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(screen.fadeOutScreen());
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
