using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class icesound : Health
{
    public GameObject IceBreakerSound;

    public override void Die()
    {
        if (IceBreakerSound != null)
        {
            Instantiate(IceBreakerSound, transform.position, transform.rotation);
        }

        base.Die();
    }
}
