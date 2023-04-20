using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Coinspawner : MonoBehaviour
{
    public int CoinAmount = 50;
    public GameObject CoinPrefab;
    bool _isTimeUp  = false;
    bool _startSpawning = false;

    public AudioClip _audioClip;

    private AudioSource _audioSource;

    


    private int _currentCoins = 50;
    private void OnEnable()
    {
        Timemanager.OnEnd += GameEnd;
    }

    private void OnDisable()
    {
        Timemanager.OnEnd -= GameEnd;
    }


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startSpawning)
            return;

        if (_currentCoins <= 0)
            return;

        GameObject.Instantiate(CoinPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(-360, 360)));

        _currentCoins--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _currentCoins = CoinAmount;

            _startSpawning = true;
        }


        if (collision.tag != "Player") return;

        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;

        if (_audioSource != null)
        {
            _audioSource.Stop();
        }
    }

    private void GameEnd()
    {
        _isTimeUp = true;
    }

}
