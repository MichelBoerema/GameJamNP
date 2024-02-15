using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject book;
    public GameObject Trigger2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            book.SetActive(true);
            Trigger2.SetActive(true);
        }
    }
}
