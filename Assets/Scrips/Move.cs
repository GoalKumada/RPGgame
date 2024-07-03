using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float speed_x = 0.0025f;
    private float speed_z = 0.0015f;
    private bool attackEnded = false;
    private Vector3 destinationPos = new Vector3(-0.5f,0.2f,0);
    private Vector3 originalPos;
    
    void Start()
    {
        originalPos = this.transform.position;
    }

    void Update()
    {

        AttackControl(destinationPos,originalPos);

    }

    void beforeAttackMove(float speed_x ,float speed_z)
    {
        Vector3 myPosition = this.transform.position;

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

    void afterAttackMove(float speed_x, float speed_z)
    {
        Vector3 myPosition = this.transform.position;

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

    void AttackControl(Vector3 destinationPos, Vector3 originalPos)
    {
        Vector3 myPosition = this.transform.position;

        if (!attackEnded)
        {
            if (myPosition != destinationPos)
            {
                beforeAttackMove(speed_x,speed_z);
            }

            else
            {
                animator.SetTrigger("Attack");
                attackEnded = true;
            }
        }
        else
        {
            if (myPosition != originalPos)
            {
                afterAttackMove(speed_x, speed_z);
            }
        }

    }

    


}
