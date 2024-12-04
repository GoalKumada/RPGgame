using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TavernPhaseBase
{
    public abstract void Excute();
    public TavernPhaseBase nextPhase;

}
