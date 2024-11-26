using UnityEngine;

public class StinkyGarlicPlume : MonoBehaviour
{
    [SerializeField] public float GasDuration = 2;
    [SerializeField] public Vector3 GasDirection;
    [SerializeField] public float GasSpreadSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GasDuration <= 0)
        {
            Destroy(this.gameObject);
        }
        GasDuration -= Time.deltaTime;

        this.transform.position += GasDirection * GasSpreadSpeed;

    }
}
