using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BattleSystemManager : MonoBehaviour
{
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

    // ToDo:戦闘開始時alliesとenemiesにパーティーのListを反映させるコードを追加したい

    private void Awake()
    {
        numOfAllies = allies.Count;
        numOfEnemies = enemies.Count;
    }

    private void Update()
    {

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
