using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sword : MonoBehaviour
{
    public int swordDamage;
    public float knockbackForce, knockBackEnnemyForce;
    public GameObject hitFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == ("EnemyMelee"))
            
        {
           Instantiate(hitFX, other.transform);
            other.GetComponent<MeleeAI>().TakeDamage(swordDamage);
            KnockBackEnnemy(other.gameObject);
        }

        if (other.gameObject.tag == "EnemyRange")
        {
            Instantiate(hitFX, other.transform);
            other.GetComponent<RangeAI>().TakeDamage(swordDamage);
            KnockBackEnnemy(other.gameObject);
        }



        if (other.gameObject.tag == "Interactable")
        {
            Instantiate(hitFX, other.transform);
            knockBack(other.gameObject);
        }
    }

    void knockBack(GameObject go)
    {
        Vector3 dif = go.transform.position - transform.position;
        dif = dif.normalized * knockbackForce;
        go.gameObject.GetComponent<Rigidbody>().AddForce(dif, ForceMode.Impulse);
    }

    void KnockBackEnnemy(GameObject go)
    {
        NavMeshAgent navMeshAgent = go.GetComponent<NavMeshAgent>();
        Vector3 dif = go.transform.position - transform.position;
        dif = dif * knockBackEnnemyForce / 2;
        dif = new Vector3(dif.x, 0, dif.z);
        navMeshAgent.Move(dif);
        go.gameObject.GetComponent<Rigidbody>().AddForce(dif, ForceMode.Impulse);
    }

}
