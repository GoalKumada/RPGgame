using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovePhase : BattlePhaseBase
{
    private string dialogue = "味方の攻撃！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("AllyMovePhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        BattleSystemManager sm = GetBattleSystemManager();
        CharacterStatusPanel allysCharacterStatusPanel = GetCharacterStatusPanel("AllyStatusPanel");
        CharacterStatusPanel enemysCharacterStatusPanel = GetCharacterStatusPanel("EnemyStatusPanel");


        // 味方の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfAllies; i++)
        {
            //冗長になるため短い名前の変数に収納
            int allyNumber = sm.numbersOfAllyInAction[i];
            int enemyNumber = sm.numbersOfEnemyInAction[i];

            //内部的な計算はここで行う
            string damageDialogue = sm.allies[allyNumber].UseSkill(sm.enemies[enemyNumber], sm.skillNumbers[i]);

            moveOfAlly[allyNumber].SetSelfInfo(sm.allyObjectsInAction[i]);
            moveOfEnemy[enemyNumber].SetTargetInfo(sm.enemyObjectsInAction[i]);

            moveOfAlly[allyNumber].executeAttackMove = true;
            moveOfEnemy[enemyNumber].executeHurtMove = true;

            battleContext.textWindow.CreateDialogueText(damageDialogue);

            yield return new WaitUntil(() => moveOfAlly[allyNumber].attackStart == true);
            moveOfAlly[allyNumber].AttackAnimationStart(sm.skillNumbers[i]);

            yield return new WaitUntil(() => moveOfAlly[allyNumber].attackEnd == true);
            moveOfEnemy[enemyNumber].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            allysCharacterStatusPanel.refreshedStatusPanelNum = ;
            allysCharacterStatusPanel.refreshedCharacterNum = allyNumber;
            allysCharacterStatusPanel.isAllyTpRefleshed = true;

            enemysCharacterStatusPanel.refreshedStatusPanelNum = ;
            enemysCharacterStatusPanel.refreshedCharacterNum = enemyNumber;
            enemysCharacterStatusPanel.isEnemyHpRefleshed = true;

            yield return new WaitUntil(() => moveOfEnemy[enemyNumber].hurtEnd == true);
            moveOfAlly[sm.numbersOfAllyInAction[i]].executeAfterAttackMove = true;
            moveOfEnemy[enemyNumber].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[enemyNumber].end == true);

            yield return null;
            moveOfAlly[allyNumber].end = false;
            moveOfEnemy[enemyNumber].end = false;
            moveOfAlly[allyNumber].self = null;
            moveOfEnemy[enemyNumber].target = null;
        }

        nextPhase = new FirstCheckPhase();
    }
}