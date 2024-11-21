using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public DraculaAgent Owner;
    [SerializeField] public GameObject ProjectileObject;
    [SerializeField] public Transform spawnTransform;
    [SerializeField] public float FireCooldown = 0.5f;

    // Maybe
    private bool isReady = true;
    private float cooldownTimer = 0;
    public float throwAngle = 0;
    public float throwPower = 0;

    void Start()
    {
        cooldownTimer = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cooldownTimer);
        if (!isReady && cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }else
        {
            isReady = true;
        }
    }

    public void FireWeapon()
    {
        if (isReady)
        {
            Debug.Log("Please Work");
            Quaternion tempR = transform.rotation;
            tempR.x += throwAngle;

            Transform tempTransform = spawnTransform;
            tempTransform.position = spawnTransform.position;
            tempTransform.rotation = tempR;

            //Vector3 force = Quaternion.Euler(0, throwAngle, 0) * transform.forward;
            Vector3 force = transform.forward;
            force.y += throwAngle / 90;
            force.Normalize();

            // Pew
            GameObject newProjectile = Instantiate(ProjectileObject, tempTransform.position, tempTransform.rotation);

            newProjectile.GetComponent<Rigidbody>().AddForce(force * throwPower);

            isReady = false;
            cooldownTimer = FireCooldown;
        }
    }
}
