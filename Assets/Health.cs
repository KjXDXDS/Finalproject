using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public delegate void HHitEvent(GameObject source);

    public HHitEvent OnHit;

  
    public delegate void ResetEvent();

    public ResetEvent OnHitReset;

    public GameObject Deathparticles;

    private gamemanager _gamemanager;

    

    public float CurrentHealth
    { 
        get 

        { 
            return _currentHealth;
        } 
    }

    public cooldown Invulnerable;

    public float _currentHealth = 10f;

    public bool _canDamage = true; 


    private void Update()
    {
        ResetInvulnerable();
    }


    private void ResetInvulnerable()
    {
        if (_canDamage)
            return;

        if (Invulnerable.IsOnCooldown && _canDamage == false)
            return;

        _canDamage = true;
        OnHitReset?.Invoke();
        
    }
    public void Damage (float damageAmount , GameObject source )
    {

        if (!_canDamage)
            return;

        _currentHealth -= damageAmount;
        if (_currentHealth <= 0 ) 
        {
            Die();

        }
        Invulnerable.Startcooldown();
        _canDamage = false;
        OnHit?.Invoke(source);
    }

    public void Die () 
    {
        if (_gamemanager != null)
        {
            _gamemanager.IDie(this.gameObject);
           
        }


        GameObject.Instantiate(Deathparticles,transform.position,transform.rotation);
        Debug.Log("died");
        Destroy(this.gameObject);

    
       
    }

   
}
