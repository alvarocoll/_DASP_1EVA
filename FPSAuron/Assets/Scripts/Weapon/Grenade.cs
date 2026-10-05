using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;

    private float countdown;

    float radius = 5f;

    public float explosionForce = 70f;

    bool exploded = false;

    public GameObject explosionEffect;


    void Start()
    {
        
        countdown = delay;

    }

  
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !exploded)
        {
            Explode();
            exploded = true;
        }

    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var rangeObjects in colliders) 
        {
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if (rb != null ) 
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
