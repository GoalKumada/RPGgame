using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyPhase : PhaseBase
{
    public static GameObject target;
    public static int attacked;
    private string dialogue = "対象は誰にする？";

    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseEnemyPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseEnemyWindowMenu.currentID;
        battleContext.chooseEnemyWindowMenu.Close();

        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                Debug.Log(index);
                Debug.Log("1番目の選択肢の処理にはいっている");
                attacked = 3;
                Enemy attackedEnemy = sm.enemies[0];
                string itsname = sm.enemies[0].name;
                target = GameObject.Find(itsname);
            }
            else if (index == 1)
            {
                Debug.Log(index);
                Debug.Log("２番目の選択肢の処理にはいっている");
                attacked = 4;
                Enemy attackedEnemy = sm.enemies[1];
                string itsname = sm.enemies[1].name;
                target = GameObject.Find(itsname);
            }
            else if (index == 2)
            {
                Debug.Log(index);
                Debug.Log("3番目の選択肢の処理にはいっている");
                attacked = 5;
                Enemy attackedEnemy = sm.enemies[2];
                string itsname = sm.enemies[2].name;
                target = GameObject.Find(itsname);
            }

            nextPhase = new ExecutePhase();
            SystemManager.start = true;

        }
        else
        {
            nextPhase = new ChooseCommandPhase();
            battleContext.chooseCommandWindowMenu.Open();
        }
    }
}
