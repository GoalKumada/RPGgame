using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAllyPhase : BattlePhaseBase
{
    private string dialogue = "誰の行動を指示しようか";
    public GameObject target;

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseAllyWindowMenu.currentID;
        battleContext.chooseAllyWindowMenu.Close();
        battleContext.chooseAllyWindowMenu.DeleteSelectableTexts();

        BattleSystemManager sm = GetBattleSystemManager();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.numbersOfAllyInAction.Add(index);
            sm.allyObjectsInAction.Add(sm.allyObjects[index]);

            nextPhase = new ChooseCommandPhase();
            battleContext.textWindow.isChooseComandPhase = true;
            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[index].GetSkillStrings());
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
                sm.numbersOfEnemyInAction.RemoveAt(sm.currentLoops);
                sm.enemyObjectsInAction.RemoveAt(sm.currentLoops);
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
                battleContext.chooseEnemyWindowMenu.Open();

                //死んでる敵のSelectableTextsを非アクティブに
                for (int i = 0; i < sm.enemies.Count; i++)
                {
                    if (sm.enemies[i].isDead)
                    {
                        battleContext.chooseEnemyWindowMenu.DeactivateTextByIndex(i);
                    }
                }
            }
        }
    }
}
