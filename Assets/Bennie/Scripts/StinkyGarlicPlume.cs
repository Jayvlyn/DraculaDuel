using UnityEngine;

public class StinkyGarlicPlume : MonoBehaviour
{
    [SerializeField] public float GasDuration = 5;
    [SerializeField] public Vector3 GasDirection;
    [SerializeField] public float GasSpreadSpeed;
    [SerializeField] public Material GasMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Renderer m_renderer;

    void Start()
    {
        GasSpreadSpeed = GasSpreadSpeed * 0.001f;
        m_renderer = GetComponent<Renderer>();
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


        Color color = m_renderer.material.color;
        if(color.a > 0.01f)
        { 
            color.a -= 0.00015f;
            m_renderer.material.color = color;
        }

    }
}
