using Unity.VisualScripting;
using UnityEngine;

public class GarlicGasGrenade : WeaponProjectile
{

    
    public float plumeSpawnDelay;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocity == Vector3.zero)
        {

        }
    }
}
