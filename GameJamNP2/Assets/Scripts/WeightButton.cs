using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Import UnityEvents

public class WeightButton : MonoBehaviour
{
    public Animator animator;
    public bool Actife = false;
    public List<GameObject> objects = new List<GameObject>();

    // UnityEvent for On and Off actions
    public UnityEvent onActivation;
    public UnityEvent onDeactivation;

    private void OnTriggerEnter(Collider other)
    {
        objects.Add(other.gameObject);

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
animator.SetBool("Active", true);
Actife = true;
// Invoke the UnityEvent for activation
onActivation.Invoke();
animator.SetBool("Active", false);
Actife = false;
// Invoke the UnityEvent for deactivation
onDeactivation.Invoke();