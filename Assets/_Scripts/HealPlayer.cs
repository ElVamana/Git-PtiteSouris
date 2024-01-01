using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] int gainAmount;
    public GameObject pouf;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(pouf, this.transform.position, transform.rotation);
            other.GetComponent<PlayerHealthHandler>().GainHealth(gainAmount);
            Destroy(this.gameObject);
        }
    }

}
