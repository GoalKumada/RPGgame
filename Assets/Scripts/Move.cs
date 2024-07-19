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
    private Vector3 destinationPosOfArray = new Vector3(-0.5f,0.2f,-0.5f);
    private Vector3 destinationPosOfEnemy = new Vector3(0.5f,0.2f,-0.5f);
    private Vector3 myOriginalPos;
    private Vector3 myDestinationPos;
    private Vector3 targetOriginalPos;
    private Vector3 targetDestinationPos;
    private bool attackStart = false;
    private bool attackEnd = false;
    private bool hurtStart = false;
    private bool hurtEnd = false;
    private bool end = false;
    private Animator myAnimator;
    private Animator targetAnimator;
    private GameObject self;
    private GameObject target;

    private void Start()
    {
        self = GameObject.Find("Warrior");
        target = GameObject.Find("Enemy");
        
        myAnimator = self.GetComponent<Animator>();
        targetAnimator = target.GetComponent<Animator>();
        
        myOriginalPos = self.transform.position;
        targetOriginalPos = target.transform.position;

        Debug.Log(myOriginalPos);
        Debug.Log(targetOriginalPos);

        if (self.tag == "Ally")
        {
            myDestinationPos = destinationPosOfArray;
        }
        else if (self.tag == "Enemy")
        {
            myDestinationPos = destinationPosOfEnemy;
        }

        if (target.tag == "Ally")
        {
            targetDestinationPos = destinationPosOfArray;
        }
        else if (target.tag == "Enemy")
        {
            targetDestinationPos = destinationPosOfEnemy;
        }

        selfSpeed_x = Math.Abs(myOriginalPos.x - myDestinationPos.x) / moveFrames;
        selfSpeed_z = Math.Abs(myOriginalPos.z - myDestinationPos.z) / moveFrames;
        targetSpeed_x = Math.Abs(targetOriginalPos.x - targetDestinationPos.x) / moveFrames;
        targetSpeed_z = Math.Abs(targetOriginalPos.z - targetDestinationPos.z) / moveFrames;

    }

    void Update()
    {
        if (!end)
        {
            moveControl(self,target);
        }
    }

    //アニメーション前に移動するための関数
    public void BeforeActionMove(GameObject gameObject)
    {
        Vector3 myPosition = gameObject.transform.position;

        if (gameObject.tag == "Ally")
        {
            if (myPosition.x != myDestinationPos.x)
            {
                myPosition.x += selfSpeed_x;
            }
            if (myPosition.z < myDestinationPos.z)
            {
                myPosition.z += selfSpeed_z;
            }
            else if (myPosition.z > myDestinationPos.z)
            {
                myPosition.z -= selfSpeed_z;
            }

            gameObject.transform.position = myPosition;
        }

        if (gameObject.tag == "Enemy")
        {
            if (myPosition.x != targetDestinationPos.x)
            {
                myPosition.x -= targetSpeed_x;
            }
            if (myPosition.z < targetDestinationPos.z)
            {
                myPosition.z += targetSpeed_z;
            }
            else if (myPosition.z > targetDestinationPos.z)
            {
                myPosition.z -= targetSpeed_z;
            }

            gameObject.transform.position = myPosition;
        }

    }

    //アニメーション後に移動するための関数
    public void AfterActionMove(GameObject gameObject)
    {
        Vector3 myPosition = gameObject.transform.position;
        Debug.Log("AfterActionMoveが呼ばれた");

        if (gameObject.tag == ("Ally"))
        {
            if (myPosition.x != myOriginalPos.x)
            {   
                myPosition.x -= selfSpeed_x;
            }
            if (myPosition.z < myOriginalPos.z)
            {
                myPosition.z += selfSpeed_z;
            }
            else if (myPosition.z > myOriginalPos.z)
            {
                myPosition.z -= selfSpeed_z;
            }

            gameObject.transform.position = myPosition;
        }

        if (gameObject.tag == "Enemy")
        {
            if (myPosition.x != targetOriginalPos.x)
            {
                myPosition.x += targetSpeed_x;
            }
            if (myPosition.z < targetOriginalPos.z)
            {
                myPosition.z += targetSpeed_z;
            }
            else if (myPosition.z > targetOriginalPos.z)
            {
                myPosition.z -= targetSpeed_z;
            }

            gameObject.transform.position = myPosition;
        }

        if (Vector3.Distance(myPosition, myOriginalPos) < 0.01f)
        {
            end = true;
        }

    }

    public void OnAttackEnd()
    {
        attackEnd = true;
    }

    public void OnHurtEnd()
    {
        hurtEnd = true;
    }

    public void AttackControl(GameObject self)
    {
        Vector3 myPosition = self.transform.position;

        if (!attackEnd)
        {
            if (myPosition != myDestinationPos && myPosition != targetDestinationPos)
            {
                BeforeActionMove(self);
            }
            else
            {
                if (!attackStart)
                {
                    myAnimator.SetTrigger("Attack");
                    attackStart = true;
                }
            }
        }
        
        if (hurtEnd)
        {
            AfterActionMove(self);
        }
        
    }

    public void HurtControl(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;

        if (!hurtEnd)
        {
            if (targetPosition != myDestinationPos && targetPosition != targetDestinationPos)
            {
                BeforeActionMove(target);
            }
            else
            {
                if (attackEnd)
                {
                    if (!hurtStart)
                    {
                        targetAnimator.SetTrigger("Hurt");
                        hurtStart = true;
                    }
                }
            }
        }
        
        if (hurtEnd)
        {
            AfterActionMove(target);
        }
        
    }

    public void moveControl(GameObject self, GameObject target)
    {
        AttackControl(self);
        HurtControl(target);
    }
}
