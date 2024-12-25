using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float groundDist;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        // 後で消す
        /*foreach (GameObject go in SystemManager.currentPartyMember)
        {
            Debug.Log(go.GetComponent<Ally>().characterName);
        }*/

        Debug.Log(SystemManager.number);

    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, groundLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        if (SceneManager.GetActiveScene().name == "DungeonScene")// ダンジョンシーンの時は水平方向のみの移動
        {
            if (!ToBattle.isSelecting)
            {
                float x = Input.GetAxis("Horizontal");
                Vector3 moveDir = new Vector3(x, 0, 0);
                rigidBody.velocity = moveDir * speed;

                if (x != 0 && x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (x != 0 && x > 0)
                {
                    spriteRenderer.flipX = false;
                }

                if (Input.GetButton("Horizontal"))
                {
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                }
            }
        }
        else// ダンジョンシーン以外はxz軸で移動可能
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDir = new Vector3(x, 0, z);
            rigidBody.velocity = moveDir * speed;

            if (x != 0 && x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (x != 0 && x > 0)
            {
                spriteRenderer.flipX = false;
            }

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }        
    }
}
