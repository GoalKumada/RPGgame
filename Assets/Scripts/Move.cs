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
    [SerializeField] private bool attackStart = false;
    [SerializeField] private bool attackEnd = false;
    [SerializeField] private bool hurtStart = false;
    [SerializeField] private bool hurtEnd = false;
    private Animator myAnimator;
    private Animator targetAnimator;
    private GameObject self;
    private GameObject target;

    public static bool setMoveInfoFlag = false;
    public static bool moveControlFlag = false;
    public static bool end = false;

    /*
    private void Start()
    {
        self = GameObject.Find("Warrior");
        target = GameObject.Find("Enemy");

        myAnimator = self.GetComponent<Animator>();
        targetAnimator = target.GetComponent<Animator>();

        myOriginalPos = self.transform.position;
        targetOriginalPos = target.transform.position;

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
    
    private void Update()
    {
        if (!end)
        {
            moveControl(self,target);
        }

        //Debug.Log("attackStart:" + attackStart);
        //Debug.Log("attackEnd:" + attackEnd);
        //Debug.Log("hurtStart:" + hurtStart);
        //Debug.Log("hurtEnd:" + hurtEnd);
    }
    */

    private void Update()
    {
        if (setMoveInfoFlag)
        {
            SetMoveInfo(ExecutePhase.self, ExecutePhase.target);
            //Debug.Log("self=" + self);
            //Debug.Log("target=" + target);
            setMoveInfoFlag = false;
        }
        
        // SetMoveInfoが一回ではselfとtargetを保持してくれない？

        if (moveControlFlag)
        {
            //Debug.Log("self=" + self);
            //Debug.Log("target=" + target);
            moveControl(ExecutePhase.self, ExecutePhase.target);
        }
    }

    //アニメーション前に移動するための関数
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

    }

    //アニメーション後に移動するための関数
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

        if (Vector3.Distance(myPosition, myOriginalPos) < 0.001f)
        {
            end = true;
        }

    }

    public void OnAttackEnd()
    {
        attackEnd = true;

        Debug.Log("attackEnd");
    }

    public void OnHurtEnd()
    {
        Debug.Log("hurtEnd");
        hurtEnd = true;
    }

    public void AttackControl(GameObject self)
    {
        Vector3 myPosition = self.transform.position;

        if (!attackStart)
        {
            if (myPosition != myDestinationPos && myPosition != targetDestinationPos)
            {
                BeforeActionMove(self);
                Debug.Log("Attack側のBeforeActionMove");
            }
            else
            {
                attackStart = true;
                myAnimator.SetTrigger("Attack");
                Debug.Log("attackStart");
            }
        }
        
        if (hurtEnd)
        {
            AfterActionMove(self);
            Debug.Log("Attack側のAfterActionMove");
        }
        
    }

    public void HurtControl(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;

        if (!attackEnd)
        {
            if (targetPosition != myDestinationPos && targetPosition != targetDestinationPos)
            {
                BeforeActionMove(target);
                Debug.Log("Hurt側のBeforeActionMove");
            }
        }
        else
        {
            if (!hurtStart)
            {
                targetAnimator.SetTrigger("Hurt");
                //attackEnd = true;
                hurtStart = true;
                Debug.Log("hurtStart");
            }
        }

        if (hurtEnd)
        {
            AfterActionMove(target);
            Debug.Log("Hurt側のAfterActionMove");
        }
    }

    public void moveControl(GameObject self, GameObject target)
    {
        AttackControl(self);
        HurtControl(target);
    }

    public void SetMoveInfo(GameObject self, GameObject target)
    {
        Debug.Log("呼ばれてるよ");
        this.self = self;
        this.target = target;

        myAnimator = this.self.GetComponent<Animator>();
        targetAnimator = this.target.GetComponent<Animator>();

        myOriginalPos = this.self.transform.position;
        targetOriginalPos = this.target.transform.position;

        if (this.self.tag == "Ally")
        {
            myDestinationPos = destinationPosOfArray;
        }
        else if (this.self.tag == "Enemy")
        {
            myDestinationPos = destinationPosOfEnemy;
        }

        if (this.target.tag == "Ally")
        {
            targetDestinationPos = destinationPosOfArray;
        }
        else if (this.target.tag == "Enemy")
        {
            targetDestinationPos = destinationPosOfEnemy;
        }

        selfSpeed_x = Math.Abs(myOriginalPos.x - myDestinationPos.x) / moveFrames;
        selfSpeed_z = Math.Abs(myOriginalPos.z - myDestinationPos.z) / moveFrames;
        targetSpeed_x = Math.Abs(targetOriginalPos.x - targetDestinationPos.x) / moveFrames;
        targetSpeed_z = Math.Abs(targetOriginalPos.z - targetDestinationPos.z) / moveFrames;

    }
}
