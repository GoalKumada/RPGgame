using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCheckPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        BattleManager bm = GetBattleManager();
        BattleSystemManager sm = GetBattleSystemManager();

        //味方が死んでいるかどうか順にチェック
        sm.numOfDeadAllies = 0;
        for (int i = 0; i < sm.allies.Count; i++)
        {
            if (sm.allies[i].currentHP <= 0)
            {
                Animator animator = sm.allies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);
                sm.allies[i].isDead = true;
                sm.numOfDeadAllies++;
            }
        }

        if (sm.numOfDeadAllies < sm.allies.Count)
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            
            // 敵の行動に関する情報をクリア
            sm.numbersOfAllyInAction.Clear();
            sm.allyObjectsInAction.Clear();
            sm.skillNumbers.Clear();
            sm.numbersOfEnemyInAction.Clear();
            sm.enemyObjectsInAction.Clear();
        }
        else
        {
            string dialogue = "味方が全滅し、戦いに敗れた";
            battleContext.textWindow.CreateDialogueText(dialogue);
            sm.isDefeated = true;
            nextPhase = new EndPhase();
        }
    }
}
