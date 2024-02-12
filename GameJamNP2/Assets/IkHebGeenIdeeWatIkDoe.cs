using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkHebGeenIdeeWatIkDoe : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    private float horizontal;
    private float vertical;
    private float moveSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3 (horizontal, vertical, 0) * moveSpeed;
    }
}
