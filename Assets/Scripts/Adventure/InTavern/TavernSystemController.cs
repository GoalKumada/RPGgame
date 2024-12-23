using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] public GameObject notificationPanelObject;
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
    [SerializeField] public GameObject moneyTextGameObject;

    public bool isMenuSelectingPhase;
    private bool isJobSelectingPhase;
    private bool isRecruitingPhase;
    private bool isNotificationPhase;
    private bool isRecruitCheckPhase;
    private bool isConfirmingPhase;
    private bool isCurrentAllySelectingPhase;
    private bool isEntrustCheckPhase;
    private bool isReserveAllySelectingPhase;
    private bool isBringOutCheckPhase;

    private string typeOfJob = "";
    private Ally[] nameForDisplay;
    [SerializeField] private Ally[] swordsmans;
    [SerializeField] private Ally[] knights;
    [SerializeField] private Ally[] archers;
    [SerializeField] private Ally[] wizards;
    [SerializeField] private Ally[] priests;
    [SerializeField] private Text[] statusTexts;

    private int preIndex = 10;
    private GameObject allyCandidate;
    private int limitOfAllyBringingAlong = 3;
    private bool isAlreadyEmployed = false;
    private bool isNotHaveEnoughMoney = false;
    private bool isLimitOver = false;

    
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
        else if (isNotificationPhase)
        {
            OnNotificationPhase();
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

    // 各フェーズの制御
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
        int index = GetCurrentID(dataForRecruiting.allyTextPanel);

        if (index != preIndex)
        {
            SetStatusOfAllies(index);
            SetSkillsOfAlliesForRecruiting(index);
        }
        preIndex = index;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dataForRecruiting.allyTextPanel.SetDeselected();
            GetAllyCandidate(index);
            
            if (allyCandidate.GetComponent<Ally>().isEmployed) //既に雇われていたら
            {
                dataForRecruiting.notificationPanelObject.SetActive(true);
                isAlreadyEmployed = true;
                SetNotificationText();
                isNotificationPhase = true;
                isRecruitingPhase = false;
            }
            else if (allyCandidate.GetComponent<Ally>().moneyNeeded > SystemManager.money) //必要資金が足りなかったら
            {
                dataForRecruiting.notificationPanelObject.SetActive(true);
                isNotHaveEnoughMoney = true;
                SetNotificationText();
                isNotificationPhase = true;
                isRecruitingPhase = false;
            }
            else if (SystemManager.currentPartyMember.Count >= limitOfAllyBringingAlong) //なかまにできる人数の上限に達していたら
            {
                dataForRecruiting.notificationPanelObject.SetActive(true);
                isLimitOver = true;
                SetNotificationText();
                isNotificationPhase = true;
                isRecruitingPhase = false;
            }
            else
            {
                dataForRecruiting.recruiteCheckPanelObject.SetActive(true);
                dataForRecruiting.recruitOptionsPanel.Open();
                isRecruitCheckPhase = true;
                isRecruitingPhase = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            dataForRecruiting.allyRecruitPanelObject.SetActive(false);
            dataForRecruiting.statusPanelObject.SetActive(false);
            dataForRecruiting.skillPanelObject.SetActive(false);
            dataForRecruiting.allyTextPanel.Close();
            dataForRecruiting.jobPanel.SetSelected();

            preIndex++; // 0以外の整数にするため

            isRecruitingPhase = false;
            isJobSelectingPhase = true;
        }
    }

    public void OnNotificationPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            dataForRecruiting.notificationPanelObject.SetActive(false);
            dataForRecruiting.allyTextPanel.SetSelected();
            isRecruitingPhase = true;
            isNotificationPhase = false;
        }
    }

    public void OnRecruitCheckPhase()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = GetCurrentID(dataForRecruiting.recruitOptionsPanel);

            if (index == 0)
            {
                AddAllyToParty();
                allyCandidate.GetComponent<Ally>().isEmployed = true;
                
                // 
                foreach (GameObject a in SystemManager.currentPartyMember)
                {
                    Debug.Log(a.GetComponent<Ally>().characterName);
                }

                dataForRecruiting.recruitOptionsPanel.SetDeselected();
                dataForRecruiting.recruiteCheckPanelObject.SetActive(false);
                dataForRecruiting.confirmTextPanelObject.SetActive(true);

                SetConfirmTextInfo();

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


    // 雇いたい仲間の画像を設定
    public void SetImageOfAllies(int index)
    {
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

    // 仲間の名前を設定
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

    // 仲間のステータスを取得して表示
    public void SetStatusOfAllies(int index)
    {
        switch (typeOfJob)
        {
            case "Swordsman":
                statusTexts[0].text = swordsmans[index].maxHP.ToString();
                statusTexts[1].text = swordsmans[index].maxTP.ToString();
                statusTexts[2].text = swordsmans[index].ATK.ToString();
                statusTexts[3].text = swordsmans[index].DEF.ToString();
                statusTexts[4].text = swordsmans[index].SPEED.ToString();
                break;
            case "Knight":
                statusTexts[0].text = knights[index].maxHP.ToString();
                statusTexts[1].text = knights[index].maxTP.ToString();
                statusTexts[2].text = knights[index].ATK.ToString();
                statusTexts[3].text = knights[index].DEF.ToString();
                statusTexts[4].text = knights[index].SPEED.ToString();
                break;
            case "Archer":
                statusTexts[0].text = archers[index].maxHP.ToString();
                statusTexts[1].text = archers[index].maxTP.ToString();
                statusTexts[2].text = archers[index].ATK.ToString();
                statusTexts[3].text = archers[index].DEF.ToString();
                statusTexts[4].text = archers[index].SPEED.ToString();
                break;
            case "Wizard":
                statusTexts[0].text = wizards[index].maxHP.ToString();
                statusTexts[1].text = wizards[index].maxTP.ToString();
                statusTexts[2].text = wizards[index].ATK.ToString();
                statusTexts[3].text = wizards[index].DEF.ToString();
                statusTexts[4].text = wizards[index].SPEED.ToString();
                break;
            case "Priest":
                statusTexts[0].text = priests[index].maxHP.ToString();
                statusTexts[1].text = priests[index].maxTP.ToString();
                statusTexts[2].text = priests[index].ATK.ToString();
                statusTexts[3].text = priests[index].DEF.ToString();
                statusTexts[4].text = priests[index].SPEED.ToString();
                break;
        }
    }

    // 仲間のスキルを取得して表示
    public void SetSkillsOfAlliesForRecruiting(int index)
    {
        SkillPanel skillPanel = dataForRecruiting.skillPanelObject.GetComponent<SkillPanel>();

        foreach (GameObject skillText in skillPanel.skillTexts)
        {
            Destroy(skillText);
        }

        switch (typeOfJob)
        {
            case "Swordsman":
                for (int i = 0; i < swordsmans[index].skills.Length; i++)
                {
                    GameObject skillText = Instantiate(skillPanel.skillTextPrefab,dataForRecruiting.skillPanelObject.transform);
                    skillText.GetComponent<Text>().text = swordsmans[index].skills[i].skillName.ToString();
                    skillPanel.skillTexts.Add(skillText);
                }
                break;
            case "Knight":
                for (int i = 0; i < knights[index].skills.Length; i++)
                {
                    GameObject skillText = Instantiate(skillPanel.skillTextPrefab, dataForRecruiting.skillPanelObject.transform);
                    skillText.GetComponent<Text>().text = knights[index].skills[i].skillName.ToString();
                    skillPanel.skillTexts.Add(skillText);
                }
                break;
            case "Archer":
                for (int i = 0; i < archers[index].skills.Length; i++)
                {
                    GameObject skillText = Instantiate(skillPanel.skillTextPrefab, dataForRecruiting.skillPanelObject.transform);
                    skillText.GetComponent<Text>().text = archers[index].skills[i].skillName.ToString();
                    skillPanel.skillTexts.Add(skillText);
                }
                break;
            case "Wizard":
                for (int i = 0; i < wizards[index].skills.Length; i++)
                {
                    GameObject skillText = Instantiate(skillPanel.skillTextPrefab, dataForRecruiting.skillPanelObject.transform);
                    skillText.GetComponent<Text>().text = wizards[index].skills[i].skillName.ToString();
                    skillPanel.skillTexts.Add(skillText);
                }
                break;
            case "Priest":
                for (int i = 0; i < priests[index].skills.Length; i++)
                {
                    GameObject skillText = Instantiate(skillPanel.skillTextPrefab, dataForRecruiting.skillPanelObject.transform);
                    skillText.GetComponent<Text>().text = priests[index].skills[i].skillName.ToString();
                    skillPanel.skillTexts.Add(skillText);
                }
                break;
        }
    }

    // 仲間候補のオブジェクトを取得
    public void GetAllyCandidate(int index)
    {
        if (index == 0)
        {
            allyCandidate = GameObject.Find($"Ally/{typeOfJob}Rookie");
        }
        else if (index == 1)
        {
            allyCandidate = GameObject.Find($"Ally/{typeOfJob}Veteran");
        }
        else if (index == 2)
        {
            allyCandidate = GameObject.Find($"Ally/{typeOfJob}Legendary");
        }
    }

    // 確認画面の情報を取得して設定
    public void SetConfirmTextInfo()
    {
        GameObject allyImageObject = GameObject.Find("UI/TavernSystemCanvas/ConfirmTextPanel/AllyImage");
        Image allyImage = allyImageObject.GetComponent<Image>();
        allyImage.sprite = allyCandidate.GetComponent<SpriteRenderer>().sprite;
        allyImage.color = allyCandidate.GetComponent<SpriteRenderer>().color;

        GameObject nameTextObject = GameObject.Find("UI/TavernSystemCanvas/ConfirmTextPanel/NameText");
        Text text = nameTextObject.GetComponent<Text>();
        text.text = allyCandidate.GetComponent<Ally>().characterName;

    }

    // 警告表示の内容を設定
    public void SetNotificationText()
    {
        GameObject notificotionTextObject = GameObject.Find("UI/TavernSystemCanvas/NotificationTextPanel/Text");
        Text text = notificotionTextObject.GetComponent<Text>();

        if (isAlreadyEmployed)
        {
            text.text = "この人はすでに\nなかまになっています";
        }

        if (isNotHaveEnoughMoney)
        {
            text.text = "この人を雇うのに\n十分なお金がありません";
        }

        if (isLimitOver)
        {
            text.text = "一度に雇うことができるのは\n３人までです";
        }

        isAlreadyEmployed = false;
        isNotHaveEnoughMoney = false;
        isLimitOver = false;
    }

    // なかまをパーティーに加える
    public void AddAllyToParty()
    {
        SystemManager.currentPartyMember.Add(allyCandidate);
        SystemManager.money -= allyCandidate.GetComponent<Ally>().moneyNeeded;
        SetCurrentAmountOfMoney();
        Debug.Log(SystemManager.money);
    }

    // お金の表示をオンオフ
    public void SetCurrentAmountOfMoney()
    {
        moneyTextGameObject.SetActive(true);
        Text currentMoney = moneyTextGameObject.GetComponentInChildren<Text>();
        currentMoney.text = SystemManager.money.ToString();
    }

    public void DeactivateMoneyText()
    {
        moneyTextGameObject.SetActive(false);
    }

    // 現在選択中のテキストが何番目の子要素かを取得
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
