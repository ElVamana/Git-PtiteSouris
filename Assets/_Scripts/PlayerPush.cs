using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [SerializeField]
    float pushForce;

    void OnControllerColliderHit(ControllerColliderHit whatWeHit)
    {
        Rigidbody body = whatWeHit.collider.attachedRigidbody;
        if (body != null) 
        {
            Vector3 forceDirecton = whatWeHit.transform.position - transform.position;
            forceDirecton.y = 0;
            forceDirecton.Normalize();

            body.AddForceAtPosition(forceDirecton * pushForce, transform.position, ForceMode.Impulse);
        }
    }



}
