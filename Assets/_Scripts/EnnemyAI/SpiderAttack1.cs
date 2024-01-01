using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack1 : MonoBehaviour
{
    public GameObject attackBox;


    public void AttackOn()
    {
        attackBox.SetActive(true);
        Invoke("AttackOff", 0.3f);
    }

    public void AttackOff()
    {
        attackBox.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
