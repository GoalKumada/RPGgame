using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhaseBase
{
    public PhaseBase nextPhase;
    public abstract IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy);
}
