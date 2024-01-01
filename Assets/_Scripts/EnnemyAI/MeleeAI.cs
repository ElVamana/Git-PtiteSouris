using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;










public class MeleeAI : MonoBehaviour
{
    [SerializeField] private float maxDist;
    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;
    Vector3 startPos;
    [SerializeField] float meleeRange = 3f;

    public int enemyHP;
    public GameObject ennemyDeathEffect;

    public Animator SpiderAnim;
    bool alive;



    void Start()
    {
        startPos = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        alive = true;
    }

  
    void Update()
    {
        if (playerTransform != null && alive)
        {
            
            float currentDist = Vector3.Distance(transform.position, playerTransform.position);
            if (currentDist <= maxDist && currentDist > meleeRange)
            {
                transform.LookAt(playerTransform);
                navMeshAgent.SetDestination(playerTransform.position);
                SpiderAnim.SetBool("canWalk", true);
                SpiderAnim.SetBool("canAttack", false);
                // transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else if (currentDist <= meleeRange)
            {
           
                LookAtPlayer();
                SpiderAnim.SetBool("canAttack", true);
                SpiderAnim.SetBool("canWalk", false);
            }
            else
            {
                SpiderAnim.SetBool("canWalk", false);
                SpiderAnim.SetBool("canAttack", false);
                navMeshAgent.SetDestination(startPos);
            }
        }
        else
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (enemyHP <= 0 && alive)
        {
            alive = false;
            SpiderAnim.SetTrigger("canDie");
            Instantiate(ennemyDeathEffect, transform.position, transform.rotation);
            Destroy(gameObject,2.22f);
        }
    }

    void LookAtPlayer()
    {
        Vector3 targetToLookAt = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(targetToLookAt);
    }

    public void TakeDamage(int dmg)
    {
       enemyHP -= dmg;
                   
    }
}
