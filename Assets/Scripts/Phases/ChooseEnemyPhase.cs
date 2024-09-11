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

        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.opponent.Add(index);
            Enemy attackedEnemy = sm.enemies[index];
            string itsname = sm.enemies[index].name;
            sm.opponentObject[sm.currentLoops] = GameObject.Find(itsname);

            if (sm.currentLoops != sm.numOfAllies-1)
            {
                sm.currentLoops++;
                nextPhase = new ChooseAllyPhase();
                battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
                battleContext.chooseAllyWindowMenu.Open();
            }
            else
            {
                nextPhase = new ExecutePhase();
                SystemManager.start = true;
            }

        }
        else
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[sm.self[sm.currentLoops]].GetStringsOfSkills());
            battleContext.chooseCommandWindowMenu.Open();
        }
    }
}
