using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [SerializeField]
    private int lettersPerSecond;
    [SerializeField]
    private Text dialogText;
    private int dialogInQueue = 0;

    public IEnumerator typeDialog(string dialog) {
        yield return new WaitForSeconds(0.2f);
        foreach (var letter in dialog.ToCharArray()) {
            if (dialogInQueue > 1) break;
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
        if (dialogInQueue == 1) yield return new WaitForSeconds(1.2f);
        dialogText.text = "";
        dialogInQueue -= 1;
    }

    public void addDialog(string dialog) {
        dialogInQueue += 1;
        StartCoroutine(typeDialog(dialog));
    }
}
