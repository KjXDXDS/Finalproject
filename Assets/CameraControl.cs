using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
 
    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = 1f;

    void FixedUpdate()
    {
        if(target == null)
        { return; }

        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);






    }
}


