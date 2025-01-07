using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed_x;
    private float speed_z;
    private float moveFrames = 120;
    private Vector3 goalPosOfAlly = new Vector3(-0.5f, 0.2f, -0.5f);
    private Vector3 goalPosOfEnemy = new Vector3(0.5f, 0.2f, -0.5f);
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Vector3 goalPos;
    private Animator animator;

    public GameObject self;
    public GameObject target;
    public bool executeAttackMove = false;
    public bool executeHurtMove = false;
    public bool attackStart = false;
    public bool attackEnd = false;
    public bool hurtEnd = false;
    public bool executeAfterAttackMove = false;
    public bool executeAfterHurtMove = false;
    public bool end = false;


    private void Start()
    {
        originalPos = this.transform.position;
        if (this.gameObject.tag == "Ally")
        {
            goalPos = goalPosOfAlly;
        }
        if (gameObject.tag == "Enemy")
        {
            goalPos = goalPosOfEnemy;
        }
    }

    private void Update()
    {
        if (executeAttackMove)
        {
            BeforeActionMove(self);
        }
        
        if (executeHurtMove)
        {
            BeforeActionMove(target);
        }

        if (executeAfterAttackMove)
        {
            AfterActionMove(self);
        }

        if (executeAfterHurtMove)
        {
            AfterActionMove(target);
        }
    }

    public void SetSelfInfo(GameObject _object)
    {
        self = _object;
        animator = _object.GetComponent<Animator>();
        speed_x = Math.Abs(originalPos.x - goalPos.x) / moveFrames;
        speed_z = Math.Abs(originalPos.z - goalPos.z) / moveFrames;
    }
    
    public void SetTargetInfo(GameObject _object)
    {
        target = _object;
        animator = _object.GetComponent<Animator>();
        speed_x = Math.Abs(originalPos.x - goalPos.x) / moveFrames;
        speed_z = Math.Abs(originalPos.z - goalPos.z) / moveFrames;
    }

    public void OnAttackEnd()
    {
        //Debug.Log(gameObject.GetComponent<Character>().characterName);
        attackEnd = true;
        attackStart = false;
    }

    public void OnHurtEnd()
    {
        attackStart = false;
        hurtEnd = true;
    }

    public void BeforeActionMove(GameObject gameObject)
    {
        // 現在位置を取得
        Vector3 currentPos = gameObject.transform.position;

        if (gameObject.tag == "Ally") // タグで敵か味方か判断
        {
            // X軸方向に移動
            if (Mathf.Abs(currentPos.x - goalPos.x) > 0.001f)
            {
                currentPos.x += speed_x;
            }
            else
            {
                currentPos.x = goalPos.x;
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            // X軸方向に移動
            if (Mathf.Abs(currentPos.x - goalPos.x) > 0.001f)
            {
                currentPos.x -= speed_x;
            }
            else
            {
                currentPos.x = goalPos.x;
            }
        }
        // Y軸方向に移動
        if (Mathf.Abs(currentPos.z - goalPos.z) > 0.001f)
        {
            if (currentPos.z < goalPos.z)
            {
                currentPos.z += speed_z;
            }
            else if (currentPos.z > goalPos.z)
            {
                currentPos.z -= speed_z;
            }
        }
        else
        {
            currentPos.z = goalPos.z;
        }
        
        // 現在位置を更新
        gameObject.transform.position = currentPos;        

        // 目的地に着いたらフラグを立てる
        if (currentPos == goalPos)
        {
            executeAttackMove = false;
            executeHurtMove = false;
            attackStart = true;
        }
    }

    public void AfterActionMove(GameObject gameObject)
    {
        // 現在位置を取得
        Vector3 currentPos = gameObject.transform.position;

        if (gameObject.tag == "Ally") // タグで敵か味方か判断
        {
            // X軸方向に移動
            if (Mathf.Abs(currentPos.x - originalPos.x) > 0.001f)
            {
                currentPos.x -= speed_x;
            }
            else
            {
                currentPos.x = originalPos.x;
            }
        }
        else if (gameObject.tag == "Enemy") // タグで敵か味方か判断
        {
            // X軸方向に移動
            if (Mathf.Abs(currentPos.x - originalPos.x) > 0.001f)
            {
                currentPos.x += speed_x;
            }
            else
            {
                currentPos.x = originalPos.x;
            }
        }

        // Y軸方向に移動
        if (Mathf.Abs(currentPos.z - originalPos.z) > 0.001f)
        {
            if (currentPos.z < originalPos.z)
            {
                currentPos.z += speed_z;
            }
            else if (currentPos.z > originalPos.z)
            {
                currentPos.z -= speed_z;
            }
        }
        else
        {
            currentPos.z = originalPos.z;
        }

        // 現在位置を更新
        gameObject.transform.position = currentPos;

        // 目的地に着いたらフラグを立てる
        if (currentPos == originalPos)
        {
            executeAfterAttackMove = false;
            executeAfterHurtMove = false;
            attackEnd = false;
            hurtEnd = false;
            end = true;
        }
    }

    public void AttackAnimationStart(int skillnumber)
    {
        //Debug.Log("AttackAnimationStart");
        animator.SetTrigger($"Attack{skillnumber}");
    }

    public void HurtAnimationStart()
    {
        animator.SetTrigger("Hurt");
        hurtEnd = false;
    }
}