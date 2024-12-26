using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheckPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("FirstCheckPhase");

        GameObject obj = GameObject.Find("BattleManager");
        BattleManager bm = obj.GetComponent<BattleManager>();
        
        GameObject gobj = GameObject.Find("BattleSystemManager");
        BattleSystemManager sm = gobj.GetComponent<BattleSystemManager>();

        int count = 0;
        for (int i = sm.numOfEnemies-1; i >= 0; i--)
        {
            if (sm.enemies[i].currentHP <= 0)
            {
                Animator animator = sm.enemies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);
                bm.moveOfEnemy.RemoveAt(i);
                sm.enemies.RemoveAt(i);
                count++;
            }
        }
        sm.numOfEnemies -= count;

        //Debug.Log(sm.numOfEnemies);

        if (sm.numOfEnemies > 0)
        {
            nextPhase = new EnemyMovePhase();
            
            // 味方の行動に関する情報をクリア
            sm.nakama.Clear();
            sm.nakamaObject.Clear();
            sm.skillNumber.Clear();
            sm.teki.Clear();
            sm.tekiObject.Clear();
            sm.currentLoops = 0;
        }
        else
        {
            Debug.Log("敵を全員倒した");
            nextPhase = new EndPhase();
        }
    }
}
