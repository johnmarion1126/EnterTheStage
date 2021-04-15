using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField]
    private string scene;
    [SerializeField]
    private GameObject blackScreen;
    [SerializeField]
    private Image screenImage;
    private BlackScreen screen;
    [SerializeField]
    private GameObject SoundManager;
    private SoundManager sound;


    void Awake() {
        screen = screenImage.GetComponent<BlackScreen>();
        sound = SoundManager.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            StartCoroutine(transitionLevel());
        }
    }

    IEnumerator transitionLevel() {
        sound.playSound("door");
        StartCoroutine(screen.fadeOutScreen());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

}
