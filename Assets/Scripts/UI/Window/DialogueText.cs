using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public void SetText(string text)
    {
        GetComponent<Text>().text = text;
    }

}
