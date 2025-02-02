using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : BattlePhaseBase
{
    private string dialogue = "MPが足りない！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        start:
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift));

        int index = battleContext.chooseCommandWindowMenu.currentID;
        battleContext.chooseCommandWindowMenu.Close();
        battleContext.chooseCommandWindowMenu.DeleteSelectableTexts();
        battleContext.textWindow.isChooseComandPhase = false;

        BattleSystemManager sm = GetBattleSystemManager();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 現在のTPが必要TPより少なかったら選択できない
            if (sm.allies[sm.numbersOfAllyInAction[sm.numbersOfAllyInAction.Count-1]].currentTP < sm.allies[sm.numbersOfAllyInAction[sm.numbersOfAllyInAction.Count - 1]].skills[index].requiredTP)
            {
                yield return null;
                battleContext.textWindow.isChooseComandPhase = false;
                battleContext.textWindow.CreateDialogueText(dialogue);
                
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[sm.numbersOfAllyInAction.Count-1].GetSkillStrings());
                battleContext.chooseCommandWindowMenu.Open();
                battleContext.textWindow.isChooseComandPhase = true;

                goto start;
            }
            else
            {
                sm.skillNumbers.Add(index);
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
        else
        {
            sm.numbersOfAllyInAction.RemoveAt(sm.currentLoops);
            sm.allyObjectsInAction.RemoveAt(sm.currentLoops);

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

            if (sm.currentLoops == 1)
            {
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[0]);
            }
            if (sm.currentLoops == 2)
            {
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[0]);
                battleContext.chooseAllyWindowMenu.DeactivateTextByIndex(sm.numbersOfAllyInAction[1]);
            }
        }
    }
}
