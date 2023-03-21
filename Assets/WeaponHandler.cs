using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Transform rightweaponposition;
    public Transform leftweaponposition;

    protected bool _tryShoot = false;

    protected movement _movement;


    private void Start()
    {
        _movement= GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButton("Fire1"))
            _tryShoot= true;

        if (Input.GetButtonUp("Fire1"))
            _tryShoot= false;

        if (_tryShoot) 
        {
            CurrentWeapon.Shoot();
        }

        HandleWeapon();
       
    }
       protected virtual void HandleInput()
    {

    }

    protected virtual void HandleWeapon()
    {
        if (CurrentWeapon == null) 
            return;

        bool isFlip = false;

        if ( _movement != null && _movement.FlipAnim)
            isFlip = true;


        if ( isFlip )

        {
            CurrentWeapon.transform.position = leftweaponposition.position;
            CurrentWeapon.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            CurrentWeapon.transform.position = rightweaponposition.position;
            CurrentWeapon.transform.localScale = Vector3.one;
        }
        
    }
}
