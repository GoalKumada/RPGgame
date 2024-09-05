using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public static int skillNumber;

    public override IEnumerator Execute(BattleContext battleContext, Move[] newMove)
    {
        yield return null;
        Debug.Log("ChooseCommandPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseCommandWindowMenu.currentID;
        battleContext.chooseCommandWindowMenu.Close();
        battleContext.chooseCommandWindowMenu.DeleteSelectableTexts();
        
        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        Debug.Log(index);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(index);
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
            battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
            battleContext.chooseEnemyWindowMenu.Open();
        }
        else
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.Open();
        }
    }
}
