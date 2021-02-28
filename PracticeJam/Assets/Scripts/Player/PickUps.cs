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

    [SerializeField]
    private GameObject dialogBox;
    private DialogBox dialog;

    [SerializeField]
    private GameObject HP;
    private HP playerHP;

    private string healDialog;

    void Awake() {
        dialogBox = GameObject.Find("DialogBox");
        HP = GameObject.Find("HP&Score");
        dialog = dialogBox.GetComponent<DialogBox>();
        playerHP = HP.GetComponent<HP>();
    }

    void Start() {
        healDialog = foodName + " heals you for " + healPoints.ToString() + " points!";
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            StartCoroutine(playerHP.healHP(healPoints));
            dialog.addDialog(healDialog);
            Destroy(food);
        }
    }

    //TODO: FIX ENEMY AI, ENEMIES KEEP PUSHING EACH OTHER WHEN DYING
    //TODO: ADD MORE DIALOG
    //TODO: ADD SOME SOUND DESIGN
    //TODO: ADD SOME MUSIC
}
