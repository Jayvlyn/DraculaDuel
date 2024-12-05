using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WeaponHitReciever Owner;
    [SerializeField] string targetTag;
    public GameObject projectile;

    protected Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetOwner(WeaponHitReciever owner, string targetTag)
    {
        Owner = owner;
        this.targetTag = targetTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Health h = other.GetComponent<Health>();
            if (h != null)
            {
                h.ApplyDamage(1);
                Owner.ReceiveHit(true, h.GetHealthPercent());
                Destroy(gameObject);
            }
            return;
        }

        if (!other.gameObject.CompareTag(this.gameObject.tag))
        {
            Destroy(this.gameObject);
            Owner.ReceiveHit(false, 100);
            return;
        }
    }
}
