using System;
using UnityEngine;

public abstract class PerceptionShape : MonoBehaviour
{
    [SerializeField] protected int rayCount = 10;
    [SerializeField] protected float maxDistance = 10f;
    [SerializeField] protected Vector3 centerOffset;
    public abstract Ray[] GetRays(Vector3 forward);

    private void OnDrawGizmosSelected()
    {
        if (!enabled) return;
        Gizmos.color = Color.red;
        foreach (var r in GetRays(transform.forward))
        {
            Gizmos.DrawRay(r.origin, r.direction * maxDistance);
        }
    }
}