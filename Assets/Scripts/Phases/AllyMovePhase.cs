using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovePhase : PhaseBase
{
    private string dialogue = "味方の攻撃！";

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("ExecutePhase");
        battleContext.textWindow.CreateDialogueText(dialogue);

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        GameObject allyStatusPanel = GameObject.Find("AllyStatusPanel");
        CharacterStatusPanel aspCSP = allyStatusPanel.GetComponent<CharacterStatusPanel>();

        GameObject enemyStatusPanel = GameObject.Find("EnemyStatusPanel");
        CharacterStatusPanel espCSP = enemyStatusPanel.GetComponent<CharacterStatusPanel>();

        Debug.Log(aspCSP);
        Debug.Log(espCSP);

        // 味方の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfAllies; i++)
        {
            // 味方の攻撃によるダメージの計算をする
            sm.allies[sm.nakama[i]].UseSkill(sm.enemies[sm.teki[i]], sm.skillNumber[i]);

            moveOfAlly[sm.nakama[i]].SetSelfInfo(sm.nakamaObject[i]);
            moveOfEnemy[sm.teki[i]].SetTargetInfo(sm.tekiObject[i]);

            moveOfAlly[sm.nakama[i]].executeAttackMove = true;
            moveOfEnemy[sm.teki[i]].executeHurtMove = true;

            yield return new WaitUntil(() => moveOfAlly[sm.nakama[i]].attackStart == true);
            moveOfAlly[sm.nakama[i]].AttackAnimationStart();

            yield return new WaitUntil(() => moveOfAlly[sm.nakama[i]].attackEnd == true);
            moveOfEnemy[sm.teki[i]].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            aspCSP.refreshedChracter = sm.nakama[i];
            aspCSP.refreshAllyTP = true;

            espCSP.refreshedChracter = sm.teki[i];
            espCSP.refreshEnemyHP = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.teki[i]].hurtEnd == true);
            moveOfAlly[sm.nakama[i]].executeAfterAttackMove = true;
            moveOfEnemy[sm.teki[i]].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.teki[i]].end == true);

            yield return null;
            moveOfAlly[sm.nakama[i]].end = false;
            moveOfEnemy[sm.teki[i]].end = false;
            moveOfAlly[sm.nakama[i]].self = null;
            moveOfEnemy[sm.teki[i]].target = null;
        }

        nextPhase = new FirstCheckPhase();
    }
}