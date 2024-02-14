using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Drakaris"))
        {
            animator.SetBool("Drakaris", false);
            animator.SetBool("IdleAgressive", true);
        }
    }

    public void AnimateDamage()
    {
        animator.SetBool("IdleAgressive", false);
        animator.SetBool("Drakaris", true);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DragonBox") || other.gameObject.CompareTag("DamagePillar"))
        { 
            AnimateDamage();
        }
    }
}
