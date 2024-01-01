using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject swordAttack;
    public GameObject swingFX;
    public Transform swingLocation;


    // Start is called before the first frame update
    void Start()
    {
        swordAttack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwingOn()
    {
        swordAttack.SetActive(true);
        GameObject slash = Instantiate(swingFX, swingLocation.position, Quaternion.Euler(90,0,100));
        slash.transform.SetParent(transform);
    }

    public void SwingOff()
    {
        swordAttack.SetActive(false);
    }

}
