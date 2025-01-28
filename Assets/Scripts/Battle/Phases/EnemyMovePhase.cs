using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePhase : BattlePhaseBase
{
    private string dialogue = "敵の攻撃！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("EnemyMovePhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        BattleSystemManager sm = GetBattleSystemManager();

        // 敵の行動を決めてListに格納
        // （動く敵を選ぶ→技を選ぶ→攻撃する味方を選ぶ）×（敵の数）
        //   opponent[i]→skillnumber[i]→self[i]

        System.Random random = new System.Random();

        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            // 敵の行動順はListの０→１→２で
            sm.numbersOfEnemyInAction.Add(i);
            sm.enemyObjectsInAction.Add(sm.enemyObjects[i]);

            //Debug.Log($"{i+1}番目に行動する敵：{i}");

            // 技選択は乱数を用いてランダムに
            int maxNumOfSkill = sm.enemies[i].skills.Count();
            sm.skillNumbers.Add(random.Next(0, maxNumOfSkill));

            //Debug.Log($"{i+1}番目に行動する敵の技：{sm.skillNumber[i]}");

            // 攻撃する味方の選択もランダムに
            int numOfRandomAlly = random.Next(0, sm.numOfAllies);
            sm.numbersOfAllyInAction.Add(numOfRandomAlly);
            sm.allyObjectsInAction.Add(sm.allyObjects[numOfRandomAlly]);

            //Debug.Log($"攻撃する味方：{sm.nakama[i]}");
        }

        CharacterStatusPanel allysCharacterStatusPanel = GetCharacterStatusPanel("AllyStatusPanel");
        CharacterStatusPanel enemysCharacterStatusPanel = GetCharacterStatusPanel("EnemyStatusPanel");

        // 敵の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            //冗長になるため短い名前の変数に収納
            int allyNumber = sm.numbersOfAllyInAction[i];
            int enemyNumber = sm.numbersOfEnemyInAction[i];

            //内部的な計算はここで行う
            string damageDialogue = sm.enemies[enemyNumber].UseSkill(sm.allies[allyNumber], sm.skillNumbers[i]);

            moveOfEnemy[enemyNumber].SetSelfInfo(sm.enemyObjectsInAction[i]);
            moveOfAlly [allyNumber].SetTargetInfo(sm.allyObjectsInAction[i]);

            moveOfEnemy[enemyNumber].executeAttackMove = true;
            moveOfAlly[allyNumber].executeHurtMove = true;

            battleContext.textWindow.CreateDialogueText(damageDialogue);

            yield return new WaitUntil(() => moveOfEnemy[enemyNumber].attackStart == true);
            moveOfEnemy[enemyNumber].AttackAnimationStart(sm.skillNumbers[i]);

            yield return new WaitUntil(() => moveOfEnemy[enemyNumber].attackEnd == true);
            moveOfAlly[allyNumber].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            enemysCharacterStatusPanel.refreshedCharacterNum = sm.numbersOfEnemyInAction[i];
            enemysCharacterStatusPanel.isEnemyTpRefleshed = true;

            allysCharacterStatusPanel.refreshedCharacterNum = sm.numbersOfAllyInAction[i];
            allysCharacterStatusPanel.isAllyHPRefleshed = true;

            yield return new WaitUntil(() => moveOfAlly[allyNumber].hurtEnd == true);
            moveOfEnemy[enemyNumber].executeAfterAttackMove = true;
            moveOfAlly[allyNumber].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfAlly[allyNumber].end == true);

            yield return null;
            moveOfEnemy[enemyNumber].end = false;
            moveOfAlly[allyNumber].end = false;
            moveOfEnemy[enemyNumber].self = null;
            moveOfAlly[allyNumber].target = null;
        }

        nextPhase = new SecondCheckPhase();
    }
}