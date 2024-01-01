using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;
    public float knockbackRadius, explosionForce;
    public int damage;
    public float pushBack;


    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        knockback();
        Destroy(gameObject);
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, knockbackRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, knockbackRadius);
            }

            if (nearbyObject.tag == "Player")
            {
                Vector3 push = transform.position - nearbyObject.transform.position;
                push = push.normalized * pushBack;
                nearbyObject.GetComponent<PlayerHealthHandler>().LoseHealth(damage, push);
            }
        }
    }
}
