using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject pouf;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(pouf, this.transform.position, transform.rotation);
            other.GetComponent<PlayerHealthHandler>().GainMaxHealth();
            Destroy(gameObject);
        }
    }
}
