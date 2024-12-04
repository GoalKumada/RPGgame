using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCheckPhase : BattlePhaseBase
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
            if (sm.allies[i].currentHP <= 0)
            {
                Animator animator = sm.allies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);
                bm.moveOfAlly.RemoveAt(i);
                sm.allies.RemoveAt(i);
                count++;
            }
        }
        sm.numOfAllies -= count;

        //Debug.Log(sm.numOfAllies);

        if (sm.numOfAllies > 0)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            
            // 敵の行動に関する情報をクリア
            sm.nakama.Clear();
            sm.nakamaObject.Clear();
            sm.skillNumber.Clear();
            sm.teki.Clear();
            sm.tekiObject.Clear();
        }
        else
        {
            Debug.Log("味方が全滅した");
            nextPhase = new EndPhase();
        }
    }
}
