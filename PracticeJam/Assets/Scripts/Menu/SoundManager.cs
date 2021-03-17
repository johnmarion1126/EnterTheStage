using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip FaintSFX, PunchSFX, JabSFX, MissAttackSFX, HeavyImpactSFX, PickUpSFX, PointsSFX;
    public AudioClip StartMenuSFX, QuitSFX;

    [SerializeField]
    public AudioSource audioSrc;

    void Start() {
        audioSrc = GetComponent<AudioSource>();
    }

    public void playSound(string clip) {
        switch (clip) {
            case "faint":
                audioSrc.PlayOneShot(FaintSFX);
                break;
            case "punch":
                audioSrc.PlayOneShot(PunchSFX);
                break;
            case "jab":
                audioSrc.PlayOneShot(JabSFX);
                break;
            case "miss":
                audioSrc.PlayOneShot(MissAttackSFX);
                break;
            case "heavy":
                audioSrc.PlayOneShot(HeavyImpactSFX);
                break;
            case "pick":
                audioSrc.PlayOneShot(PickUpSFX);
                break;
            case "point":
                audioSrc.PlayOneShot(PointsSFX);
                break;
            case "start":
                audioSrc.PlayOneShot(StartMenuSFX);
                break;
            case "quit":
                audioSrc.PlayOneShot(QuitSFX);
                break;
        }
    }

}
