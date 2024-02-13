using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private RaycastHit _Hit;
    private bool inRangeOfBox = false;

    void Update()
    {
        if (inRangeOfBox)
        {
            if (Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit) && _Hit.transform.CompareTag("DestroyableObjects"))
            {
                Destroy(_Hit.transform.gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyableObjects"))
        {
            inRangeOfBox = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyableObjects"))
        {
            inRangeOfBox = false;
        }
    }
}
