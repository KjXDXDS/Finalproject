using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesound : MonoBehaviour
{
    public AudioClip _audioClip;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

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
}
