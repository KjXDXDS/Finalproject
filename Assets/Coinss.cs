using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinss : MonoBehaviour
{
    public delegate void OnCoinCollected(int amount);

    public static OnCoinCollected onCoinCollected;

    public bool Test = false;
    public int CoinsAmount = 10;
    public GameObject CoinsEffect;
    public GameObject _sprite;
    private Collider2D _collider2D;
    private AudioSource _audioSource;

    public AudioClip[] AudioClips;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {

        if (_audioSource != null)
        {
            int randomClip = UnityEngine.Random.Range(0, AudioClips.Length - 1);
            _audioSource.PlayOneShot(AudioClips[randomClip]);
        }

        GameObject.Instantiate(CoinsEffect, transform.position, Quaternion.identity);

        onCoinCollected.Invoke(CoinsAmount);
        // Debug.Log("collected")

        _sprite.SetActive(false);
        _collider2D.enabled = false;

        Invoke("Destroy", 1f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
