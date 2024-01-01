using UnityEngine;


public class CamFollow : MonoBehaviour
{
    [SerializeField]
    Transform targetToFollow;
    public Vector3 offset;
    public float smoothDuration;



    void Start()
    {
        targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (targetToFollow != null)
        {
//Debug.Log("targetToFollow is not null");          
            Vector3 desiredPosition = targetToFollow.position + offset;
            Vector3 smoothFollow = Vector3.Lerp(transform.position, desiredPosition, smoothDuration * Time.deltaTime);
            transform.position = smoothFollow;
        }
        else
        {
          //  Debug.Log("targetToFollow is null");
            targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}

/*


public class CamFollow : MonoBehaviour
{
    [SerializeField]
    Transform targetToFollow;
    public Vector3 offset;
    public float smoothDuration;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (targetToFollow == null)
        {
            Debug.Log("targetToFollow is null");
            FindPlayer();
        }
        else
        {
            Debug.Log("targetToFollow is not null");
            UpdateCameraPosition();
        }
    }

    void FindPlayer()
    {
        targetToFollow = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (targetToFollow != null)
        {
            UpdateCameraPosition();
        }
    }

    void UpdateCameraPosition()
    {
        if (targetToFollow != null)
        {
            Vector3 desiredPosition = targetToFollow.position + offset;
            Vector3 smoothFollow = Vector3.Lerp(transform.position, desiredPosition, smoothDuration * Time.deltaTime);
            transform.position = smoothFollow;
        }
    }
}
*/
