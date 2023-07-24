using UnityEngine;

public class Paddles : MonoBehaviour
{
    public KeyCode keyCode;//This lets you assign the key in the inspector.
    Rigidbody rb;
    public Vector3 offsetCenter;
    public float forceMultiplier;

    private bool _isKeyPressed = false;

    public float rotationSpeed = 30f;
    public float activeRotation;
    public float inactiveRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = offsetCenter;

        inactiveRotation = rb.rotation.eulerAngles.y;

    }

    private void Update()
    {
        if(Input.GetKey(keyCode))
        {
            _isKeyPressed = true;
        }

    }

    private void FixedUpdate()
    {
        float targetAngle = _isKeyPressed ? activeRotation : inactiveRotation;
        float currentAngle = rb.rotation.eulerAngles.y;

        //Ternary operator is the ? then :
        //The equivalent is: if(_isKeyPressed){ targetAngle = activeRotation }, else{targetAngle = inactiveRotation}

        float angleDelta = targetAngle - currentAngle;

        

        //rb.MoveRotation();

    }
}
