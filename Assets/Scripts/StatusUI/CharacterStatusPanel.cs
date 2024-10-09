using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusPanel : MonoBehaviour
{
    [SerializeField] List<CharacterStatus> characterStatuses = new List<CharacterStatus>();
    [SerializeField] CharacterStatus characterStatusPrefab = default;
    public bool refreshAllyHP = false; 
    public bool refreshAllyTP = false;
    public bool refreshEnemyHP = false; 
    public bool refreshEnemyTP = false; 
    public int refreshedChracter;
    SystemManager sm;

    private void Start()
    {
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

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
        if (refreshAllyHP)
        {
            characterStatuses[refreshedChracter].SetValueOfHP(sm.allies[refreshedChracter]);
            characterStatuses[refreshedChracter].RefreshGaugeOfHP(sm.allies[refreshedChracter]);
            refreshAllyHP = false;
        }

        if (refreshAllyTP)
        {
            characterStatuses[refreshedChracter].SetValueOfTP(sm.allies[refreshedChracter]);
            characterStatuses[refreshedChracter].RefreshGaugeOfTP(sm.allies[refreshedChracter]);
            refreshAllyTP = false;
        }

        if (refreshEnemyHP)
        {
            characterStatuses[refreshedChracter].SetValueOfHP(sm.enemies[refreshedChracter]);
            characterStatuses[refreshedChracter].RefreshGaugeOfHP(sm.enemies[refreshedChracter]);
            refreshEnemyHP = false;
        }

        if (refreshEnemyTP)
        {
            characterStatuses[refreshedChracter].SetValueOfTP(sm.enemies[refreshedChracter]);
            characterStatuses[refreshedChracter].RefreshGaugeOfTP(sm.enemies[refreshedChracter]);
            refreshEnemyTP = false;
        }
    }
}
