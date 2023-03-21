using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform Spawnpos;
    public cooldown ShootInterval;




    public bool isFlip
    {
        set {isFlip = value;}   
    }

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

        ShootInterval.Startcooldown();
        
    }
}
