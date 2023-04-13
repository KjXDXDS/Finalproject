using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform Spawnpos;
    public cooldown ShootInterval;

    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool IsFlip
    {
        set { _isFlip = value;}   
    }
    private bool _isFlip = false;

    void Update()
    {
        if (ShootInterval.CurrentProgress != cooldown.Progress.Finished)
            return;
        ShootInterval.CurrentProgress = cooldown.Progress.Ready;
    }
    public void Shoot()
    {
        if (ShootInterval.CurrentProgress != cooldown.Progress.Ready) 
            return;

        GameObject bullet = GameObject.Instantiate(Projectile,Spawnpos.position ,Spawnpos.rotation);


         if (_isFlip)
                bullet.GetComponent<Projectile>().Speed *= -1;

        ShootInterval.Startcooldown();
        
        if(_audioSource != null) _audioSource.Play();
    }
}
