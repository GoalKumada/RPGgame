using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float speed_x;
    private float speed_z;
    private float moveFrames = 120;
    private Vector3 destinationPosOfArray = new Vector3(-0.5f,0.2f,-0.5f);
    private Vector3 destinationPosOfEnemy = new Vector3(0.5f,0.2f,-0.5f);
    private Vector3 destinationPos;
    private Vector3 originalPos;
    private bool attackStart = false;
    private bool attackEnd = false;
    private bool hurtStart = false;
    private bool hurtEnd = false;

    //private bool moveEnd = false;

    private void Start()
    {
        originalPos = this.transform.position;

        if (this.gameObject.tag == "Array")
        {
            destinationPos = destinationPosOfArray;
        }
        else if (this.gameObject.tag == "Enemy")
        {
            destinationPos = destinationPosOfEnemy;
        }

        speed_x = Math.Abs(originalPos.x - destinationPos.x) / moveFrames;
        speed_z = Math.Abs(originalPos.z - destinationPos.z) / moveFrames;

    }

    void Update()
    {

        //AttackControl();
        HurtControl();

        /*if (moveEnd)
        {
            return;
        }*/

    }

    //アニメーション前に移動するための関数
    public void BeforeActionMove()
    {
        Vector3 myPosition = this.transform.position;

        if (this.gameObject.tag == "Array")
        {
            if (myPosition.x != destinationPos.x)
            {
                myPosition.x += speed_x;
            }
            if (myPosition.z < destinationPos.z)
            {
                myPosition.z += speed_z;
            }
            else if (myPosition.z > destinationPos.z)
            {
                myPosition.z -= speed_z;
            }

            this.transform.position = myPosition;
        }

        if (this.gameObject.tag == "Enemy")
        {
            if (myPosition.x != destinationPos.x)
            {
                myPosition.x -= speed_x;
            }
            if (myPosition.z < destinationPos.z)
            {
                myPosition.z += speed_z;
            }
            else if (myPosition.z > destinationPos.z)
            {
                myPosition.z -= speed_z;
            }

            this.transform.position = myPosition;
        }

    }

    //アニメーション後に移動するための関数
    public void AfterActionMove()
    {
        Vector3 myPosition = this.transform.position;

        if (this.gameObject.tag == "Array")
        {
            if (myPosition.x != originalPos.x)
            {
                myPosition.x -= speed_x;
            }
            if (myPosition.z < originalPos.z)
            {
                myPosition.z += speed_z;
            }
            else if (myPosition.z > originalPos.z)
            {
                myPosition.z -= speed_z;
            }


            this.transform.position = myPosition;

        }

        if (this.gameObject.tag == "Enemy")
        {
            if (myPosition.x != originalPos.x)
            {
                myPosition.x += speed_x;
            }
            if (myPosition.z < originalPos.z)
            {
                myPosition.z += speed_z;
            }
            else if (myPosition.z > originalPos.z)
            {
                myPosition.z -= speed_z;
            }

            this.transform.position = myPosition;

        }

        /*if (myPosition == originalPos)
        {
            Debug.Log("kougeki syuuryou");
            moveEnd = true;
        }*/
    }

    public void OnAttackEnd()
    {
        attackEnd = true;
    }

    public void OnHurtEnd()
    {
        hurtEnd = true;
    }

    public void AttackControl()
    {
        Vector3 myPosition = this.transform.position;

        if (!attackEnd)
        {
            if (myPosition != destinationPos)
            {
                BeforeActionMove();
            }
            else
            {
                if (!attackStart)
                {
                    animator.SetTrigger("Attack");
                    attackStart = true;
                }
            }
        }

        if (attackEnd)
        {
            AfterActionMove();
        }

    }

    public void HurtControl()
    {
        Vector3 myPosition = this.transform.position;

        if (!hurtEnd)
        {
            if (myPosition != destinationPos)
            {
                BeforeActionMove();
            }
            else
            {
                if (!hurtStart)
                {
                    animator.SetTrigger("Hurt");
                    hurtStart = true;
                }
            }
        }

        if (hurtEnd)
        {
            AfterActionMove();
        }

    }

}
