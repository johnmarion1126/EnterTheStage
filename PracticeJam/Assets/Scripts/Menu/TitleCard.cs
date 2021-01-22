using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCard : MonoBehaviour
{
    public GameObject title;
    public GameObject playText;
    private bool inScene = false;
    private bool delay = false;

    void Start() {
        StartCoroutine(startSequence());
    }

    void Update() {
        if(title.activeInHierarchy && inScene == false && delay == true) {
            StartCoroutine(startPlay());
        }
    }

    IEnumerator startSequence() {
        yield return new WaitForSeconds(5f);
        title.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        delay = true;
    }

    IEnumerator startPlay() {
        inScene = true;
        playText.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        playText.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        inScene = false;
    }

}
