using UnityEngine;
using UnityEngine.AI;


public class RangeAI : MonoBehaviour
{
    [SerializeField] private float maxDist;
    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;
    Vector3 startPos;
    [SerializeField] float attackRange = 12f;
    public GameObject bomb;
    public Transform cannonPoint;
    [SerializeField] float nextBomb;
    public float fireRate;
    public float bombSpeed = 32f;

    public int enemyHP;
    public GameObject ennemyDeathEffect;



    void Start()
    {
        startPos = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (playerTransform != null)
        {
            float currentDist = Vector3.Distance(transform.position, playerTransform.position);
            if (currentDist <= maxDist && currentDist > attackRange)
            {
                Vector3 targetToLookAt = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
                LookAtPlayer();
                navMeshAgent.SetDestination(playerTransform.position);
                //Invoke("Shoot", 1f);
                if (Time.time >= nextBomb)
                {
                    nextBomb = Time.time + 1f / fireRate;
                    Shoot();
                }
                //transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else if (currentDist <= attackRange)
            {
                LookAtPlayer();
                if (Time.time >= nextBomb)
                {
                    nextBomb = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else
            {
                navMeshAgent.SetDestination(startPos);
            }
        }
        else
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (enemyHP <= 0)
        {
            Instantiate(ennemyDeathEffect, transform.position, transform.rotation);
            Destroy(gameObject, 0.08f);
        }
    }
    
    void LookAtPlayer()
    {
        Vector3 targetToLookAt = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(targetToLookAt);
    }

    void Shoot()
    {
       GameObject bom = Instantiate(bomb, cannonPoint.position, transform.rotation);
        Vector3 aimingPlayer = playerTransform.position - transform.position;
        aimingPlayer = aimingPlayer.normalized;
        bom.GetComponent<Rigidbody>().AddForce(aimingPlayer * bombSpeed); //, ForceMode.Impulse);
        bom.GetComponent<Rigidbody>().useGravity = true;
        Destroy(bom, 5f);
    }

    public void TakeDamage(int dmg)
    {
        enemyHP -= dmg;
       
    }
}
