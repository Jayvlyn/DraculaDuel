using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitReciever : MonoBehaviour
{
    private List<ProjectileHitData> hitQueue = new List<ProjectileHitData>();
    public void ReceiveHit(bool success, float healthPercent)
    {
        if(success) currentDPS += 1;
        hitQueue.Add(new ProjectileHitData(Time.time, success, healthPercent));
        int misses = 0;
        int hits = 0;
        foreach (var hit in hitQueue)
        {
            if (hit.success)
            {
                hits++;
            }
            else
            {
                misses++;
            }
        }
        if(_draculaAgent != null) _draculaAgent.HitSuccess(new AgentHitRecieveData() { hits = hits, misses = misses, healthPercent = healthPercent }, success);
    }

    [SerializeField] private float secondsForDPS = 10;

    [SerializeField] private DraculaAgent _draculaAgent;

    private float currentDPS = 0;
    private void Update()
    {
        if (hitQueue.Count > 0)
        {
            if (hitQueue[0].time < Time.time - secondsForDPS)
            {
                currentDPS -= hitQueue[0].success ? 1 : 0;
                hitQueue.RemoveAt(0);
            }
        }
    }
}

public class ProjectileHitData
{
    public float time;
    public bool success;
    public float healthPercent;

    public ProjectileHitData(float t, bool s, float k)
    {
        time = t;
        success = s;
        healthPercent = k;
    }
}

public class AgentHitRecieveData
{
    public int hits;
    public int misses;
    public float healthPercent;
}