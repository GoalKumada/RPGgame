using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheckPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        BattleManager bm = GetBattleManager();
        BattleSystemManager sm = GetBattleSystemManager();

        //敵が死んでいるかListを順にどうかチェック
        sm.numOfDeadEnemies = 0;
        for (int i = 0; i <sm.enemies.Count; i++)
        {
            if (sm.enemies[i].currentHP <= 0)
            {
                Animator animator = sm.enemies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);
                sm.enemies[i].isDead = true;
                sm.numOfDeadEnemies++;
            }
        }

        if (sm.numOfDeadEnemies < sm.enemies.Count)
        {
            // 味方の行動に関する情報をクリア
            sm.numbersOfAllyInAction.Clear();
            sm.allyObjectsInAction.Clear();
            sm.skillNumbers.Clear();
            sm.numbersOfEnemyInAction.Clear();
            sm.enemyObjectsInAction.Clear();
            sm.currentLoops = 0;
            
            nextPhase = new EnemyMovePhase();
        }
        else
        {
            string dialogue = "敵を全員倒し、戦いに勝利した！";
            battleContext.textWindow.CreateDialogueText(dialogue);
            sm.isCleared = true;
            nextPhase = new EndPhase();
        }
    }
}
