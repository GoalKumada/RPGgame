using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyPhase : PhaseBase
{
    public static GameObject target;
    public static int attacked;

    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseEnemyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        
        battleContext.chooseEnemyWindowMenu.Close();

        int currentID_cE = battleContext.chooseEnemyWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID_cE == 0)
            {
                attacked = 3;
                target = GameObject.Find("Enemy");
                nextPhase = new ExecutePhase();
            }
            else if (currentID_cE == 1)
            {
                attacked = 4;
                target = GameObject.Find("Enemy (1)"); 
                nextPhase = new ExecutePhase();
            }
            else
            {
                attacked = 5;
                target = GameObject.Find("Enemy (2)"); 
                nextPhase = new ExecutePhase();
            }
        }
        else
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.Open();
            battleContext.chooseCommandWindowMenu.Select();
        }
    }
}
