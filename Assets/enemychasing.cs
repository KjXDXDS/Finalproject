using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;

public class enemychasing : movement
{
    public Transform Target;

 
    protected override void HandleInput()
    {
        if (Target == null)
        {
            //Debug.Log("no target");
            return;
        }
        if (_disableInput)
        {
            //Debug.Log("disabled input");
            return;
        }
        if (_rigidbody == null)
        {
            //Debug.Log("no rigidbody");s
            return;
        }

        _InputDirection = Target.position - transform.position;
        _InputDirection.Normalize();

        _rigidbody.velocity = new Vector2(_InputDirection.x * Acceleration, _InputDirection.y * Acceleration);

        if (_rigidbody.velocity.x == 0)
        {
            _IsRunning = false;
        }
        else
        {
            _IsRunning = true;
        }


    }

}
