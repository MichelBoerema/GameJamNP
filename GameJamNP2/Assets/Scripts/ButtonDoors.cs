using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoors : MonoBehaviour
{
    public Animator animator;
    public bool isOpenn = false;
    [SerializeField] AudioSource openDoor;
    [SerializeField] AudioSource closeDoor;
    public void OnDoorButtonPress()
    {
        openDoor.Play();
        animator.SetBool("isOpen", true);
    }
    public void OnDoorButtonRelease()
    {
        closeDoor.Play();
        animator.SetBool("isOpen", false);
    }
}