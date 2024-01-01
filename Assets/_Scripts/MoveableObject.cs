using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{

    public float pushForce = 1f;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody _rigg = hit.collider.attachedRigidbody;

        if (_rigg != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            _rigg.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
