using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource idleAgrassiveAudioSource;
    [SerializeField] AudioSource takeOffAudioSource;

    public float timer = 6f;
    [SerializeField] ParticleSystem dragonFire;
    [SerializeField] GameObject damageCollider;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //flam aan en collider 1 sec later
        if (timer <= 10)
        {
            dragonFire.Play();
        }
        if (timer <= 9)
        {
            damageCollider.GetComponent<CapsuleCollider>().enabled = true;
        }

        //flam uit en collider later
        if (timer <= 7f)
        {
            dragonFire.Stop();
        }
        if (timer <= 6)
        {
            damageCollider.GetComponent<CapsuleCollider>().enabled = false;
        }
        //reset timer
        if(timer <=0)
        {
            timer = 10f;
        }
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
    public void PlayDamageAudio()
    {
        idleAgrassiveAudioSource.Stop();
        audioSource.Play();
    }
    public void PlayTakeOffAudio()
    {
        idleAgrassiveAudioSource.Stop();
        audioSource.Stop();
        takeOffAudioSource.Play();
    }
    public void PlayIdleAudio()
    {
        audioSource.Stop();
        idleAgrassiveAudioSource.Play();
    }
}
