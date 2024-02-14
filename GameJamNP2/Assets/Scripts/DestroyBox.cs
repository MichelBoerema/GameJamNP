using System.Collections;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isAttacking");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyableObjects"))
        {
            Destroy(other.gameObject);
        }
    }
}