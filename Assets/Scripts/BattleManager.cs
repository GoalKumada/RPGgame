using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleManager : MonoBehaviour
{
    // フェーズの管理

    enum Phase
    {
        StartPhase,
        ChooseRunOrBattlePhase, //「たたかう」か「にげる」か選ぶ
        ChooseArrayPhase, // 行動する味方を選ぶ
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
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.ChooseRunOrBattlePhase;
                    break;
                case Phase.ChooseRunOrBattlePhase:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.ChooseArrayPhase;
                    break;
                case Phase.ChooseArrayPhase:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.ChooseCommandPhase;
                    break;
                case Phase.ChooseCommandPhase:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.ChooseEnemyPhase;
                    break;
                case Phase.ChooseEnemyPhase:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.ExecutePhase;
                    break;
                case Phase.ExecutePhase:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.Result;
                    break;
                case Phase.Result:
                    //
                    yield return new WaitUntil(() => Keyboard.current.spaceKey.wasReleasedThisFrame);
                    phase = Phase.End;
                    break;
                case Phase.End:
                    //
                    break;

            }
        }
    }
}