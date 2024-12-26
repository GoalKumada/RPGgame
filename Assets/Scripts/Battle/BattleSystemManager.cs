using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystemManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> allyObjects = new List<GameObject>();
    [SerializeField] private GameObject allyObjectPrefab = default;

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

    private float distance = 0.5f; // 立ち位置調整用


    private void Awake()
    {
        numOfAllies = allies.Count;
        numOfEnemies = enemies.Count;
        InstantiateAllyObject();
    }

    private void Start()
    {

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

    /*
    public void Temp()
    {
        // 消すの忘れるな
        Ally a = new Ally();
        a.maxHP = 500;
        a.currentHP = 250;
        a.maxTP = 20;
        a.currentTP = 10;
        SystemManager.allyComponentsOfCurrentPartyMember.Add(a);
        SystemManager.allyComponentsOfCurrentPartyMember.Add(a);
        SystemManager.allyComponentsOfCurrentPartyMember.Add(a);
    }
    */

    // なかまの数だけオブジェクトをインスタンス化
    public void InstantiateAllyObject()
    {
        GameObject gameObject = GameObject.Find("BattleManager");
        BattleManager battleManager = gameObject.GetComponent<BattleManager>();

        for (int i = 0; i < SystemManager.allyComponentsOfCurrentPartyMember.Count; i++)
        {
            GameObject allyObject = Instantiate(allyObjectPrefab);
            
            // ｚ座標をを0.5ずつずらす
            Vector3 vector3 = allyObject.transform.position;
            vector3.z -= distance * i;
            allyObject.transform.position = vector3;

            //BattleManagerのMoveOfAlliesになかまのMoveくらすを追加
            battleManager.moveOfAlly.Add(allyObject.GetComponent<Move>());

            Ally ally = allyObject.GetComponent<Ally>();
            SetAllyContext(ally,i);
        }
    }

    // なかまのステイタスなどの情報をオブジェクトに渡して、
    // battlesystemmanagerのリストに追加
    public void SetAllyContext(Ally ally, int i)
    {
        ally.characterName = SystemManager.allyComponentsOfCurrentPartyMember[i].characterName;
        ally.maxHP = SystemManager.allyComponentsOfCurrentPartyMember[i].maxHP;
        ally.currentHP = SystemManager.allyComponentsOfCurrentPartyMember[i].currentHP;
        ally.maxTP = SystemManager.allyComponentsOfCurrentPartyMember[i].maxTP;
        ally.currentTP = SystemManager.allyComponentsOfCurrentPartyMember[i].currentTP;
        ally.ATK = SystemManager.allyComponentsOfCurrentPartyMember[i].ATK;
        ally.currentATK = SystemManager.allyComponentsOfCurrentPartyMember[i].currentATK;
        ally.DEF = SystemManager.allyComponentsOfCurrentPartyMember[i].DEF;
        ally.currentDEF = SystemManager.allyComponentsOfCurrentPartyMember[i].currentDEF;
        ally.SPEED = SystemManager.allyComponentsOfCurrentPartyMember[i].SPEED;
        ally.currentSPEED = SystemManager.allyComponentsOfCurrentPartyMember[i].currentSPEED;

        allies.Add(ally);
    }
}