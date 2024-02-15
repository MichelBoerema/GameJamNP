using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairButton : MonoBehaviour
{
    public Animator animator;
    
    public void OnButtonPress()
    {
        animator.SetBool("stairUp", true);
    }
    public void OnButtonRelease()
    {
        animator.SetBool("stairUp", false);
    }
}
