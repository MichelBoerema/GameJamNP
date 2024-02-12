using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public Animator animator;
    public bool Actife = false;
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Active", true);
        Actife = true;
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Active", false);
        Actife = false;
    }
}
