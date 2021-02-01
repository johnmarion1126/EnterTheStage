using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public int lettersPerSecond;
    public Text dialogText;

    public IEnumerator typeDialog(string dialog) {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }
}
