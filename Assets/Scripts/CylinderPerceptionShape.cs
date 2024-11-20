using UnityEngine;

public class CylinderPerceptionShape : PerceptionShape
{
    [SerializeField] protected float degreeArc = 90f;

    public override Ray[] GetRays(Vector3 forward)
    {
        Ray[] rays = new Ray[rayCount];
        for (int i = 0; i < rayCount; i++)
        {
            float t = i * 1.0f / (rayCount - 1);
            float angleOffForward = Mathf.LerpAngle(-degreeArc, degreeArc, t);
            rays[i] = new Ray(transform.position + centerOffset, (Quaternion.Euler(0, angleOffForward, 0) * forward.normalized) * maxDistance);
        }
        return rays;
    }
}