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

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bool isFlip = (mousePos.x > transform.position.x) ? false : true;

        Vector2 gunPos = isFlip ? leftweaponposition.position : rightweaponposition.position;
        Vector2 direction = isFlip ? gunPos - mousePos : mousePos - gunPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        CurrentWeapon.transform.position = gunPos;
        CurrentWeapon.transform.localScale = isFlip ? new Vector3(-1, 1, 1) : Vector3.one;
        CurrentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        CurrentWeapon.IsFlip = isFlip;

        _movement.FlipAnim = isFlip;

        if (_tryShoot)
            CurrentWeapon.Shoot();
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon != null)
            CurrentWeapon = weapon;

    }
}
