using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : movement
{
    protected override void HandleInput()
    {
        _InputDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if(Input.GetButtonDown("Jump"))
            DoJump();



    }

    protected override void Hit(GameObject source)
    {
        base.Hit(source);
        _rigidbody.gravityScale = 1f;
    }

    protected override void ResetMove()
    {
        base.ResetMove();
        _rigidbody.gravityScale = 7f;
    }

}
