using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject HPScore;
    [SerializeField]
    private Image blackScreen;
    private HP hpScript;

    void Awake() {
        hpScript = HPScore.GetComponent<HP>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            StartCoroutine(transitionLevel());
        }
    }

    IEnumerator transitionLevel() {
        StartCoroutine(hpScript.fadeOutScreen());
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("LevelTwo");
    }

    //TODO: SEPARATE HP AND FADE TRANSITIONS FROM HP SCRIPT
    //TODO: ADD MOVEMENT SPEED TO STATS
}
