using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAllyPhase : PhaseBase
{
    public static GameObject self;
    public static int attacker;
    string ""
    
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.chooseAllyWindowMenu.Close();

        int currentID = battleContext.chooseAllyWindowMenu.currentID;

        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                attacker = 0;
                self = GameObject.Find("Warrior");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[0].GetStringsOfSkills());
                battleContext.chooseCommandWindowMenu.Open();
            }
            else if (currentID == 1)
            {
                attacker = 1;
                self = GameObject.Find("Warrior (1)");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[1].GetStringsOfSkills());
                battleContext.chooseCommandWindowMenu.Open();
            }
            else
            {
                attacker = 2;
                self = GameObject.Find("Warrior (2)");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[2].GetStringsOfSkills());
                battleContext.chooseCommandWindowMenu.Open();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            battleContext.chooseRunOrBattleWindowMenu.Select();
        }
    }
}
