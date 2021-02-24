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

    void Awake() {
        screen = screenImage.GetComponent<BlackScreen>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            StartCoroutine(transitionLevel());
        }
    }

    IEnumerator transitionLevel() {
        StartCoroutine(screen.fadeOutScreen());
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(scene);
    }

}
