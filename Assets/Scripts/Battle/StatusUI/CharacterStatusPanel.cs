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
    public int refreshedCharacter;
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
            characterStatuses[refreshedCharacter].SetValueOfHP(sm.allies[refreshedCharacter]);
            characterStatuses[refreshedCharacter].RefreshGaugeOfHP(sm.allies[refreshedCharacter]);
            isAllyHPRefleshed = false;
        }

        if (isAllyTpRefleshed)
        {
            characterStatuses[refreshedCharacter].SetValueOfTP(sm.allies[refreshedCharacter]);
            characterStatuses[refreshedCharacter].RefreshGaugeOfTP(sm.allies[refreshedCharacter]);
            isAllyTpRefleshed = false;
        }

        if (isEnemyHpRefleshed)
        {
            characterStatuses[refreshedCharacter].SetValueOfHP(sm.enemies[refreshedCharacter]);
            characterStatuses[refreshedCharacter].RefreshGaugeOfHP(sm.enemies[refreshedCharacter]);
            isEnemyHpRefleshed = false;
        }

        if (isEnemyTpRefleshed)
        {
            characterStatuses[refreshedCharacter].SetValueOfTP(sm.enemies[refreshedCharacter]);
            characterStatuses[refreshedCharacter].RefreshGaugeOfTP(sm.enemies[refreshedCharacter]);
            isEnemyTpRefleshed = false;
        }
    }
}
