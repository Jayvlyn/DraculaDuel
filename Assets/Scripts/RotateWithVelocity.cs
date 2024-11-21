using System;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        Vector3 forwardVelocity = _rigidbody.linearVelocity;

        // Ensure the forward direction is normalized (to avoid scaling issues)
        if (forwardVelocity.sqrMagnitude > 0.1f) // Ensure velocity is not zero
        {
            transform.forward = forwardVelocity.normalized;
        }
        else
        {
            // Optional: Set a default forward direction if velocity is near zero
            transform.forward = Vector3.forward;
        }    }
}
