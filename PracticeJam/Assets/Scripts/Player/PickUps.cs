using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private string foodName;
    [SerializeField]
    private int healPoints;

    private GameObject dialogBox;
    private DialogBox dialog;
    private GameObject HP;
    private HP playerHP;
    private GameObject soundManager;
    private SoundManager sound;

    private string healDialog;

    void Awake() {
        dialogBox = GameObject.Find("DialogBox");
        dialog = dialogBox.GetComponent<DialogBox>();
        HP = GameObject.Find("HP&Score");
        playerHP = HP.GetComponent<HP>();
        soundManager = GameObject.Find("SoundManager");
        sound = soundManager.GetComponent<SoundManager>();
    }

    void Start() {
        healDialog = foodName + " heals your HP!";
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            sound.playSound("pick");
            StartCoroutine(playerHP.healHP(healPoints));
            dialog.addDialog(healDialog);
            Destroy(food);
        }
    }
}
