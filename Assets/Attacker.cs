using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private AgentWeapon _weapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _weapon.throwAngle = 45;
            _weapon.throwPower = 500;
            _weapon.FireWeapon();
        }
    }
}
