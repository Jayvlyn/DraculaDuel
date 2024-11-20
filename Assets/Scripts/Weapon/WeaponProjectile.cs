using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Owner;
    public string targetTag;
    public GameObject projectile;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetOwner(GameObject owner)
    {
        Owner = owner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            other.GetComponent<Health>().ApplyDamage(1);
            //Owner.HitSuccess();
        }

        Destroy(this.gameObject);
        //Owner.HitMiss();
    }
}
