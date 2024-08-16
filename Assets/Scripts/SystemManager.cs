using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] Ally[] allies;
    [SerializeField] Enemy[] enemies;

    public static bool start;

    private void Update()
    {
        if (start)
        {
            switch (ChooseAllyPhase.attacker)
            {
                case 0:
                    allies[0].Attack(enemies[ChooseEnemyPhase.attacked-3]);
                    break;
                case 1:
                    allies[1].UseSkill(enemies[ChooseEnemyPhase.attacked-3],1);
                    break;
                case 2:
                    allies[2].UseSkill(enemies[ChooseEnemyPhase.attacked-3],2);
                    break;
            }

            //Debug.Log("");
            
            start = false;
        }


    }

}
