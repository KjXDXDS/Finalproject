using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class monsterdiesound : Health 

{
    public GameObject monsterdie;

    public override void Die()
    {
       

        if (monsterdie != null)
        {
          
            Instantiate( monsterdie, transform.position, transform.rotation);
        }

        base.Die();
    }
}
