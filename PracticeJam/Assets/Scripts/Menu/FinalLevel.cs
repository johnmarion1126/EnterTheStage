using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogBox;
    private DialogBox dialog;

    void Awake() {
        dialog = dialogBox.GetComponent<DialogBox>();
    }

    void Start() {
        StartCoroutine(startScene());
    }

    IEnumerator startScene() {
        dialog.addDialog("Otto: You managed to fight your way here.");
        yield return new WaitForSeconds(4.5f);
        dialog.addDialog("Otto: But you're too late.");
        yield return new WaitForSeconds(3.0f);
        dialog.addDialog("Otto: It all ends here.");
        yield return new WaitForSeconds(3.0f);
    }
}
