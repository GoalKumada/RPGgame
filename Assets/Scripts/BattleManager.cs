using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    // フェーズの管理

    [SerializeField] WindowMenu chooseRunOrBattleWindowMenu = default;
    [SerializeField] WindowMenu runCheckWindowMenu = default;
    [SerializeField] WindowMenu chooseAllyWindowMenu = default;
    [SerializeField] WindowMenu chooseCommandWindowMenu = default;
    [SerializeField] WindowMenu chooseEnemyWindowMenu = default;
    
    enum Phase
    {
        StartPhase,
        ChooseRunOrBattlePhase, //「たたかう」か「にげる」か選ぶ
        RunCheckPhase, // 本当ににげるかどうかの確認
        ChooseAllyPhase, // 行動する味方を選ぶ
        ChooseCommandPhase, //コマンドを選ぶ
        ChooseEnemyPhase, // コマンドを実行する相手を選ぶ
        ExecutePhase,
        Result,
        End,
    }

    Phase phase;

    private void Start()
    {
        phase = Phase.StartPhase;
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            Debug.Log(phase);
            switch (phase)
            {
                case Phase.StartPhase:
                                        
                    //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    
                    phase = Phase.ChooseRunOrBattlePhase;
                    // ウィンドウをアクティブにする
                    UI.WindowActivated();


                    break;
                
                case Phase.ChooseRunOrBattlePhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    
                    int currentID_cROB = chooseRunOrBattleWindowMenu.currentID;


                    
                    if (currentID_cROB == 0) // 0(たたかう)ならChooseAllyPhaseへ
                    {
                        phase = Phase.ChooseAllyPhase;

                    }
                    else // 1（にげる）ならRunCheckへ
                    {
                        phase = Phase.RunCheckPhase;

                    }
                    break;
                
                case Phase.RunCheckPhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                    int currentID_rC = runCheckWindowMenu.currentID;

                    if (currentID_rC == 0)
                    {
                        phase = Phase.ChooseRunOrBattlePhase;

                    }
                    else
                    {
                        phase = Phase.StartPhase;

                    }
                    break;
                
                case Phase.ChooseAllyPhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    
                    int currentID_cA = chooseAllyWindowMenu.currentID;

                    if (currentID_cA == 0)
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    else if (currentID_cA == 1)
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    else
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    break;
                
                case Phase.ChooseCommandPhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                    int currentID_cC = chooseCommandWindowMenu.currentID;

                    if (currentID_cC == 0)
                    {
                        phase = Phase.ChooseEnemyPhase;
                    }
                    else if (currentID_cC == 1)
                    {
                        phase = Phase.ChooseEnemyPhase;
                    }
                    else
                    {
                        phase = Phase.ChooseEnemyPhase;
                    }
                    break;
                
                case Phase.ChooseEnemyPhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                    int currentID_cE = chooseEnemyWindowMenu.currentID;

                    if (currentID_cE == 0)
                    {
                        phase = Phase.ExecutePhase;
                    }
                    else if (currentID_cE == 1)
                    {
                        phase = Phase.ExecutePhase;
                    }
                    else
                    {
                        phase = Phase.ExecutePhase;
                    }
                    break;
                
                case Phase.ExecutePhase:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                    phase = Phase.Result;
                    break;
                
                case Phase.Result:
                    
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                    phase = Phase.End;
                    break;
                
                case Phase.End:

                    phase = Phase.StartPhase;
                    
                    break;

            }
        }
    }
}