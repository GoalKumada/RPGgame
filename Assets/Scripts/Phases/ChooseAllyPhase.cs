using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class ChooseAllyPhase : PhaseBase
{
    public static GameObject self;
    public static int attacker;
    private string dialogue = "誰の行動を指示しようか";

    public override IEnumerator Execute(BattleContext battleContext, Move[] newMove)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");
        battleContext.textWindow.CreateDialogueText(dialogue);


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        int index = battleContext.chooseAllyWindowMenu.currentID;
        battleContext.chooseAllyWindowMenu.Close();

        SystemManager sm;
        GameObject gobj = GameObject.Find("SystemManager");
        sm = gobj.GetComponent<SystemManager>();

        Debug.Log(index);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(index);
            if (index == 0)
            {
                attacker = 0;
                Ally attackingAlly = sm.allies[0];
                string itsname = sm.allies[0].name;
                self = GameObject.Find(itsname);
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[0].GetStringsOfSkills());
            }
            else if (index == 1)
            {
                attacker = 1;
                Ally attackingAlly = sm.allies[1];
                string itsname = sm.allies[1].name;
                self = GameObject.Find(itsname);
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[1].GetStringsOfSkills());
            }
            else if (index == 2)
            {
                attacker = 2;
                Ally attackingAlly = sm.allies[2];
                string itsname = sm.allies[2].name;
                self = GameObject.Find(itsname);
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.CreateSelectableText(sm.allies[2].GetStringsOfSkills());
            }
            battleContext.chooseCommandWindowMenu.Open();
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
        }
    }
}
