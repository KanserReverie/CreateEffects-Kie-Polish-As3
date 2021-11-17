using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPIIIIN : MonoBehaviour
{
    private Rigidbody rb;
    private float xvalue, yvalue;
    private Vector3 spin = new Vector3(4, 5, 0);
    
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    void FixedUpdate()
    {
        
        rb.AddTorque(spin);
    }
}
