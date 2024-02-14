using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour
{
    public int fuctionsCalled = 0;
    public Animator bossAnimator;
    public Animator cageAnim;
    public Animator cageAnim1;
    public Animator cageAnim2;
    private bool firtFunctionIsCalled = true;
    private bool secondFunctionIsCalled = true;
    private bool thirdFunctionIsCalled = true;

    [SerializeField] Rigidbody axe;

    private float timer = 2f;
    private bool timerIsActive = false;
    [SerializeField] private GameObject dragonCollider;
    void Update()
    {

        if (fuctionsCalled >= 3)
        {
            timerIsActive = true;
            if (timer <= 0)
            {
                bossAnimator.SetBool("Drakaris", false);
                bossAnimator.SetBool("IdleAgressive", false);
                bossAnimator.SetBool("TakeOff", true);
                dragonCollider.GetComponent<BoxCollider>().enabled = false;
                dragonCollider.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        if (timerIsActive)
        {
            timer -= Time.deltaTime;
        }
    }
    public void FirstAttack()
    {
        if (firtFunctionIsCalled)
        {
            fuctionsCalled++;
            firtFunctionIsCalled = false;
        }
    }
    public void SecondAttack()
    {
        if (secondFunctionIsCalled)
        {
            fuctionsCalled++;
            secondFunctionIsCalled = false;
        }
    }
    public void ThirdAttack()
    {
        if (thirdFunctionIsCalled)
        {
            axe.constraints = RigidbodyConstraints.None;
            fuctionsCalled++;
            thirdFunctionIsCalled = false;
        }
    }

    public void Liftcage0()
    {
        cageAnim.SetBool("Lift",true);
    }
    public void Liftcage1()
    {
        cageAnim1.SetBool("Lift", true);
    }
    public void Liftcage2()
    {
        cageAnim2.SetBool("Lift", true);
    }
}
