using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SystemManager : MonoBehaviour
{
    [SerializeField] public List<Ally> allies;
    [SerializeField] public List<Enemy> enemies;

    public static bool start;
    public static bool canContinueFighting;

    private void Update()
    {
        if (start)
        {
            switch (ChooseAllyPhase.attacker)
            {
                case 0:
                    allies[0].UseSkill(enemies[ChooseEnemyPhase.attacked], ChooseCommandPhase.skillNumber);
                    break;
                case 1:
                    allies[1].UseSkill(enemies[ChooseEnemyPhase.attacked], ChooseCommandPhase.skillNumber);
                    break;
                case 2:
                    allies[2].UseSkill(enemies[ChooseEnemyPhase.attacked], ChooseCommandPhase.skillNumber);
                    break;
            }

            if (enemies.Count > 0)
            {
                canContinueFighting = true;
            }
            else
            {
                canContinueFighting = false;
            }

            //Debug.Log("");

            start = false;
        }
    }

    public string[] GetStringsOfAllies()
    {
        List<string> list = new List<string>();
        foreach (Character ally in allies)
        {
            list.Add(ally.characterName);
        }

        return list.ToArray();
    }

    public string[] GetStringsOfEnemies()
    {
        List<string> list = new List<string>();
        foreach (Character enemy in enemies)
        {
            list.Add(enemy.characterName);
        }

        return list.ToArray();
    }
}
