using System.Collections.Generic;
using UnityEngine;

public class AIPerception : MonoBehaviour
{
    [SerializeField] private PerceptionShape _perceptionShape;
    public List<TargetHitData> PerceiveTargets(Vector3 forwardDirection)
    {
        List<TargetHitData> result = new List<TargetHitData>();
        Ray[] rays = _perceptionShape.GetRays(forwardDirection);
        foreach (var r in rays)
        {
            Physics.Raycast(r, out RaycastHit hit);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out PerceptionHitTarget data))
                {
                    result.Add(new TargetHitData(data.TargetType, data.transform, hit.distance, Time.time));
                }
            }
        }
        return result;
    }
}


public class TargetHitData
{
    public TargetType type;
    public Transform transform;
    public float distance;
    public float time;

    public TargetHitData(TargetType t, Transform tr, float d, float ti)
    {
        type = t;
        transform = tr;
        distance = d;
        time = ti;
    }
}

