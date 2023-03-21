using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform LeftBorder;
    public Transform RightBorder;
    
    public Vector2 PositionOffset= Vector2.zero;
    public float LerpSpeed = 5f;

    protected float targetXPos = 0f;

    public GameObject _player;

    

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void FixedUpdate()
    {
        if (_player == null)
            return;

        float XPos = Mathf.Clamp(_player.transform.position.x, LeftBorder.position.x+8 , RightBorder.position.x+8);
        targetXPos = Mathf.Lerp(targetXPos, _player.transform.position.x,Time.deltaTime + LerpSpeed);
        Debug.Log(targetXPos);

        transform.position = new Vector3(targetXPos, 0 , -10f );

       

    }
}
