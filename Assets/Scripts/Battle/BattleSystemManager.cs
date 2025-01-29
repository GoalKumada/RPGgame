using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSystemManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> allyObjects = new List<GameObject>();
    [SerializeField] public List<GameObject> enemyObjects = new List<GameObject>();
    [SerializeField] private GameObject allyObjectPrefab = default;

    [SerializeField] public List<Ally> allies;
    [SerializeField] public List<Enemy> enemies;

    public List<int> numbersOfAllyInAction = new List<int>();
    public List<int> numbersOfEnemyInAction = new List<int>();
    public List<int> skillNumbers = new List<int>();
    public List<GameObject> allyObjectsInAction = new List<GameObject>();
    public List<GameObject> enemyObjectsInAction = new List<GameObject>();

    public int numOfDeadAllies;
    public int numOfDeadEnemies;
    public int currentLoops = 0;

    public bool isCleared;
    public bool isEscaped;
    public bool isDefeated;

    private float distance = 0.5f; // 立ち位置調整用


    private void Awake()
    {
        InstantiateAllyObjects();
    }

    private void Start()
    {
        CheckAllyIsDead();
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

    
    public void InstantiateAllyObjects()
    {
        GameObject gameObject = GameObject.Find("BattleManager");
        BattleManager battleManager = gameObject.GetComponent<BattleManager>();

        for (int i = 0; i < SystemManager.allyComponents.Count; i++)
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

            SetAllySkills(allyObject, i);

            allyObjects.Add(allyObject);
        }
    }

    // なかまのステイタスなどの情報をオブジェクトに渡して、
    // BattleSystemManagerのリストに追加
    public void SetAllyStatus(Ally ally, int i)
    {
        ally.characterName =    SystemManager.allyComponents[i].characterName;
        ally.maxHP =            SystemManager.allyComponents[i].maxHP;
        ally.currentHP =        SystemManager.allyComponents[i].currentHP;
        ally.maxTP =            SystemManager.allyComponents[i].maxTP;
        ally.currentTP =        SystemManager.allyComponents[i].currentTP;
        ally.ATK =              SystemManager.allyComponents[i].ATK;
        ally.currentATK =       SystemManager.allyComponents[i].currentATK;
        ally.DEF =              SystemManager.allyComponents[i].DEF;
        ally.currentDEF =       SystemManager.allyComponents[i].currentDEF;
        ally.SPEED =            SystemManager.allyComponents[i].SPEED;
        ally.currentSPEED =     SystemManager.allyComponents[i].currentSPEED;
        ally.skills = new Skill[SystemManager.allyComponents[i].skills.Length];
        ally.isDead =           SystemManager.allyComponents[i].isDead;
        allies.Add(ally);
    }

    // なかまのスプライト、色、AnimatorControllerを設定する
    public void SetAllyContext(SpriteRenderer spriteRenderer,Animator animator, int i)
    {
        spriteRenderer.sprite = SystemManager.sprites[i];
        spriteRenderer.color = SystemManager.colorsOfSpriteProperty[i];
        animator.runtimeAnimatorController = SystemManager.runtimeAnimatorControllers[i];
    }

    public void SetAllySkills(GameObject allyObject, int i)
    {
        int countSkillnumber = 0;
        foreach (Skill skill in SystemManager.skills[i])
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

    public void CheckAllyIsDead()
    {
        for (int i = 0; i < allies.Count; i++)
        {
            if (allies[i].isDead)
            {
                Animator animator = allies[i].GetComponent<Animator>();
                animator.SetBool("Death_Idle", true);

                numOfDeadAllies++;
            }
        }
    }
}