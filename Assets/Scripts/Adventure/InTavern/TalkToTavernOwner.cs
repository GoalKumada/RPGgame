using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToTavernOwner : MonoBehaviour
{
    private GameObject canvas;
    private Transform talkIconTransform;
    private GameObject talkIcon;

    private GameObject tavernSystemControllerObject;
    private TavernSystemController tavernSystemController;

    private float cooldownTime = 0.2f;
    private float lastInteractionTime = 0f;

    private void Start()
    {
        GetSystemManager();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && Time.time - lastInteractionTime >= cooldownTime)
        {
            StartTavernSystem();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("衝突判定されている");
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
        tavernSystemControllerObject = GameObject.Find("TavernSystenController");
        tavernSystemController = tavernSystemControllerObject.GetComponent<TavernSystemController>();
    }

    public void StartTavernSystem()
    {
        lastInteractionTime = Time.time;
        Pause();
        tavernSystemController.menuPanel.Open();
        tavernSystemController.isMenuSelectingPhase = true;
        tavernSystemController.SetCurrentAmountOfMoney();
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
