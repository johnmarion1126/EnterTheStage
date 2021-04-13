using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreen;
    private BlackScreen screen;
    private string scene = "StartMenu";

    void Awake() {
        screen = blackScreen.GetComponent<BlackScreen>();
    }

    void Update() {
        if (Input.GetKey("z")) StartCoroutine(transitionToMenu());
    }

    IEnumerator transitionToMenu() {
        StartCoroutine(screen.fadeOutScreen());
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(scene);
    }
}
