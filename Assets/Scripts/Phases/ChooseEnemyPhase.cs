using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyPhase : PhaseBase
{
    private string dialogue = "対象は誰にする？";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("ChooseEnemyPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseEnemyWindowMenu.currentID;
        battleContext.chooseEnemyWindowMenu.Close();
        battleContext.chooseEnemyWindowMenu.DeleteSelectableTexts();

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.opponent.Add(index);
            string itsname = sm.enemies[index].name;
            sm.opponentObject.Add(GameObject.Find(itsname));

            if (sm.currentLoops != sm.numOfAllies-1)
            {
                sm.currentLoops++;
                nextPhase = new ChooseAllyPhase();
                battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
                battleContext.chooseAllyWindowMenu.Open();
                if (sm.currentLoops == 1)
                {
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.self[0]);
                }
                if (sm.currentLoops == 2)
                {
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.self[0]);
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.self[1]);
                }
            }
            else
            {
                nextPhase = new AllyMovePhase();
                SystemManager.allyCalcuStart = true;
            }
        }
        else
        {
            sm.skillNumber.RemoveAt(sm.currentLoops);
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[sm.self[sm.currentLoops]].GetStringsOfSkills());
            battleContext.chooseCommandWindowMenu.Open();
        }
    }
}
