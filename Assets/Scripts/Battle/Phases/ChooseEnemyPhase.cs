using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyPhase : BattlePhaseBase
{
    private string dialogue = "対象は誰にする？";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift));

        int index = battleContext.chooseEnemyWindowMenu.currentID;
        battleContext.chooseEnemyWindowMenu.Close();
        battleContext.chooseEnemyWindowMenu.DeleteSelectableTexts();

        BattleSystemManager sm = GetBattleSystemManager();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.numbersOfEnemyInAction.Add(index);
            sm.enemyObjectsInAction.Add(sm.enemyObjects[index]);

            if (sm.currentLoops != sm.allies.Count - sm.numOfDeadAllies -1)
            {
                sm.currentLoops++;
                nextPhase = new ChooseAllyPhase();

                battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
                battleContext.chooseAllyWindowMenu.Open();

                //死んでるなかまのSelectableTextsを非アクティブに
                for (int i = 0; i < sm.allies.Count; i++)
                {
                    if (sm.allies[i].isDead)
                    {
                        battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(i);
                    }
                }

                //ループの回数に応じて既に選んだなかまのSelectableTextsを非表示に
                if (sm.currentLoops == 1)
                {
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[0]);
                }
                else if (sm.currentLoops == 2)
                {
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[0]);
                    battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[1]);
                }
            }
            else
            {
                nextPhase = new AllyMovePhase();
            }
        }
        else
        {
            sm.skillNumbers.RemoveAt(sm.currentLoops);

            nextPhase = new ChooseCommandPhase();

            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[sm.numbersOfAllyInAction[sm.currentLoops]].GetSkillStrings());
            battleContext.chooseCommandWindowMenu.Open();
        }
    }
}
