using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goombamovement : movement

{
    protected bool FlipDirection = false;

    protected override void HandleInput()
    {
        if (FlipDirection)
        {
            _InputDirection = Vector2.left;
        }
        else
        {

            _InputDirection = Vector2.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Boundary"))
            return;

        FlipDirection = !FlipDirection;

    }
}
