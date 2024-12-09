using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] public WindowMenu reserveAllyNamePanel;
    [SerializeField] public GameObject reserveAllyImagePanelObject;
    [SerializeField] public GameObject reserveAllyStatusPanelObject;
    [SerializeField] public GameObject reserveAllySkillPanelObject;
    [SerializeField] public GameObject reserveAllyEquiomentPanelObject;
    [SerializeField] public GameObject bringOutCheckPanelObject;
    [SerializeField] public WindowMenu bringOutCheckPanel;

    public bool isMenuSelectingPhase;
    public bool isJobSelectingPhase;
    public bool isRecruitingPhase;
    public bool isRecruitCheckPhase;
    public bool isConfirmingPhase;
    public bool isCurrentAllySelectingPhase;
    public bool isEntrustCheckPhase;
    public bool isReserveAllySelectingPhase;
    public bool isBringOutCheckPhase;

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

        else if (isReserveAllySelectingPhase)
        {
            OnReserveAllySelectingPhase();
        }
        else if (isBringOutCheckPhase)
        {
            OnBringOutCheckPhase();
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
                reserveAllyNamePanel.Open();
                isReserveAllySelectingPhase = true;
                isMenuSelectingPhase = false;
            }
            else if (index == 3)
            {
                menuPanel.Close();
                DeactivateMoneyText();
                Resume();
                isMenuSelectingPhase = false;
            }


        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.Close();
            DeactivateMoneyText();
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

            SetImageOfAllies(index);

            //

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
                //

            }
            else if (index == 2)
            {
                //

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
            int index = GetCurrentID(currentAllyNamePanel);

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
            int index = GetCurrentID(entrustCheckPanel);

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

    public void OnReserveAllySelectingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(reserveAllyNamePanel);

            reserveAllyImagePanelObject.SetActive(true);
            reserveAllyStatusPanelObject.SetActive(true);
            reserveAllyEquiomentPanelObject.SetActive(true);
            reserveAllySkillPanelObject.SetActive(true);
            bringOutCheckPanelObject.SetActive(true);
            bringOutCheckPanel.Open();
            isBringOutCheckPhase = true;
            isReserveAllySelectingPhase = false;

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
            reserveAllyNamePanel.Close();
            menuPanel.SetSelected();
            isReserveAllySelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }

    public void OnBringOutCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            int index = GetCurrentID(bringOutCheckPanel);

            reserveAllyImagePanelObject.SetActive(false);
            reserveAllyStatusPanelObject.SetActive(false);
            reserveAllyEquiomentPanelObject.SetActive(false);
            reserveAllySkillPanelObject.SetActive(false);
            bringOutCheckPanelObject.SetActive(false);
            bringOutCheckPanel.Close();
            reserveAllyNamePanel.SetSelected();
            isBringOutCheckPhase = false;
            isReserveAllySelectingPhase = true;

            if (index == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                //
            }
        }
    }

    public void SetCurrentAmountOfMoney()
    {
        GameObject moneyTextGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText");
        moneyTextGameObject.SetActive(true);
        GameObject moneyGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText/Money");
        Text currentMoney = moneyGameObject.GetComponent<Text>();
        currentMoney.text = SystemManager.money.ToString();
    }

    public void DeactivateMoneyText()
    {
        GameObject moneyTextGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText");
        moneyTextGameObject.SetActive(false);
    }

    public void SetImageOfAllies(int index)
    {
        string typeOfJob = "";
        int sizeOfWidth = 0;
        switch (index)
        {
            case 0:
                typeOfJob = "Swordsman";
                sizeOfWidth = 80;
                break;
            case 1:
                typeOfJob = "Knight";
                sizeOfWidth = 110;
                break;
            case 2:
                typeOfJob = "Archer";
                sizeOfWidth = 100;
                break;
            case 3:
                typeOfJob = "Wizard";
                sizeOfWidth = 70;
                break;
            case 4:
                typeOfJob = "Priest";
                sizeOfWidth = 70;
                break;
        }

        Sprite sprite = Resources.Load<Sprite>($"CharacterSprites/{typeOfJob}");

        for (int i = 0; i < 3; i++)
        {
            GameObject allyImage = GameObject.Find($"UI/TavernSystemCanvas/AllyRecruitPanel/Images/Image ({i})");
            RectTransform targetRectTransform = (RectTransform)allyImage.transform;
            
            Image image = allyImage.GetComponent<Image>();
            image.sprite = sprite;

            Vector2 size = targetRectTransform.sizeDelta;
            size.x = sizeOfWidth;
            targetRectTransform.sizeDelta = size;
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
