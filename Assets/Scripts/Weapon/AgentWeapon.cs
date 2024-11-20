using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public DraculaAgent Owner;
    [SerializeField] public GameObject ProjectileObject;
    [SerializeField] public Transform Proj_SpawnTransform;
    [SerializeField] public float FireCooldown = 3;

    // Maybe
    private bool isReady = true;
    private float cooldownTimer = 0;
    private float throwAngle = 0;
    private float throwPower = 0;

    void Start()
    {
        cooldownTimer = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady && cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void FireWeapon()
    {
        if (isReady)
        {
            Quaternion tempR = Proj_SpawnTransform.rotation;
            tempR.x += throwAngle;

            Transform tempTransform = Proj_SpawnTransform;
            tempTransform.position = Proj_SpawnTransform.position;
            tempTransform.rotation = tempR;

            Vector3 force = Quaternion.Euler(0, throwAngle, 0) * tempTransform.forward;
            force.Normalize();

            // Pew
            GameObject newProjectile = Instantiate(ProjectileObject, tempTransform.position, tempTransform.rotation);

            newProjectile.GetComponent<Rigidbody>().AddForce(force * throwPower);

            isReady = false;
            cooldownTimer = FireCooldown;
        }
    }
}
