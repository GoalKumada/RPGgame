using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRunOrBattlePhase : PhaseBase
{
    private string dialogue = "どうする？";
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseRunOrBattlePhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.chooseRunOrBattleWindowMenu.Close();
        
        int index = battleContext.chooseRunOrBattleWindowMenu.currentID;
        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (index == 0) // 0(たたかう)ならChooseAllyPhaseへ
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.CreateSelectableText(sm.GetStringsOfAllies());
            battleContext.chooseAllyWindowMenu.Open();
        }
        else if (index == 1) // 1（にげる）ならRunCheckへ
        {
            nextPhase = new RunCheckPhase();
            battleContext.runCheckWindowMenu.Open();
        }
    }
}
