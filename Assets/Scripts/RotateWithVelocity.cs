using System;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        Vector3 forwardVelocity = _rigidbody.linearVelocity;

        if (forwardVelocity.sqrMagnitude > 0.1f)
        {
            transform.forward = forwardVelocity.normalized;
        }
        else
        {
            transform.forward = Vector3.forward;
        }    
    }
}
