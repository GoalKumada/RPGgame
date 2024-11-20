using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTavernToTown : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject sceneController = GameObject.Find("SceneController");
            sceneController.GetComponent<SceneController>().sceneChange("TownScene");
        }
    }
}
