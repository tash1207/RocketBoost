using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationStrength = 100f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }
        else if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
    }
}
