using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DateForRecruiting
{
    [SerializeField] public WindowMenu jobPanel;
    [SerializeField] public GameObject allyRecruitPanelObject;
    [SerializeField] public WindowMenu allyTextPanel;
    [SerializeField] public GameObject statusPanelObject;
    [SerializeField] public GameObject skillPanelObject;
    [SerializeField] public GameObject recruiteCheckPanelObject;
    [SerializeField] public WindowMenu recruitOptionsPanel;
    [SerializeField] public GameObject confirmTextPanelObject;
}

[System.Serializable]
public class DateForEntrusting
{
    [SerializeField] public WindowMenu currentAllyNamePanel;
    [SerializeField] public GameObject currnetAllyImagePanelObject;
    [SerializeField] public GameObject currnetAllyStatusPanelObject;
    [SerializeField] public GameObject currentAllySkillPanelObject;
    [SerializeField] public GameObject currnetAllyEquiomentPanelObject;
    [SerializeField] public GameObject entrustCheckPanelObject;
    [SerializeField] public WindowMenu entrustCheckPanel;
}

[System.Serializable]
public class DateForBringingOut
{
    [SerializeField] public WindowMenu reserveAllyNamePanel;
    [SerializeField] public GameObject reserveAllyImagePanelObject;
    [SerializeField] public GameObject reserveAllyStatusPanelObject;
    [SerializeField] public GameObject reserveAllySkillPanelObject;
    [SerializeField] public GameObject reserveAllyEquiomentPanelObject;
    [SerializeField] public GameObject bringOutCheckPanelObject;
    [SerializeField] public WindowMenu bringOutCheckPanel;
}

public class TavernSystemController : MonoBehaviour
{
    [SerializeField] public WindowMenu menuPanel;
    [SerializeField] private DateForRecruiting dataForRecruiting;
    [SerializeField] private DateForEntrusting dataForEntrusting;
    [SerializeField] private DateForBringingOut dataForBringingOut;

    public bool isMenuSelectingPhase;
    public bool isJobSelectingPhase;
    public bool isRecruitingPhase;
    public bool isRecruitCheckPhase;
    public bool isConfirmingPhase;
    public bool isCurrentAllySelectingPhase;
    public bool isEntrustCheckPhase;
    public bool isReserveAllySelectingPhase;
    public bool isBringOutCheckPhase;

    Ally[] nameForDisplay;
    [SerializeField] private Ally[] swordsmans;
    [SerializeField] private Ally[] knights;
    [SerializeField] private Ally[] archers;
    [SerializeField] private Ally[] wizards;
    [SerializeField] private Ally[] priests;

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
                dataForRecruiting.jobPanel.Open();
                isJobSelectingPhase = true;
                isMenuSelectingPhase = false;
            }
            else if (index == 1)
            {
                dataForEntrusting.currentAllyNamePanel.Open();
                isCurrentAllySelectingPhase = true;
                isMenuSelectingPhase = false;
            }
            else if (index == 2)
            {
                dataForBringingOut.reserveAllyNamePanel.Open();
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
            int index = GetCurrentID(dataForRecruiting.jobPanel);

            dataForRecruiting.allyRecruitPanelObject.SetActive(true);
            dataForRecruiting.statusPanelObject.SetActive(true);
            dataForRecruiting.skillPanelObject.SetActive(true);
            dataForRecruiting.allyTextPanel.Open();

            isRecruitingPhase = true;
            isJobSelectingPhase = false;

            SetImageOfAllies(index);
            SetNameOfAllies(index);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            dataForRecruiting.jobPanel.Close();
            menuPanel.SetSelected();
            isJobSelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }

    public void OnRecruitingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(dataForRecruiting.allyTextPanel);

            dataForRecruiting.recruiteCheckPanelObject.SetActive(true);
            dataForRecruiting.recruitOptionsPanel.Open();
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
            dataForRecruiting.allyRecruitPanelObject.SetActive(false);
            dataForRecruiting.statusPanelObject.SetActive(false);
            dataForRecruiting.skillPanelObject.SetActive(false);
            dataForRecruiting.allyTextPanel.Close();
            dataForRecruiting.jobPanel.SetSelected();
            isRecruitingPhase = false;
            isJobSelectingPhase = true;
        }
    }

    public void OnRecruitCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(dataForRecruiting.recruitOptionsPanel);

            if (index == 0)
            {
                //

                dataForRecruiting.recruitOptionsPanel.SetDeselected();
                dataForRecruiting.recruiteCheckPanelObject.SetActive(false);
                dataForRecruiting.confirmTextPanelObject.SetActive(true);
                isRecruitCheckPhase = false;
                isConfirmingPhase = true;
            }
            else if (index == 1)
            {
                dataForRecruiting.recruiteCheckPanelObject.SetActive(false);
                dataForRecruiting.recruitOptionsPanel.Close();
                dataForRecruiting.allyTextPanel.SetSelected();
                isRecruitCheckPhase = false;
                isRecruitingPhase = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            dataForRecruiting.recruiteCheckPanelObject.SetActive(false);
            dataForRecruiting.recruitOptionsPanel.Close();
            dataForRecruiting.allyTextPanel.SetSelected();
            isRecruitCheckPhase = false;
            isRecruitingPhase = true;
        }
    }

    public void OnConfirmingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            dataForRecruiting.confirmTextPanelObject.SetActive(false);
            dataForRecruiting.allyTextPanel.SetSelected();
            isConfirmingPhase = false;
            isRecruitingPhase = true;
        }
    }

    public void OnCurrentAllySelectingPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(dataForEntrusting.currentAllyNamePanel);

            dataForEntrusting.currnetAllyImagePanelObject.SetActive(true);
            dataForEntrusting.currnetAllyStatusPanelObject.SetActive(true);
            dataForEntrusting.currnetAllyEquiomentPanelObject.SetActive(true);
            dataForEntrusting.currentAllySkillPanelObject.SetActive(true);
            dataForEntrusting.entrustCheckPanelObject.SetActive(true);
            dataForEntrusting.entrustCheckPanel.Open();
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
            dataForEntrusting.currentAllyNamePanel.Close();
            menuPanel.SetSelected();
            isCurrentAllySelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }

    public void OnEnrtustCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            int index = GetCurrentID(dataForEntrusting.entrustCheckPanel);

            dataForEntrusting.currnetAllyImagePanelObject.SetActive(false);
            dataForEntrusting.currnetAllyStatusPanelObject.SetActive(false);
            dataForEntrusting.currnetAllyEquiomentPanelObject.SetActive(false);
            dataForEntrusting.currentAllySkillPanelObject.SetActive(false);
            dataForEntrusting.entrustCheckPanelObject.SetActive(false);
            dataForEntrusting.entrustCheckPanel.Close();
            dataForEntrusting.currentAllyNamePanel.SetSelected();
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
            int index = GetCurrentID(dataForBringingOut.reserveAllyNamePanel);

            dataForBringingOut.reserveAllyImagePanelObject.SetActive(true);
            dataForBringingOut.reserveAllyStatusPanelObject.SetActive(true);
            dataForBringingOut.reserveAllyEquiomentPanelObject.SetActive(true);
            dataForBringingOut.reserveAllySkillPanelObject.SetActive(true);
            dataForBringingOut.bringOutCheckPanelObject.SetActive(true);
            dataForBringingOut.bringOutCheckPanel.Open();
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
            dataForBringingOut.reserveAllyNamePanel.Close();
            menuPanel.SetSelected();
            isReserveAllySelectingPhase = false;
            isMenuSelectingPhase = true;
        }
    }

    public void OnBringOutCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            int index = GetCurrentID(dataForBringingOut.bringOutCheckPanel);

            dataForBringingOut.reserveAllyImagePanelObject.SetActive(false);
            dataForBringingOut.reserveAllyStatusPanelObject.SetActive(false);
            dataForBringingOut.reserveAllyEquiomentPanelObject.SetActive(false);
            dataForBringingOut.reserveAllySkillPanelObject.SetActive(false);
            dataForBringingOut.bringOutCheckPanelObject.SetActive(false);
            dataForBringingOut.bringOutCheckPanel.Close();
            dataForBringingOut.reserveAllyNamePanel.SetSelected();
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
        GameObject moneyGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText/Money");
        GameObject dollarTextGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText/$Text");
        moneyGameObject.SetActive(true);
        dollarTextGameObject.SetActive(true);
        Text currentMoney = moneyGameObject.GetComponent<Text>();
        currentMoney.text = SystemManager.money.ToString();
    }

    public void DeactivateMoneyText()
    {
        GameObject moneyGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText/Money");
        GameObject dollarTextGameObject = GameObject.Find("UI/TavernSystemCanvas/MoneyText/$Text");
        moneyGameObject.SetActive(false);
        dollarTextGameObject.SetActive(false);
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
                sizeOfWidth = 90;
                break;
            case 3:
                typeOfJob = "Wizard";
                sizeOfWidth = 70;
                break;
            case 4:
                typeOfJob = "Priest";
                sizeOfWidth = 60;
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

    public void SetNameOfAllies(int index)
    {
        switch (index)
        {
            case 0:
                nameForDisplay = swordsmans;
                break;
            case 1:
                nameForDisplay = knights;
                break;
            case 2:
                nameForDisplay = archers;
                break;
            case 3:
                nameForDisplay = wizards;
                break;
            case 4:
                nameForDisplay = priests;
                break;
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject allyNameTextObject = GameObject.Find($"UI/TavernSystemCanvas/AllyRecruitPanel/AllyNameTexts/AllyNameText ({i})");
            Text allyNameText = allyNameTextObject.GetComponent<Text>();           
            allyNameText.text = nameForDisplay[i].characterName;
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
