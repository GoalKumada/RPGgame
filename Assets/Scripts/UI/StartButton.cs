using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class StartButton : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            sceneController.sceneChange("TownScene");
        });
    }
}