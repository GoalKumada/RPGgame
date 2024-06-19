using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private bool attack;
    private bool hurt;

    void Start()
    {
        
    }

    void Update()
    {
        if (Mouse.current != null)
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
        }

        animator.SetBool("Attack", attack);
        animator.SetBool("Hurt", hurt);

    }
}
