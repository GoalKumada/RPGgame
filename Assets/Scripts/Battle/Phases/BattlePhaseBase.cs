using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattlePhaseBase
{
    public BattlePhaseBase nextPhase;
    public abstract IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy);

    public BattleManager GetBattleManager()
    {
        GameObject gobj = GameObject.Find("BattleManager");
        BattleManager bm = gobj.GetComponent<BattleManager>();
        return bm;
    }

    public BattleSystemManager GetBattleSystemManager()
    {
        GameObject gobj = GameObject.Find("BattleSystemManager");
        BattleSystemManager sm = gobj.GetComponent<BattleSystemManager>();
        return sm;
    }

    public CharacterStatusPanel GetCharacterStatusPanel(string statusPanelName)
    {
        GameObject statusPanel = GameObject.Find(statusPanelName);
        CharacterStatusPanel characterStatusPanel = statusPanel.GetComponent<CharacterStatusPanel>();
        return characterStatusPanel;
    } 
}
