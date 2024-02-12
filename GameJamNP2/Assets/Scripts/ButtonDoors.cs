using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoors : MonoBehaviour
{
    public Animator animator;
    public bool isOpenn = false;

    public void OnDoorButtonPress()
    {
        animator.SetBool("isOpen", true);
    }
    public void OnDoorButtonRelease()
    {
        animator.SetBool("isOpen", false);
    }
}