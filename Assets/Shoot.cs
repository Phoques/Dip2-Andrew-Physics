using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Rigidbody rb;

    private bool _shot = false;
    private bool _applyForce = false;

    private float _currentForce = 0;
    public float _forceBuild; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_shot)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //PushBall();
            _currentForce += Time.deltaTime * _forceBuild;

        }
        if(_currentForce != 0 && Input.GetKeyUp(KeyCode.Space))
        {
            _applyForce = true;
        }

    }

    private void FixedUpdate()
    {
        //This function has a problem if the ball rolls, as the 'forward' add force is Z axis, and if the ball rolls, it can shoot out of the board.
        if (!_applyForce)
        {
            return;
        }

        if (_applyForce)
        {
            rb.isKinematic = false; // Would need to trigger this.
            Vector3 forward = transform.forward;
            rb.AddForce(forward * _currentForce, ForceMode.Impulse); // there are 4 types of forcemode.
            _currentForce = 0;
            _applyForce = false;
        }
    }

    private void PushBall() // mine
    {
        rb.AddForce(0, 0, 30);
    }



}
