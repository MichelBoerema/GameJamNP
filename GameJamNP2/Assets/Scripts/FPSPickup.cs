using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSPickup : MonoBehaviour
{
    private RaycastHit _Hit;

    private bool inRangeOfBox = false;
    private bool isHoldingBox = false;
    public GameObject box;

    [SerializeField]
    Transform boxLocation;
    void Start()
    {
        
    }
    void Update()
    {
        if (inRangeOfBox && !isHoldingBox)
        {
            if (Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit) && _Hit.transform.CompareTag("Box"))
            {
                box.transform.position = boxLocation.position;
                Rigidbody rb = box.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                box.transform.SetParent(boxLocation);
                isHoldingBox = true;
            }
        }

        if (isHoldingBox && Input.GetMouseButton(1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit) && _Hit.transform.CompareTag("Box"))
        {
            Rigidbody rb = box.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            box.transform.SetParent(null);
            isHoldingBox = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box = other.gameObject;
            inRangeOfBox = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            if (!isHoldingBox)
            {
                box = null;
                inRangeOfBox = false;
            }
        }
    }
}
