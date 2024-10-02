using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusPanel : MonoBehaviour
{
    [SerializeField] List<CharacterStatus> characterStatuses = new List<CharacterStatus>();
    [SerializeField] CharacterStatus characterStatusPrefab = default;
    private float a = 500f;
    private float b = 30f;

    void Start()
    {
        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();
        for (int i = 0; i < sm.numOfAllies; i++)
        {
            CharacterStatus characterStatus = Instantiate(characterStatusPrefab,this.transform);
            characterStatus.SetName(sm.allies[i].characterName);
            characterStatus.SetValueOfHP(sm.allies[i].HP);
            characterStatus.SetValueOfTP(sm.allies[i].TP);
            characterStatuses.Add(characterStatus);
        }
    }

    void Update()
    {
        
    }





}
