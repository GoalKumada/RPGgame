using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleContext battleContext;
    PhaseBase phaseState;

    private void Start()
    {
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            yield return phaseState.Execute(battleContext); //フェーズの実行
            phaseState = phaseState.nextPhase; //次のフェーズに移行
        }

        yield return phaseState.Execute(battleContext); //EndPhaseの実行

        yield break;
    }
}

[System.Serializable]
public struct BattleContext // クラスに必要な情報を渡すための構造体
{
    public WindowMenu chooseRunOrBattleWindowMenu;
    public WindowMenu runCheckWindowMenu;
    public WindowMenu chooseAllyWindowMenu;
    public WindowMenu chooseCommandWindowMenu;
    public WindowMenu chooseEnemyWindowMenu;

    public BattleContext(WindowMenu chooseRunOrBattleWindowMenu,
                            WindowMenu runCheckWindowMenu,
                            WindowMenu chooseAllyWindowMenu,
                            WindowMenu chooseCommandWindowMenu,
                            WindowMenu chooseEnemyWindowMenu)
    {
        this.chooseRunOrBattleWindowMenu = chooseRunOrBattleWindowMenu;
        this.runCheckWindowMenu = runCheckWindowMenu;
        this.chooseAllyWindowMenu = chooseAllyWindowMenu;
        this.chooseCommandWindowMenu = chooseCommandWindowMenu;
        this.chooseEnemyWindowMenu = chooseEnemyWindowMenu;
    }
}