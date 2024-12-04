using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class TavernSystemManager : MonoBehaviour
{
    [SerializeField] public WindowMenu menuPanel;
    [SerializeField] public WindowMenu jobPanel;
    [SerializeField] public GameObject allyRecruitPanel;
    [SerializeField] public WindowMenu allyTextPanel;


    public bool isMenuSelectingPhase;
    private bool isJobSelectingPhase;
    private bool isRecruitingPhase;


    void Start()
    {
        
    }

    void Update()
    {
        if (isMenuSelectingPhase)
        {
            OnMenuSelectPhase();
        }
        else if (isJobSelectingPhase)
        {
            OnJobSelectPhase();
        }
        else if (isRecruitingPhase)
        {

        }

    }

    public void OnMenuSelectPhase()
    {
        //Debug.Log("MenuSelectPhase");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(menuPanel);

            if (index == 0)
            {
                jobPanel.Open();
                isJobSelectingPhase = true;
                isMenuSelectingPhase = false;
            }
            else if (index == 1)
            {
                // 後記

                isMenuSelectingPhase = false;
            }
            else if (index == 2)
            {
                // 後記

                isMenuSelectingPhase = false;
            }
            else
            {
                menuPanel.Close();
                Resume();
                isMenuSelectingPhase = false;
            }


        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.Close();
            Resume();
            isMenuSelectingPhase = false;
        }
    }

    public void OnJobSelectPhase()
    {
        //Debug.Log("MenuSelectPhase");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(jobPanel);

            if (index == 0)
            {
                allyRecruitPanel.SetActive(true);
                allyTextPanel.Open();
                isRecruitingPhase = true;
                isJobSelectingPhase = false;
            }
            else if (index == 1)
            {
                // 後記

            }
            else if (index == 2)
            {
                // 後記

            }
            else if (index == 3)
            {
                // 後記

            }
            else if (index == 4)
            {
                // 後記

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            jobPanel.Close();
            menuPanel.SetSelected();
            isJobSelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }


    public int GetCurrentID(WindowMenu window)
    {
        int id = window.currentID;
        return id;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
