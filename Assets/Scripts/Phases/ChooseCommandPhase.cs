using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public static int skillNumber;

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
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
            battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
            battleContext.chooseEnemyWindowMenu.Open();
        }
        else
        {
            nextPhase = new ChooseAllyPhase();
            battleContext.chooseAllyWindowMenu.CreateSelectableTexts(sm.GetStringsOfAllies());
            battleContext.chooseAllyWindowMenu.Open();
        }
    }
}
