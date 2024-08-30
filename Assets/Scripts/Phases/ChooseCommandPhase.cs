using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public static int skillNumber;

    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseCommandPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseCommandWindowMenu.currentID;
        battleContext.chooseCommandWindowMenu.Close();
        
        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                skillNumber = 0;
            }
            else if (index == 1)
            {
                skillNumber = 1;
            }
            else if (index == 2)
            {
                skillNumber = 2;
            }
            nextPhase = new ChooseEnemyPhase();
            battleContext.chooseEnemyWindowMenu.CreateSelectableText(sm.GetStringsOfEnemies());
            battleContext.chooseEnemyWindowMenu.Open();
        }
        else
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.Open();
        }
    }
}
