using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationhandler : MonoBehaviour
{

    private Animator _animator;
    private movement _movement;

    private Vector3 _initialScale= Vector3.one;
    private Vector3 _flipScale= Vector3.one;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = transform.parent.GetComponent<movement>();

        _initialScale = transform.localScale;
        _flipScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
    }


    void Update()
    {
        HandleFlip();
        UpdateAnimator();
    }

    private void HandleFlip()
    {
        if (_movement == null) return;

       
        if (_movement.FlipAnim)  
        {
            transform.localScale = _flipScale;

        }
        else
        {
            transform.localScale = _initialScale;
        }
    }
    private void UpdateAnimator()
    {
        if (_animator == null || _movement == null)
            return;
            
      _animator.SetBool("IsRunning", _movement.IsRunning);
    }

    
}
