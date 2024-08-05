using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, NewMove[] newMove)
    {
        yield return null;

        Debug.Log("EndPhase");
    }
}
