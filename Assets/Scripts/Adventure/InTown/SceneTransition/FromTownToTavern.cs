using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTownToTavern : MonoBehaviour
{
    private Vector3 frontOfTavaren = new Vector3(-1f, 0.2f, -2.85f);

    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPositionManager.posOfPlayerInTown = frontOfTavaren;

            GameObject sceneController = GameObject.Find("SceneController");
            sceneController.GetComponent<SceneController>().sceneChange("TavernScene");
        }
    }
}