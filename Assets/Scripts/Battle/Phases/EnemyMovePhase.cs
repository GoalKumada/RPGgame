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

        GameObject gobj = GameObject.Find("BattleSystemManager");
        BattleSystemManager sm = gobj.GetComponent<BattleSystemManager>();

        // 敵の行動を決めてListに格納
        // （動く敵を選ぶ→技を選ぶ→攻撃する味方を選ぶ）×（敵の数）
        //   opponent[i]→skillnumber[i]→self[i]

        System.Random random = new System.Random();
        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            // 敵の行動順はListの０→１→２で
            sm.teki.Add(i);
            string enemyName = sm.enemies[i].name;
            sm.tekiObject.Add(GameObject.Find(enemyName));

            //Debug.Log($"{i+1}番目に行動する敵：{i}");

            // 技選択は乱数を用いてランダムに
            int maxNumOfSkill = sm.enemies[i].skills.Count();
            sm.skillNumber.Add(random.Next(0, maxNumOfSkill));

            //Debug.Log($"{i+1}番目に行動する敵の技：{sm.skillNumber[i]}");

            // 攻撃する味方の選択もランダムに
            sm.nakama.Add(random.Next(0,sm.numOfAllies));
            string allyname = sm.allies[sm.nakama[i]].name;
            sm.nakamaObject.Add(GameObject.Find(allyname));

            //Debug.Log($"攻撃する味方：{sm.nakama[i]}");
        } 


        GameObject allyStatusPanel = GameObject.Find("AllyStatusPanel");
        CharacterStatusPanel aspCSP = allyStatusPanel.GetComponent<CharacterStatusPanel>();

        GameObject enemyStatusPanel = GameObject.Find("EnemyStatusPanel");
        CharacterStatusPanel espCSP = enemyStatusPanel.GetComponent<CharacterStatusPanel>();

        // 敵の動きのアニメーションを制御するコード
        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            // 敵の攻撃によるダメージの計算をする
            sm.enemies[sm.teki[i]].UseSkill(sm.allies[sm.nakama[i]], sm.skillNumber[i]);


            moveOfEnemy[sm.teki[i]].SetSelfInfo(sm.tekiObject[i]);
            moveOfAlly [sm.nakama[i]].SetTargetInfo(sm.nakamaObject[i]);

            moveOfEnemy[sm.teki[i]].executeAttackMove = true;
            moveOfAlly[sm.nakama[i]].executeHurtMove = true;

            yield return new WaitUntil(() => moveOfEnemy[sm.teki[i]].attackStart == true);
            moveOfEnemy[sm.teki[i]].AttackAnimationStart();

            yield return new WaitUntil(() => moveOfEnemy[sm.teki[i]].attackEnd == true);
            moveOfAlly[sm.nakama[i]].HurtAnimationStart();

            // ステイタス表示系のUIを更新する
            espCSP.refreshedCharacter = sm.teki[i];
            espCSP.isEnemyTpRefleshed = true;

            aspCSP.refreshedCharacter = sm.nakama[i];
            aspCSP.isAllyHPRefleshed = true;

            yield return new WaitUntil(() => moveOfAlly[sm.nakama[i]].hurtEnd == true);
            moveOfEnemy[sm.teki[i]].executeAfterAttackMove = true;
            moveOfAlly[sm.nakama[i]].executeAfterHurtMove = true;

            yield return new WaitUntil(() => moveOfAlly[sm.nakama[i]].end == true);

            yield return null;
            moveOfEnemy[sm.teki[i]].end = false;
            moveOfAlly[sm.nakama[i]].end = false;
            moveOfEnemy[sm.teki[i]].self = null;
            moveOfAlly[sm.nakama[i]].target = null;
        }

        nextPhase = new SecondCheckPhase();
    }
}
