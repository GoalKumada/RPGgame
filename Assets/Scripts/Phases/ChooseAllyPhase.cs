using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAllyPhase : PhaseBase
{
    private string dialogue = "誰の行動を指示しようか";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");

        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseAllyWindowMenu.currentID;
        battleContext.chooseAllyWindowMenu.Close();
        battleContext.chooseAllyWindowMenu.DeleteSelectableTexts();

        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.self.Add(index);
            string itsname = sm.allies[index].name;
            sm.selfObject.Add(GameObject.Find(itsname));

            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[index].GetStringsOfSkills());
            battleContext.chooseCommandWindowMenu.Open();
        }
        else
        {
            if (sm.currentLoops == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();
            }
            else
            {
                sm.currentLoops--;
                sm.opponent.RemoveAt(sm.currentLoops);
                sm.opponentObject.RemoveAt(sm.currentLoops);
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
                battleContext.chooseEnemyWindowMenu.Open();
            }
        }
    }
}
