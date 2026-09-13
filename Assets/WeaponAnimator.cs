using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float horizontal =
            Input.GetAxisRaw("Horizontal");

        float vertical =
            Input.GetAxisRaw("Vertical");

        bool walking =
            horizontal != 0 ||
            vertical != 0;

        animator.SetBool(
            "Walking",
            walking
        );
    }

    public void PlayFireAnimation()
    {
        animator.SetTrigger("AttackFire");
    }

    public void PlayLightningAnimation()
    {
        animator.SetTrigger("AttackLightning");
    }

    public void PlayRootsAnimation()
    {
        animator.SetTrigger("AttackRoots");
    }
}