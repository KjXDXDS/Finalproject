using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 1f;
    public float Speed = 10f;
    public float PushForce = 10f;
    public cooldown Lifetime;
    public LayerMask TargetLayerMask;

    private Rigidbody2D _rigidbody2D;
   
    void Start()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();

        Lifetime.Startcooldown();
        _rigidbody2D.AddRelativeForce(new Vector2(Speed, 0f));

    }

  
    void Update()
    {
        if (Lifetime.CurrentProgress != cooldown.Progress.Finished)
            return;

        Die();

    }
    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        Rigidbody2D targetRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

        if (targetRigidbody != null)
        {
            Vector3 pushDirection = (col.transform.position - transform.position).normalized* PushForce;

   
            targetRigidbody.AddForce(pushDirection);
        }

        Health targetHealth = col.gameObject.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.Damage(Damage, gameObject);
        }

        Die();




    }
}
