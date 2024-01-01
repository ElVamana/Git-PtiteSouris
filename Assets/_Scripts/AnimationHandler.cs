using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    Animator _animator;
 

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }


    public void Idle()
    {
        _animator.SetBool("do_idle", true);
    }   

    public void Run()
    {
        _animator.SetBool("do_idle", false);
    }

    public void Jump()
    {
        _animator.SetTrigger("do_jump");
    }   

    public void Airborn()
    {
        _animator.SetBool("do_airborn", true);
    }

    public void Landed()
    {
        _animator.SetBool("do_airborn", false);
    }

    public void Attack()
    {
        _animator.SetTrigger("do_attack");
    }

    void Update()
    {
        
    }
}
