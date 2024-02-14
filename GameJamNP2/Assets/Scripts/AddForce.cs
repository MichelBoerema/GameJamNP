using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 forceDirection;
    public float forceMagnitude = 10.0f;

    public bool on = true;
    public float timer = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void DropBoxes()
    {
        if (on)
        {
            rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            on = false;
        }
    }
}
