using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToTavernOwner : MonoBehaviour
{
    private GameObject canvas;
    private Transform talkIconTransform;
    private GameObject talkIcon;

    private void Start()
    {
        canvas = GameObject.Find("UI");
        talkIconTransform = canvas.transform.Find("TalkIcon");
        talkIcon = talkIconTransform?.gameObject;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("衝突判定されている");
            
            talkIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("話しかけることに成功した");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        talkIcon.SetActive(false);
    }

}
