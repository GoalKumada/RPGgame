using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        InstantiateAllyObject();
        numOfAllies = allies.Count;
        numOfEnemies = enemies.Count;
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
            SetAllyStatus(ally,i);

            SpriteRenderer spriteRenderer = allyObject.GetComponent<SpriteRenderer>();
            Animator animator = allyObject.GetComponent<Animator>();
            SetAllyContext(spriteRenderer,animator,i);

            SetAllySkill(allyObject, i);
        }
    }

    // なかまのステイタスなどの情報をオブジェクトに渡して、
    // battlesystemmanagerのリストに追加
    public void SetAllyStatus(Ally ally, int i)
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
        ally.skills = new Skill[SystemManager.allyComponentsOfCurrentPartyMember[i].skills.Length];

        allies.Add(ally);
    }

    // なかまのスプライト、色、AnimatorControllerを設定する
    public void SetAllyContext(SpriteRenderer spriteRenderer,Animator animator, int i)
    {
        spriteRenderer.sprite = SystemManager.spritesOfCurrentPartyMember[i];
        spriteRenderer.color = SystemManager.colorOfCurrentPartyMember[i];
        animator.runtimeAnimatorController = SystemManager.controllersOfCurrentPartyMember[i];
    }

    // なかまのスキルを設定する
    public void SetAllySkill(GameObject allyObject, int i)
    {
        int countSkillnumber = 0;
        foreach (Skill skill in SystemManager.skillsOfCurrentPartyMember[i])
        {
            Skill addedSkill = allyObject.AddComponent<Skill>();

            addedSkill.skillName = skill.skillName;
            addedSkill.attackPower = skill.attackPower;
            addedSkill.type = skill.type;
            addedSkill.requiredTP = skill.requiredTP;
            addedSkill.skillExplain = skill.skillExplain;

            allyObject.GetComponent<Ally>().skills[countSkillnumber] = addedSkill;
            countSkillnumber++;
        }
    }
}