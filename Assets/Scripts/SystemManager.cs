using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SystemManager : MonoBehaviour
{
    // ToDo:戦闘開始時alliesとenemiesにパーティーのListを反映させるコードを追加したい
    [SerializeField] public List<Ally> allies;
    [SerializeField] public List<Enemy> enemies;

    public List<int> nakama = new List<int>();
    public List<int> teki = new List<int>();
    public List<int> skillNumber = new List<int>();
    public List<GameObject> nakamaObject = new List<GameObject>();
    public List<GameObject> tekiObject = new List<GameObject>();
    public int numOfAllies;
    public int numOfEnemies;
    public int currentLoops = 0;
    public static bool allyCalcuStart;
    public static bool enemyCalcuStart;

    private void Awake()
    {
        numOfAllies = allies.Count;
        numOfEnemies = enemies.Count;
    }

    private void Update()
    {
        // 味方の攻撃によるダメージの計算をする
        if (allyCalcuStart)
        {
            for (int i = 0; i < numOfAllies; i++) 
            {
                allies[nakama[i]].UseSkill(enemies[teki[i]], skillNumber[i]);
            }
            allyCalcuStart = false;
        }

        // 敵
        if (enemyCalcuStart)
        {
            for (int i = 0; i < numOfEnemies; i++)
            {
                enemies[teki[i]].UseSkill(allies[nakama[i]], skillNumber[i]);
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
