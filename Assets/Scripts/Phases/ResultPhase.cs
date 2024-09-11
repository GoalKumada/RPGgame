using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        
        Debug.Log("ResultPhase");

        BattleManager bm;
        GameObject obj = GameObject.Find("BattleManager");
        bm = obj.GetComponent<BattleManager>();
        
        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        for (int i = 0; i < sm.numOfEnemies; i++)
        {
            if (sm.enemies[i].HP <= 0)
            {
                bm.moveOfEnemy.RemoveAt(i);
                sm.enemies.RemoveAt(i);
                sm.numOfEnemies--;
            }
        }

        if (SystemManager.canContinueFighting)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();

        }
        else
        {
            nextPhase = new EndPhase();
        }
    }
}
