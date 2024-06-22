using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool attack;
    private bool hurt;
    private float speed = 2.0f;
    private Vector3 goal = new Vector3(2,2,2);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                attack = false;
            }

            if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                hurt = false;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                attack = true;
                Debug.Log("攻撃");
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                hurt = true;
                Debug.Log("攻撃を受けた");
            }

        }*/

        characterControll(goal);
            animator.SetBool("Attack", attack);

    }

    private void characterMove(float speed)
    {
        Vector3 myPosition = this.transform.position;
        myPosition.x += speed;
        myPosition.y += speed;
        myPosition.z += speed;

        this.transform.position = myPosition;

    }

    private void characterControll(Vector3 goal)
    {
        Vector3 myPosition = this.transform.position;
        if (myPosition != goal)
        {
            characterMove(speed);
        }

        else
        {
            attack = true;
            Debug.Log("攻撃");
            //animator.SetBool("Hurt", hurt);

        }

    }


}
