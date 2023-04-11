using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    public float LifetimeDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", LifetimeDuration);
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
