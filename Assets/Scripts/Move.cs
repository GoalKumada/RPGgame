using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float selfSpeed_x;
    private float selfSpeed_z;
    private float targetSpeed_x;
    private float targetSpeed_z;
    private float moveFrames = 120;
    private Vector3 destinationPosOfArray = new Vector3(-0.5f, 0.2f, -0.5f);
    private Vector3 destinationPosOfEnemy = new Vector3(0.5f, 0.2f, -0.5f);
    private Vector3 myOriginalPos;
    private Vector3 myDestinationPos;
    private Vector3 targetOriginalPos;
    private Vector3 targetDestinationPos;
    private Animator myAnimator;
    private Animator targetAnimator;
    private GameObject self;
    private GameObject target;

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

    public void SetAttackerInfo(GameObject attacker)
    {
        self = attacker;
        
        myAnimator = self.GetComponent<Animator>();
        
        myOriginalPos = self.transform.position;
        
        if (self.tag == "Ally")
        {
            myDestinationPos = destinationPosOfArray;
        }
        else if (self.tag == "Enemy")
        {
            myDestinationPos = destinationPosOfEnemy;
        }

        selfSpeed_x = Math.Abs(myOriginalPos.x - myDestinationPos.x) / moveFrames;
        selfSpeed_z = Math.Abs(myOriginalPos.z - myDestinationPos.z) / moveFrames;
        
    }

    public void SetTargetInfo(GameObject target)
    {
        this.target = target;

        targetAnimator = this.target.GetComponent<Animator>();

        targetOriginalPos = this.target.transform.position;

        if (this.target.tag == "Ally")
        {
            targetDestinationPos = destinationPosOfArray;
        }
        else if (this.target.tag == "Enemy")
        {
            targetDestinationPos = destinationPosOfEnemy;
        }

        targetSpeed_x = Math.Abs(targetOriginalPos.x - targetDestinationPos.x) / moveFrames;
        targetSpeed_z = Math.Abs(targetOriginalPos.z - targetDestinationPos.z) / moveFrames;

    }

    public void OnAttackEnd()
    {
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
        Vector3 myPosition = gameObject.transform.position;

        if (gameObject.tag == "Ally")
        {
            if (Mathf.Abs(myPosition.x - myDestinationPos.x) > 0.001f)
            {
                myPosition.x += selfSpeed_x;
            }
            else
            {
                myPosition.x = myDestinationPos.x;
            }

            if (Mathf.Abs(myPosition.z - myDestinationPos.z) > 0.001f)
            {
                if (myPosition.z < myDestinationPos.z)
                {
                    myPosition.z += selfSpeed_z;
                }
                else if (myPosition.z > myDestinationPos.z)
                {
                    myPosition.z -= selfSpeed_z;
                }
            }
            else
            {
                myPosition.z = myDestinationPos.z;
            }

            gameObject.transform.position = myPosition;

        }

        if (gameObject.tag == "Enemy")
        {
            if (Mathf.Abs(myPosition.x - targetDestinationPos.x) > 0.001f)
            {
                myPosition.x -= targetSpeed_x;
            }
            else
            {
                myPosition.x = targetDestinationPos.x;
            }

            if (Mathf.Abs(myPosition.z - targetDestinationPos.z) > 0.001f)
            {
                if (myPosition.z < targetDestinationPos.z)
                {
                    myPosition.z += targetSpeed_z;
                }
                else if (myPosition.z > targetDestinationPos.z)
                {
                    myPosition.z -= targetSpeed_z;
                }
            }
            else
            {
                myPosition.z = targetDestinationPos.z;
            }

            gameObject.transform.position = myPosition;
        }

        if (myPosition == myDestinationPos || myPosition == targetDestinationPos)
        {
            executeAttackMove = false;
            executeHurtMove = false;
            attackStart = true;
        }
    }

    public void AfterActionMove(GameObject gameObject)
    {
        Vector3 myPosition = gameObject.transform.position;

        if (gameObject.tag == ("Ally"))
        {
            if (Mathf.Abs(myPosition.x - myOriginalPos.x) > 0.001f)
            {
                myPosition.x -= selfSpeed_x;
            }
            else
            {
                myPosition.x = myOriginalPos.x;
            }

            if (Mathf.Abs(myPosition.z - myOriginalPos.z) > 0.001f)
            {
                if (myPosition.z < myOriginalPos.z)
                {
                    myPosition.z += selfSpeed_z;
                }
                else if (myPosition.z > myOriginalPos.z)
                {
                    myPosition.z -= selfSpeed_z;
                }
            }
            else
            {
                myPosition.z = myOriginalPos.z;
            }

            gameObject.transform.position = myPosition;
        }

        if (gameObject.tag == "Enemy")
        {
            if (Mathf.Abs(myPosition.x - targetOriginalPos.x) > 0.001f)
            {
                myPosition.x += targetSpeed_x;
            }
            else
            {
                myPosition.x = targetOriginalPos.x;
            }

            if (Mathf.Abs(myPosition.z - myOriginalPos.z) > 0.001f)
            {
                if (myPosition.z < targetOriginalPos.z)
                {
                    myPosition.z += targetSpeed_z;
                }
                else if (myPosition.z > targetOriginalPos.z)
                {
                    myPosition.z -= targetSpeed_z;
                }
            }
            else
            {
                myPosition.z = targetOriginalPos.z;
            }

            gameObject.transform.position = myPosition;
        }

        if (myPosition == myOriginalPos || myPosition == targetOriginalPos)
        {
            executeAfterAttackMove = false;
            executeAfterHurtMove = false;
            attackEnd = false;
            hurtEnd = false;
            end = true;
        }

    }

    public void AttackAnimationStart()
    {
        myAnimator.SetTrigger("Attack");
    }

    public void HurtAnimationStart()
    {
        targetAnimator.SetTrigger("Hurt");
        hurtEnd = false;
    }
}