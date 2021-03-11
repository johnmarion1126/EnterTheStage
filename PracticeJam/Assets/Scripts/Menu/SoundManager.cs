using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip FaintSFX, PunchSFX, JabSFX, MissAttackSFX, HeavyImpactSFX, PickUpSFX;

    [SerializeField]
    public AudioSource audioSrc;

    void Start() {
        /*
        FaintSFX = Resources.Load<AudioClip>("FaintSFX");
        PunchSFX = Resources.Load<AudioClip>("PunchSFX");
        JabSFX = Resources.Load<AudioClip>("JabSFX");
        MissAttackSFX = Resources.Load<AudioClip>("MissAttackSFX");
        HeavyImpactSFX = Resources.Load<AudioClip>("HeavyImpactSFX");
        PickUpSFX = Resources.Load<AudioClip>("PickUpSFX");
        */

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
        }
    }

}
