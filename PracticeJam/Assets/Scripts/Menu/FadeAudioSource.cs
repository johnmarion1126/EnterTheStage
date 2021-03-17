using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudioSource : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float startDuration;
    [SerializeField]
    private float endDuration;
    [SerializeField]
    private float targetVolume;

    private float currentTime;
    private float start;

    void Awake() {
        StartCoroutine(fadeSourceIn());
    }

    void Update() {
        if(Input.GetKey("z")) StartCoroutine(fadeSourceOut());
    }

    IEnumerator fadeSourceIn() {
        currentTime = 0;
        start = audioSource.volume;

        while (currentTime < startDuration) {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / startDuration);
            yield return null;
        }

        yield break;
    }

    IEnumerator fadeSourceOut() {
        currentTime = 0;
        start = audioSource.volume;

        while (currentTime < endDuration) {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / endDuration);
            yield return null;
        }

        yield break;
    }
}
