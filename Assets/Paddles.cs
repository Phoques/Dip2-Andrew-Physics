using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public KeyCode keyCode;//This lets you assign the key in the inspector.
    Rigidbody rb;
    public Vector3 offsetCenter;
    public float forceMultiplier;

    private bool _isKeyPressed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = offsetCenter;

    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            _isKeyPressed = true;
        }

    }

    private void FixedUpdate()
    {
        if(!_isKeyPressed)
        {
            return;
        }

        Vector3 axis = transform.up;
        rb.AddTorque(axis * forceMultiplier, ForceMode.Acceleration);
    }
}
