using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Import UnityEvents

public class WeightButton : MonoBehaviour
{
    public Animator animator;
    public bool Actife = false;

    // UnityEvent for On and Off actions
    public UnityEvent onActivation;
    public UnityEvent onDeactivation;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Active", true);
        Actife = true;
        // Invoke the UnityEvent for activation
        onActivation.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Active", false);
        Actife = false;
        // Invoke the UnityEvent for deactivation
        onDeactivation.Invoke();
    }
}
