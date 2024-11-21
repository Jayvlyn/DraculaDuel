using UnityEngine;

public class ConePerceptionShape : CylinderPerceptionShape
{
    [SerializeField] private float tiltAngle = 30;
    [SerializeField] private float slope = 10;
    public override Ray[] GetRays(Vector3 forward)
    {
        Ray[] rays = new Ray[rayCount];
        float angleRad = Mathf.Deg2Rad * degreeArc * 0.5f;
        for (int i = 0; i < rayCount; i++)
        {
            float t = i * 1.0f / (rayCount - 1);
            float azimuthalAngle = Mathf.Lerp(-angleRad, angleRad, t);
            float adjustedAngleRad = angleRad * slope;
            float polarAngle = Mathf.Lerp(-adjustedAngleRad, adjustedAngleRad, t);
            Vector3 rotatedDirection = new Vector3(
                Mathf.Sin(polarAngle) * Mathf.Cos(azimuthalAngle),
                Mathf.Sin(polarAngle) * Mathf.Sin(azimuthalAngle),
                Mathf.Cos(polarAngle)
            );
            Vector3 relativeOffset = centerOffset + transform.forward;
            rotatedDirection = Quaternion.LookRotation(-forward) * rotatedDirection;
            rotatedDirection = Quaternion.Euler(tiltAngle, 0, 0) * rotatedDirection;
            rays[i] = new Ray(transform.position + relativeOffset, rotatedDirection * maxDistance);
            rays[i] = new Ray(transform.position + relativeOffset, -rotatedDirection * maxDistance);
        }
        return rays;
    }
}