using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickerhandler : MonoBehaviour
{
    public Color color = Color.red;
    public float Duration = 1.0f;
    public float interval = 0.2f;

    private Color _originalColor;

    private Health _health;
    private SpriteRenderer _spriteRenderer;

    private bool _canStartFlicker = false;

    void Start()
    {
        _health = GetComponentInParent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer != null)
            _originalColor= _spriteRenderer.color;

        if ( _health != null )
        {
            _health.OnHit += Flicker;
            _health.OnHitReset += StopFlicker;

        }
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            _health.OnHit -= Flicker;
            _health.OnHitReset -= StopFlicker;

        }
    }
    private void Flicker(GameObject source)
    {
        _canStartFlicker=true;
        StartCoroutine(DoFlicker());
            
    }
    private void StopFlicker()
    {
        _canStartFlicker=false;
    }
        
    IEnumerator DoFlicker() 
    {
        float duration = Duration;
        float flickerDuration = interval;
        Color _flickerColor = color;

        bool colorFlicker = false;

        while ( duration > 0) 
        { 
            if (flickerDuration <= 0) 
            {
                colorFlicker=  !colorFlicker;
                flickerDuration = interval;
            }

            if (colorFlicker) 
            {
                _spriteRenderer.color = _flickerColor;
               
            }
            else
            {
                _spriteRenderer.color = _originalColor;
                

            }

            flickerDuration -= Time.deltaTime;
            duration -= Time.deltaTime;
            yield return null;
        }
        _spriteRenderer.color = _originalColor;

    }


}

