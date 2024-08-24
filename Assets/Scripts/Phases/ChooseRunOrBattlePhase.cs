using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRunOrBattlePhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseRunOrBattlePhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.chooseRunOrBattleWindowMenu.Close();
        
        int currentID = battleContext.chooseRunOrBattleWindowMenu.currentID;
        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (currentID == 0) // 0(たたかう)ならChooseAllyPhaseへ
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.CreateSelectableText(sm.GetStringsOfAllies());
            battleContext.chooseAllyWindowMenu.Open();
        }
        else // 1（にげる）ならRunCheckへ
        {
            nextPhase = new RunCheckPhase();
            battleContext.runCheckWindowMenu.Open();
        }
    }
}
