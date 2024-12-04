using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAllyPhase : BattlePhaseBase
{
    private string dialogue = "誰の行動を指示しようか";
    public GameObject target;

    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");

        battleContext.textWindow.CreateDialogueText(dialogue);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseAllyWindowMenu.currentID;
        battleContext.chooseAllyWindowMenu.Close();
        battleContext.chooseAllyWindowMenu.DeleteSelectableTexts();

        GameObject gobj = GameObject.Find("SystemManager");
        SystemManager sm = gobj.GetComponent<SystemManager>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.nakama.Add(index);
            string itsName = sm.allies[index].name;
            sm.nakamaObject.Add(GameObject.Find(itsName));

            nextPhase = new ChooseCommandPhase();
            battleContext.textWindow.isChooseComandPhase = true;
            battleContext.chooseCommandWindowMenu.CreateSelectableTexts(sm.allies[index].GetStringsOfSkills());
            battleContext.chooseCommandWindowMenu.Open();
        }
        else
        {
            if (sm.currentLoops == 0)
            {
                nextPhase = new ChooseRunOrBattlePhase();
                battleContext.chooseRunOrBattleWindowMenu.Open();
            }
            else
            {
                sm.currentLoops--;
                sm.teki.RemoveAt(sm.currentLoops);
                sm.tekiObject.RemoveAt(sm.currentLoops);
                nextPhase = new ChooseEnemyPhase();
                battleContext.chooseEnemyWindowMenu.CreateSelectableTexts(sm.GetStringsOfEnemies());
                battleContext.chooseEnemyWindowMenu.Open();
            }
        }
    }
}
