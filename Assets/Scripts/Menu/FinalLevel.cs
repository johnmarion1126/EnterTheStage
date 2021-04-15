using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogBox;
    private DialogBox dialog;

    [SerializeField]
    private GameObject player;
    private Animator playerAnimator;
    [SerializeField]
    private GameObject enemy;

    void Awake() {
        dialog = dialogBox.GetComponent<DialogBox>();
        playerAnimator = player.GetComponent<Animator>();
    }

    void Start() {
        enemy.GetComponent<HoodieEnemy>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(startScene());
        playerAnimator.Play("HeroIdle");
    }

    IEnumerator startScene() {
        yield return new WaitForSeconds(2.0f);
        dialog.addDialog("Otto: You managed to fight your way here.");
        yield return new WaitForSeconds(4.5f);
        dialog.addDialog("Otto: But you're too late.");
        yield return new WaitForSeconds(3.0f);
        dialog.addDialog("Otto: It all ends here.");
        yield return new WaitForSeconds(3.0f);
        enemy.GetComponent<HoodieEnemy>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
