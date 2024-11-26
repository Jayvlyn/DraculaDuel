using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitReciever : MonoBehaviour
{
    private Queue<ProjectileHitData> hitQueue = new Queue<ProjectileHitData>();
    public void ReceiveHit(bool success, float healthPercent)
    {
        if(success) currentDPS += 1;
        hitQueue.Enqueue(new ProjectileHitData(Time.time, success, healthPercent));
        _draculaAgent.HitSuccess(new AgentHitRecieveData() { DPS = currentDPS, healthPercent = healthPercent });
    }

    [SerializeField] private float secondsForDPS = 10;

    [SerializeField] private DraculaAgent _draculaAgent;

    private float currentDPS = 0;
    private void Update()
    {
        if (hitQueue.Count > 0)
        {
            if (hitQueue.Peek().time < Time.time - secondsForDPS)
            {
                currentDPS -= hitQueue.Dequeue().success ? 1 : 0;
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
    public float DPS;
    public float healthPercent;
}