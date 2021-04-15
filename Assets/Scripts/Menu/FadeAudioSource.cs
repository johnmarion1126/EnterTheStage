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
        StartCoroutine(fadeSource(targetVolume, startDuration));
    }

    public void fadeSourceOut(float targetVolume) {
        StartCoroutine(fadeSource(targetVolume, endDuration));
    }

    IEnumerator fadeSource(float targetVolume, float duration) {
        currentTime = 0;
        start = audioSource.volume;

        while (currentTime < duration) {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }
}
