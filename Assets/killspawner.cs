using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killspawner : MonoBehaviour
{
    private Collider2D _collider2D;



    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);


    }
}
