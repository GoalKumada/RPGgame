using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("ChooseCommandPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseCommandWindowMenu.currentID;
        battleContext.chooseCommandWindowMenu.Close();
        battleContext.chooseCommandWindowMenu.DeleteSelectableTexts();
        battleContext.textWindow.isChooseComandPhase = false;

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.skillNumber.Add(index);
            nextPhase = new ChooseEnemyPhase();
            battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
            battleContext.chooseEnemyWindowMenu.Open();
        }
        else
        {
            sm.nakama.RemoveAt(sm.currentLoops);
            sm.nakamaObject.RemoveAt(sm.currentLoops);
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
            battleContext.chooseAllyWindowMenu.Open();
            if (sm.currentLoops == 1)
            {
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.nakama[0]);
            }
            if (sm.currentLoops == 2)
            {
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.nakama[0]);
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.nakama[1]);
            }
        }
    }
}
