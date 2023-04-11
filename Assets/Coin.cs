using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Coin : MonoBehaviour
{

    
    public int CoinsAmount = 10;

    protected gamemanager _gamemanager;

    private void Start()
    {
       _gamemanager = FindObjectOfType<gamemanager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.tag != "Player")
            return;

        if (_gamemanager != null)
        _gamemanager.CoinsCollected += CoinsAmount;


        Debug.Log("picked up " + CoinsAmount);
            Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;


        if (_gamemanager != null)
            _gamemanager.CoinsCollected += CoinsAmount;

        Destroy(gameObject);
    }

}
