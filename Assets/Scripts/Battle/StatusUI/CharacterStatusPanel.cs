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
    public int refreshedCharacterNum;
    BattleSystemManager sm;

    private void Start()
    {
        GameObject gobj = GameObject.Find("BattleSystemManager");
        sm = gobj.GetComponent<BattleSystemManager>();

        if (gameObject.tag == "Ally") 
        {
            for (int i = 0; i < sm.allies.Count; i++)
            {
                CharacterStatus characterStatus = Instantiate(characterStatusPrefab,this.transform);
                characterStatus.SetName(sm.allies[i].characterName);
                characterStatus.SetValueOfHP(sm.allies[i]);
                characterStatus.SetValueOfTP(sm.allies[i]);
                characterStatus.RefreshGaugeOfHP(sm.allies[i]);
                characterStatus.RefreshGaugeOfTP(sm.allies[i]);
                characterStatuses.Add(characterStatus);
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            for (int i = 0; i < sm.enemies.Count; i++)
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
            characterStatuses[refreshedCharacterNum].SetValueOfHP(sm.allies[refreshedCharacterNum]);
            characterStatuses[refreshedCharacterNum].RefreshGaugeOfHP(sm.allies[refreshedCharacterNum]);
            isAllyHPRefleshed = false;
        }

        if (isAllyTpRefleshed)
        {
            characterStatuses[refreshedCharacterNum].SetValueOfTP(sm.allies[refreshedCharacterNum]);
            characterStatuses[refreshedCharacterNum].RefreshGaugeOfTP(sm.allies[refreshedCharacterNum]);
            isAllyTpRefleshed = false;
        }

        if (isEnemyHpRefleshed)
        {
            characterStatuses[refreshedCharacterNum].SetValueOfHP(sm.enemies[refreshedCharacterNum]);
            characterStatuses[refreshedCharacterNum].RefreshGaugeOfHP(sm.enemies[refreshedCharacterNum]);
            isEnemyHpRefleshed = false;
        }

        if (isEnemyTpRefleshed)
        {
            characterStatuses[refreshedCharacterNum].SetValueOfTP(sm.enemies[refreshedCharacterNum]);
            characterStatuses[refreshedCharacterNum].RefreshGaugeOfTP(sm.enemies[refreshedCharacterNum]);
            isEnemyTpRefleshed = false;
        }
    }
}
