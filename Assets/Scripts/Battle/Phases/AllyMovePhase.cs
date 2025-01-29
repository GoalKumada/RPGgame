using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovePhase : BattlePhaseBase
{
    private string dialogue = "味方の攻撃！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        battleContext.textWindow.CreateDialogueText(dialogue);

        BattleSystemManager sm = GetBattleSystemManager();
        CharacterStatusPanel allysCharacterStatusPanel = GetCharacterStatusPanel("AllyStatusPanel");
        CharacterStatusPanel enemysCharacterStatusPanel = GetCharacterStatusPanel("EnemyStatusPanel");

        int deathCount = 0;

        // 味方の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.allies.Count; i++)
        {
            if (sm.allies[i].isDead)
            {
                deathCount++;
                continue;
            }

            //冗長になるため短い名前の変数に収納
            int allyNumber = sm.numbersOfAllyInAction[i - deathCount];
            int enemyNumber = sm.numbersOfEnemyInAction[i - deathCount];

            //内部的な計算はここで行う
            string damageDialogue = sm.allies[allyNumber].UseSkill(sm.enemies[enemyNumber], sm.skillNumbers[i - deathCount]);

            moveOfAlly[allyNumber].SetSelfInfo(sm.allyObjectsInAction[i - deathCount]);
            moveOfEnemy[enemyNumber].SetTargetInfo(sm.enemyObjectsInAction[i - deathCount]);

            moveOfAlly[allyNumber].executeAttackMove = true;
            moveOfEnemy[enemyNumber].executeHurtMove = true;

            battleContext.textWindow.CreateDialogueText(damageDialogue);

            yield return new WaitUntil(() => moveOfAlly[allyNumber].attackStart == true);
            moveOfAlly[allyNumber].AttackAnimationStart(sm.skillNumbers[i - deathCount]);

            yield return new WaitUntil(() => moveOfAlly[allyNumber].attackEnd == true);
            moveOfEnemy[enemyNumber].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            allysCharacterStatusPanel.refreshedCharacterNum = allyNumber;
            allysCharacterStatusPanel.isAllyTpRefleshed = true;

            enemysCharacterStatusPanel.refreshedCharacterNum = enemyNumber;
            enemysCharacterStatusPanel.isEnemyHpRefleshed = true;

            yield return new WaitUntil(() => moveOfEnemy[enemyNumber].hurtEnd == true);
            moveOfAlly[sm.numbersOfAllyInAction[i - deathCount]].executeAfterAttackMove = true;
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