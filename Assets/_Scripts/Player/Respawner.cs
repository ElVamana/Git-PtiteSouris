using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    [SerializeField] GameObject playerToSpawn;
    Vector3 respawnPosition;
    Transform heartPanel;
    



    void Start()
    {
        heartPanel = GameObject.Find("HeartPanel").transform;
    }

    public void SetPosition(Vector3 newPosition)
    {
       respawnPosition = newPosition;
    }


    public void AA()
    {
       foreach (Transform child in heartPanel)
        {
            Destroy(child.gameObject);
        }
        // Debug.Log("RespawnNewLife method called");

        Instantiate(playerToSpawn, respawnPosition, Quaternion.identity);
    }

    public void PlayerIsDead()
    {
        //Debug.Log("PlayerIsDead method called");
        //wait 3 seconds
        //then call AA
       AA();
      // Invoke("AA",3f); 
    }

  


}
