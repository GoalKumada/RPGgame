using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        Debug.Log("EndPhase");
    }
}
