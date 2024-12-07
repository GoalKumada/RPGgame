using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class TavernSystemController : MonoBehaviour
{
    [SerializeField] public WindowMenu menuPanel;

    [SerializeField] public WindowMenu jobPanel;
    [SerializeField] public GameObject allyRecruitPanelObject;
    [SerializeField] public WindowMenu allyTextPanel;
    [SerializeField] public GameObject statusPanelObject;
    [SerializeField] public GameObject skillPanelObject;
    [SerializeField] public GameObject recruiteCheckPanelObject;
    [SerializeField] public WindowMenu recruitOptionsPanel;
    [SerializeField] public GameObject confirmTextPanelObject;

    [SerializeField] public WindowMenu currentAllyNamePanel;
    [SerializeField] public GameObject currnetAllyImagePanelObject;
    [SerializeField] public GameObject currnetAllyStatusPanelObject;
    [SerializeField] public GameObject currentAllySkillPanelObject;
    [SerializeField] public GameObject currnetAllyEquiomentPanelObject;
    [SerializeField] public GameObject entrustCheckPanelObject;
    [SerializeField] public WindowMenu entrustCheckPanel;


    public bool isMenuSelectingPhase;

    public bool isJobSelectingPhase;
    public bool isRecruitingPhase;
    public bool isRecruitCheckPhase;
    public bool isConfirmingPhase;

    public bool isCurrentAllySelectingPhase;
    public bool isEntrustCheckPhase;

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
            OnRecruitingPhase();
        }
        else if (isRecruitCheckPhase)
        {
            OnRecruitCheckPhase();
        }
        else if (isConfirmingPhase)
        {
            OnConfirmingPhase();
        }

        else if (isCurrentAllySelectingPhase)
        {
            OnCurrentAllySelectingPhase();
        }
        else if (isEntrustCheckPhase)
        {
            OnEnrtustCheckPhase();
        }
    }

    public void OnMenuSelectPhase()
    {
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
                currentAllyNamePanel.Open();
                isCurrentAllySelectingPhase = true;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(jobPanel);

            allyRecruitPanelObject.SetActive(true);
            statusPanelObject.SetActive(true);
            skillPanelObject.SetActive(true);
            allyTextPanel.Open();
            isRecruitingPhase = true;
            isJobSelectingPhase = false;

            if (index == 0)
            {
                //
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

    public void OnRecruitingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(allyTextPanel);

            recruiteCheckPanelObject.SetActive(true);
            recruitOptionsPanel.Open();
            isRecruitCheckPhase = true;
            isRecruitingPhase = false;

            if (index == 0)
            {
                //
            }
            else if (index == 1)
            {
                // 後記

            }
            else if (index == 2)
            {
                // 後記

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            allyRecruitPanelObject.SetActive(false);
            statusPanelObject.SetActive(false);
            skillPanelObject.SetActive(false);
            allyTextPanel.Close();
            jobPanel.SetSelected();
            isRecruitingPhase = false;
            isJobSelectingPhase = true;
        }
    }

    public void OnRecruitCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(recruitOptionsPanel);

            if (index == 0)
            {
                //

                recruitOptionsPanel.SetDeselected();
                recruiteCheckPanelObject.SetActive(false);
                confirmTextPanelObject.SetActive(true);
                isRecruitCheckPhase = false;
                isConfirmingPhase = true;
            }
            else if (index == 1)
            {
                recruiteCheckPanelObject.SetActive(false);
                recruitOptionsPanel.Close();
                allyTextPanel.SetSelected();
                isRecruitCheckPhase = false;
                isRecruitingPhase = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            recruiteCheckPanelObject.SetActive(false);
            recruitOptionsPanel.Close();
            allyTextPanel.SetSelected();
            isRecruitCheckPhase = false;
            isRecruitingPhase = true;
        }
    }

    public void OnConfirmingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            confirmTextPanelObject.SetActive(false);
            allyTextPanel.SetSelected();
            isConfirmingPhase = false;
            isRecruitingPhase = true;
        }
    }

    public void OnCurrentAllySelectingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(jobPanel);

            currnetAllyImagePanelObject.SetActive(true);
            currnetAllyStatusPanelObject.SetActive(true);
            currnetAllyEquiomentPanelObject.SetActive(true);
            currentAllySkillPanelObject.SetActive(true);
            entrustCheckPanelObject.SetActive(true);
            entrustCheckPanel.Open();
            isEntrustCheckPhase = true;
            isCurrentAllySelectingPhase = false;

            if (index == 0)
            {
                // 後記
            }
            else if (index == 1)
            {
                // 後記

            }
            else if (index == 2)
            {
                // 後記

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentAllyNamePanel.Close();
            menuPanel.SetSelected();
            isCurrentAllySelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }

    public void OnEnrtustCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            int index = GetCurrentID(recruitOptionsPanel);

            currnetAllyImagePanelObject.SetActive(false);
            currnetAllyStatusPanelObject.SetActive(false);
            currnetAllyEquiomentPanelObject.SetActive(false);
            currentAllySkillPanelObject.SetActive(false);
            entrustCheckPanelObject.SetActive(false);
            entrustCheckPanel.Close();
            currentAllyNamePanel.SetSelected();
            isEntrustCheckPhase = false;
            isCurrentAllySelectingPhase = true;

            if (index == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                //
            }
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
