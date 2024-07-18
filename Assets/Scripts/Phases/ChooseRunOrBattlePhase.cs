using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRunOrBattlePhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseRunOrBattlePhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.chooseRunOrBattleWindowMenu.gameObject.SetActive(false);
        
        int currentID = battleContext.chooseRunOrBattleWindowMenu.currentID;

        if (currentID == 0) // 0(たたかう)ならChooseAllyPhaseへ
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.gameObject.SetActive(true);
        }
        else // 1（にげる）ならRunCheckへ
        {
            nextPhase = new RunCheckPhase();
            battleContext.runCheckWindowMenu.gameObject.SetActive(true);
        }
    }
}
