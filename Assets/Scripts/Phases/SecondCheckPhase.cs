using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCheckPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        GameObject obj = GameObject.Find("BattleManager");
        BattleManager bm = obj.GetComponent<BattleManager>();

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        int count = 0;
        for (int i = sm.numOfAllies - 1; i >= 0; i--)
        {
            if (sm.allies[i].HP <= 0)
            {
                bm.moveOfAlly.RemoveAt(i);
                sm.allies.RemoveAt(i);

                Animator animator = sm.selfObject[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);

                count++;
            }
        }
        sm.numOfEnemies -= count;

        //Debug.Log(sm.numOfAllies);

        if (sm.numOfAllies > 0)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            
            // 敵の行動に関する情報をクリア
            sm.self.Clear();
            sm.selfObject.Clear();
            sm.skillNumber.Clear();
            sm.opponent.Clear();
            sm.opponentObject.Clear();
        }
        else
        {
            Debug.Log("味方が全滅した");
            nextPhase = new EndPhase();
        }
    }
}
