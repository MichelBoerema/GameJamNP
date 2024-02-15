using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public bool isOpenn = false;
    public bool inRange = false;

    [SerializeField] AudioSource openDoor;
    [SerializeField] AudioSource closeDoor;
    void Update()
    {
        if (inRange)
        {
            if (!isOpenn && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isOpen", true);
                isOpenn = true;
            }
            else if (isOpenn && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isOpen", false);
                isOpenn = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    public void OpenDoor()
    {
        openDoor.Play();
        animator.SetBool("isOpen", true);
    }
    public void CloseDoor()
    {
        closeDoor.Play();
        animator.SetBool("isOpen", false);
    }
}