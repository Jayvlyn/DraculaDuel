using Unity.VisualScripting;
using UnityEngine;

public class GarlicGasGrenade : WeaponProjectile
{

    [SerializeField] public GameObject plumeObject;
    public float plumeSpawnDelay = 1.0f;
    public bool Active = false;
    public float GrenadeLifeTime = 10.0f;
    
    private float plumeSpawnTime;
    void Start()
    {
        Active = false;
        plumeSpawnTime = plumeSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            GrenadeLifeTime -= Time.deltaTime;
            plumeSpawnTime -= Time.deltaTime;

            if (plumeSpawnTime <= 0)
            {
                // new plumeObject
                float xVel = UnityEngine.Random.Range(-1.0f, 1.0f);
                float zVel = UnityEngine.Random.Range(-1.0f, 1.0f);
                float yVel = UnityEngine.Random.Range(0.0f, 1.0f);

                GameObject newPlume = Instantiate(plumeObject, this.transform.position, this.transform.rotation);
                newPlume.GetComponent<StinkyGarlicPlume>().GasDirection = new Vector3(xVel, yVel, zVel);
                plumeSpawnTime = plumeSpawnDelay;
            }
        }
        if(GrenadeLifeTime <= 0.0f)
        {
            Debug.Log("Kill");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            Active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
