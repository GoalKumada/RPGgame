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

    private bool isTalkIconActivating = false;

    private float cooldownTime = 0.2f;
    private float lastInteractionTime = 0f;

    private void Start()
    {
        GetSystemManager();
    }

    private void Update()
    {
        if (isTalkIconActivating)
        {
            if (Input.GetKeyUp(KeyCode.Space) && Time.time - lastInteractionTime >= cooldownTime)
            {
                StartTavernSystem();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivateTalkIconObject();
            isTalkIconActivating = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        talkIcon.SetActive(false);
        isTalkIconActivating = false;
    }

    // 「話す」アイコンを表示する
    public void ActivateTalkIconObject()
    {
        canvas = GameObject.Find("UI");
        talkIconTransform = canvas.transform.Find("TalkIcon");
        talkIcon = talkIconTransform?.gameObject;
        talkIcon.SetActive(true);
    }

    // SystemManagerを取得
    public void GetSystemManager()
    {
        tavernSystemControllerObject = GameObject.Find("TavernSystenController");
        tavernSystemController = tavernSystemControllerObject.GetComponent<TavernSystemController>();
    }

    // 酒場の雇用システムを開始する
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
