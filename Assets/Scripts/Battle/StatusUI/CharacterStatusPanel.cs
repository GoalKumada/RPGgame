using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusPanel : MonoBehaviour
{
    [SerializeField] List<CharacterStatus> characterStatuses = new List<CharacterStatus>();
    [SerializeField] CharacterStatus characterStatusPrefab = default;
    public bool isAllyHPRefleshed = false; 
    public bool isAllyTpRefleshed = false;
    public bool isEnemyHpRefleshed = false; 
    public bool isEnemyTpRefleshed = false;
    public int refreshedStatusPanelNum;
    public int refreshedCharacterNum;
    BattleSystemManager sm;

    private void Start()
    {
        GameObject gobj = GameObject.Find("BattleSystemManager");
        sm = gobj.GetComponent<BattleSystemManager>();

        if (gameObject.tag == "Ally") 
        {
            for (int i = 0; i < sm.numOfAllies; i++)
            {
                CharacterStatus characterStatus = Instantiate(characterStatusPrefab,this.transform);
                characterStatus.SetName(sm.allies[i].characterName);
                characterStatus.SetValueOfHP(sm.allies[i]);
                characterStatus.SetValueOfTP(sm.allies[i]);
                characterStatuses.Add(characterStatus);
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            for (int i = 0; i < sm.numOfEnemies; i++)
            {
                CharacterStatus characterStatus = Instantiate(characterStatusPrefab, this.transform);
                characterStatus.SetName(sm.enemies[i].characterName);
                characterStatus.SetValueOfHP(sm.enemies[i]);
                characterStatus.SetValueOfTP(sm.enemies[i]);
                characterStatuses.Add(characterStatus);
            }
        }

    }

    private void Update()
    {
        if (isAllyHPRefleshed)
        {
            characterStatuses[refreshedStatusPanelNum].SetValueOfHP(sm.allies[refreshedCharacterNum]);
            characterStatuses[refreshedStatusPanelNum].RefreshGaugeOfHP(sm.allies[refreshedCharacterNum]);
            isAllyHPRefleshed = false;
        }

        if (isAllyTpRefleshed)
        {
            characterStatuses[refreshedStatusPanelNum].SetValueOfTP(sm.allies[refreshedCharacterNum]);
            characterStatuses[refreshedStatusPanelNum].RefreshGaugeOfTP(sm.allies[refreshedCharacterNum]);
            isAllyTpRefleshed = false;
        }

        if (isEnemyHpRefleshed)
        {
            characterStatuses[refreshedStatusPanelNum].SetValueOfHP(sm.enemies[refreshedCharacterNum]);
            characterStatuses[refreshedStatusPanelNum].RefreshGaugeOfHP(sm.enemies[refreshedCharacterNum]);
            isEnemyHpRefleshed = false;
        }

        if (isEnemyTpRefleshed)
        {
            characterStatuses[refreshedStatusPanelNum].SetValueOfTP(sm.enemies[refreshedCharacterNum]);
            characterStatuses[refreshedStatusPanelNum].RefreshGaugeOfTP(sm.enemies[refreshedCharacterNum]);
            isEnemyTpRefleshed = false;
        }
    }
}
