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

        GameObject gobj = GameObject.Find("BattleSystemManager");
        BattleSystemManager sm = gobj.GetComponent<BattleSystemManager>();

        GameObject allyStatusPanel = GameObject.Find("AllyStatusPanel");
        CharacterStatusPanel aspCSP = allyStatusPanel.GetComponent<CharacterStatusPanel>();

        GameObject enemyStatusPanel = GameObject.Find("EnemyStatusPanel");
        CharacterStatusPanel espCSP = enemyStatusPanel.GetComponent<CharacterStatusPanel>();

        // 味方の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfAllies; i++)
        {
            // 味方の攻撃によるダメージの計算をする
            sm.allies[sm.numbersOfAllyInAction[i]].UseSkill(sm.enemies[sm.numbersOfEnemyInAction[i]], sm.skillNumbers[i]);

            moveOfAlly[sm.numbersOfAllyInAction[i]].SetSelfInfo(sm.allyObjectsInAction[i]);
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].SetTargetInfo(sm.enemyObjectsInAction[i]);

            moveOfAlly[sm.numbersOfAllyInAction[i]].executeAttackMove = true;
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].executeHurtMove = true;

            yield return new WaitUntil(() => moveOfAlly[sm.numbersOfAllyInAction[i]].attackStart == true);
            moveOfAlly[sm.numbersOfAllyInAction[i]].AttackAnimationStart(sm.skillNumbers[i]);

            Debug.Log("aaa");

            yield return new WaitUntil(() => moveOfAlly[sm.numbersOfAllyInAction[i]].attackEnd == true);
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            aspCSP.refreshedCharacter = sm.numbersOfAllyInAction[i];
            aspCSP.isAllyTpRefleshed = true;

            espCSP.refreshedCharacter = sm.numbersOfEnemyInAction[i];
            espCSP.isEnemyHpRefleshed = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.numbersOfEnemyInAction[i]].hurtEnd == true);
            moveOfAlly[sm.numbersOfAllyInAction[i]].executeAfterAttackMove = true;
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.numbersOfEnemyInAction[i]].end == true);

            yield return null;
            moveOfAlly[sm.numbersOfAllyInAction[i]].end = false;
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].end = false;
            moveOfAlly[sm.numbersOfAllyInAction[i]].self = null;
            moveOfEnemy[sm.numbersOfEnemyInAction[i]].target = null;
        }

        nextPhase = new FirstCheckPhase();
    }
}