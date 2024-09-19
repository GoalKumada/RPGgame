using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SystemManager : MonoBehaviour
{
    // 後にalliesとenemiesにパーティーのListを反映させるコードを追加したい
    [SerializeField] public List<Ally> allies;
    [SerializeField] public List<Enemy> enemies;

    public List<int> self = new List<int>();
    public List<int> opponent = new List<int>();
    public List<int> skillNumber = new List<int>();
    public List<GameObject> selfObject = new List<GameObject>();
    public List<GameObject> opponentObject = new List<GameObject>();
    public int numOfAllies;
    public int numOfEnemies;
    public int currentLoops = 0;
    public static bool allyCalcuStart;
    public static bool enemyCalcuStart;

    private void Start()
    {
        numOfAllies = allies.Count;
        numOfEnemies = enemies.Count;
    }

    private void Update()
    {
        if (allyCalcuStart)
        {
            for (int i = 0; i < numOfAllies; i++) 
            {
                allies[self[i]].UseSkill(enemies[opponent[i]], skillNumber[i]);
            }
            allyCalcuStart = false;
        }

        if (enemyCalcuStart)
        {
            for (int i = 0; i < numOfEnemies; i++)
            {
                enemies[opponent[i]].UseSkill(allies[self[i]], skillNumber[i]);
            }
            enemyCalcuStart = false;
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
