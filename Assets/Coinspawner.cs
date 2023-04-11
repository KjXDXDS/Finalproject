using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinspawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public GameObject RareCoinPrefab;

    public Vector2 MinMaxPos;

    public float RareSpawnChance = 0.1f;

    public float SpawnInterval = 1f;

    public bool isSpawning = false;

    public float spawnTimer;

    private bool _isTimeUp = false;

    private void OnEnable()
    {
        Timemanager.OnEnd += GameEnd;
    }

    private void OnDisable()
    {
        Timemanager.OnEnd -= GameEnd;
    }

    private void Start()
    {
        spawnTimer = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // if (isSpawning)
        //     return;

        if (_isTimeUp)
            return;


        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            // isSpawning = false;
        }
        else
        {
            float diceroll = Random.Range(0f, 100f);

            if (diceroll <= RareSpawnChance)
            {
                GameObject.Instantiate(RareCoinPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(-360, 360)));
            }

            else
            {
                GameObject.Instantiate(CoinPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(-360, 360)));
            
            }

            // isSpawning = true;
            spawnTimer = SpawnInterval;
        }
    }

    private void GameEnd()
    {
        _isTimeUp = true;
    }

}
