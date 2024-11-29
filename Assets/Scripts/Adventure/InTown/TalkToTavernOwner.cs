using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToTavernOwner : MonoBehaviour
{
    private GameObject canvas;
    private Transform talkIconTransform;
    private GameObject talkIcon;

    private GameObject tavernSystemManagerObject;
    private TavernSystemManager tavernSystemManager;

    private void Start()
    {
        GetSystemManager();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tavernSystemManager.menuPanel.Open();
            Pause();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("衝突判定されている");
            ActivateTalkIconObject();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        talkIcon.SetActive(false);
    }

    public void ActivateTalkIconObject()
    {
        canvas = GameObject.Find("UI");
        talkIconTransform = canvas.transform.Find("TalkIcon");
        talkIcon = talkIconTransform?.gameObject;
        talkIcon.SetActive(true);
    }
    public void GetSystemManager()
    {
        tavernSystemManagerObject = GameObject.Find("TavernSystenManager");
        tavernSystemManager = tavernSystemManagerObject.GetComponent<TavernSystemManager>();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
