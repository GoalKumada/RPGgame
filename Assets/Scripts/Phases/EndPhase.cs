using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, Move[] move)
    {
        yield return null;

        Debug.Log("EndPhase");
    }
}
