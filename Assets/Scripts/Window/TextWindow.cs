using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindow : MonoBehaviour
{
    [SerializeField] DialogueText dialogueText;
    [SerializeField] DialogueText dialogueTextPrefab;

    public void CreateDialogueText(string str)
    {
        if (dialogueText != null)
        {
            Destroy(dialogueText.gameObject);
        }

        DialogueText text = Instantiate(dialogueTextPrefab, transform);
        text.SetText(str);
        dialogueText = text;
    }
}
