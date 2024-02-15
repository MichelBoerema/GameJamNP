using System.Collections;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public Animator animator;
    public AudioSource audios;
    public AudioClip punch;
    public AudioClip Wall;
    public AudioClip Pipe;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }
    public void AudioPlay()
    {
        audios.clip = punch;
        audios.Play();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyableObjects"))
        {
            if (other.gameObject.name.Contains("wallD"))
            {
                audios.clip = Wall;
                audios.Play();
                Destroy(other.gameObject);
            }
            else
            {
                audios.clip = Pipe;
                audios.Play();
                Destroy(other.gameObject);
            }
           
            
        } 
    }
}