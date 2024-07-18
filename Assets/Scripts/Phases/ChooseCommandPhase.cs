using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseCommandPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.chooseCommandWindowMenu.gameObject.SetActive(false);

        int currentID = battleContext.chooseCommandWindowMenu.currentID;

        if (currentID == 0)
        {
            nextPhase = new ChooseEnemyPhase();
            battleContext.chooseEnemyWindowMenu.gameObject.SetActive(true);
        }
        else if (currentID == 1)
        {
            nextPhase = new ChooseEnemyPhase();
            battleContext.chooseEnemyWindowMenu.gameObject.SetActive(true);
        }
        else
        {
            nextPhase = new ChooseEnemyPhase();
            battleContext.chooseEnemyWindowMenu.gameObject.SetActive(true);
        }
    }
}
