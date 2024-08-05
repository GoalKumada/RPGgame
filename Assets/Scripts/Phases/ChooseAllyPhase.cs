using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAllyPhase : PhaseBase
{
    public static GameObject self;
    public static int attacker;
    
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;
        Debug.Log("ChooseAllyPhase");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));

        battleContext.chooseAllyWindowMenu.Close();

        int currentID = battleContext.chooseAllyWindowMenu.currentID;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                attacker = 0;
                self = GameObject.Find("Warrior");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
            }
            else if (currentID == 1)
            {
                attacker = 1;
                self = GameObject.Find("Warrior (1)");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
            }
            else
            {
                attacker = 2;
                self = GameObject.Find("Warrior (2)");
                nextPhase = new ChooseCommandPhase();
                battleContext.chooseCommandWindowMenu.Open();
            }
        }
        else
        {
            nextPhase = new ChooseRunOrBattlePhase();
            battleContext.chooseRunOrBattleWindowMenu.Open();
            battleContext.chooseRunOrBattleWindowMenu.Select();
        }
    }
}
