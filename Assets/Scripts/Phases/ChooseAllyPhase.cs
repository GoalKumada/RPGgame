using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAllyPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        battleContext.chooseAllyWindowMenu.gameObject.SetActive(false);

        int currentID = battleContext.chooseAllyWindowMenu.currentID;

        if (currentID == 0)
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.gameObject.SetActive(true);
        }
        else if (currentID == 1)
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.gameObject.SetActive(true);
        }
        else
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.gameObject.SetActive(true);
        }
    }
}
