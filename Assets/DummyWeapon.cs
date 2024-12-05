using System;
using UnityEngine;

public class DummyWeapon : MonoBehaviour
{
    [SerializeField] private AgentWeapon weapon;
    [SerializeField] private Transform target;

    private void Update()
    {
        weapon.throwAngle = 45;
        weapon.throwPower = CalculateThrowPower();
        transform.LookAt(target);
        weapon.FireWeapon();
    }

    private float CalculateThrowPower()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance / 2f * 100f;
        return 500;
    }
}
