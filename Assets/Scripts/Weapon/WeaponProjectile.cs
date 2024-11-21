using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public DraculaAgent Owner;
    public string targetTag;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // Rotate the stake based on it's velocity ??
        //transform.RotateAround(transform.position,)
    }

    void SetOwner(DraculaAgent owner)
    {
        Owner = owner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            other.GetComponent<Health>().ApplyDamage(1);
            Owner.HitSuccess();
            Destroy(gameObject);
            return;
        }

        if (!other.gameObject.CompareTag(this.gameObject.tag))
        {
            Destroy(this.gameObject);
            Owner.HitMiss();
            return;
        }
    }
}
