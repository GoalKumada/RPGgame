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

        if (sm.enemies[ChooseEnemyPhase.attacked].HP <= 0)
        {
            bm.moveOfEnemy.RemoveAt(ChooseEnemyPhase.attacked);
            sm.enemies.RemoveAt(ChooseEnemyPhase.attacked);
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
