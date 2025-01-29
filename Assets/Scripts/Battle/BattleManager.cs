using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleContext battleContext;
    [SerializeField] public List<Move> moveOfAlly;
    [SerializeField] public List<Move> moveOfEnemy;
    public BattlePhaseBase phaseState;


    private void Start()
    {
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase)) //EndPhaseになるまで繰り返し
        {
             yield return phaseState.Execute(battleContext,moveOfAlly,moveOfEnemy); //フェーズの実行
             phaseState = phaseState.nextPhase; //次のフェーズに移行
        }

        yield return phaseState.Execute(battleContext,moveOfAlly,moveOfEnemy); //EndPhaseの実行

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
    public TextWindow textWindow;

    public BattleContext(WindowMenu chooseRunOrBattleWindowMenu,
                            WindowMenu runCheckWindowMenu,
                            WindowMenu chooseAllyWindowMenu,
                            WindowMenu chooseCommandWindowMenu,
                            WindowMenu chooseEnemyWindowMenu,
                            TextWindow textWindow)
    {
        this.chooseRunOrBattleWindowMenu = chooseRunOrBattleWindowMenu;
        this.runCheckWindowMenu = runCheckWindowMenu;
        this.chooseAllyWindowMenu = chooseAllyWindowMenu;
        this.chooseCommandWindowMenu = chooseCommandWindowMenu;
        this.chooseEnemyWindowMenu = chooseEnemyWindowMenu;
        this.textWindow = textWindow;
    }
}