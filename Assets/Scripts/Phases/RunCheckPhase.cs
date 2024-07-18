using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCheckPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("RunCheckPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.runCheckWindowMenu.gameObject.SetActive(false);

        int currentID = battleContext.runCheckWindowMenu.currentID;

        if (currentID == 0)
        {
            nextPhase = new StartPhase();
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.gameObject.SetActive(true);
        }
    }
}
