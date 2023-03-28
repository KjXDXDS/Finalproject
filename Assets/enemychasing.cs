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
            return;

        Vector2 direction = Target.position - transform.position;

        _InputDirection = direction;


    }

}
