using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        
        Debug.Log("ResultPhase");

        GameObject obj = GameObject.Find("BattleManager");
        BattleManager bm = obj.GetComponent<BattleManager>();
        
        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        int count = 0;
        for (int i = sm.numOfEnemies-1; i >= 0; i--)
        {
            if (sm.enemies[i].HP <= 0)
            {
                bm.moveOfEnemy.RemoveAt(i);
                sm.enemies.RemoveAt(i);
                count++;
            }
        }
        sm.numOfEnemies -= count;

        Debug.Log(sm.numOfEnemies);

        if (sm.numOfEnemies > 0)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();

            sm.self.Clear();
            sm.selfObject.Clear();

            sm.opponent.Clear();
            sm.opponentObject.Clear();

            sm.currentLoops = 0;
        }
        else
        {
            Debug.Log("敵を全員倒した");
            nextPhase = new EndPhase();
        }
    }
}
