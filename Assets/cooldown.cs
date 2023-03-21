using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class cooldown 
{
    public enum Progress
    {
        Ready,
        Started,
        InProgress,
        Finished
    }

    public float Duration = 1.0f;

    public Progress CurrentProgress = Progress.Ready;

    public bool IsOnCooldown
    {
        get { return _isOnCooldown;}
    }


    private float _currentDuration = 0f;

    private bool _isOnCooldown = false;

    private Coroutine _coroutine;

    public void Startcooldown()
    {
        if (CurrentProgress is Progress.Started or Progress.InProgress)
            return;

        _coroutine = CoroutineHost.Instance.StartCoroutine(DoCooldown());
    }
    public void Stopcooldown() 
    { 
        if (_coroutine != null )
            CoroutineHost.Instance.StopCoroutine( _coroutine );
        _currentDuration= 0f;
        _isOnCooldown= false;
        CurrentProgress= Progress.Ready;
    }

    private IEnumerator DoCooldown() 
    {
        CurrentProgress= Progress.Started ;
        _currentDuration = Duration;
        _isOnCooldown= true;

        while (_currentDuration> 0f) 
        { 
            _currentDuration -= Time.deltaTime;
            CurrentProgress= Progress.InProgress;

            yield return null;

        }
        _currentDuration= 0f;
        _isOnCooldown= false;
        CurrentProgress= Progress.Finished;

    }
}
  
