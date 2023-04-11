using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{

    public delegate void OnTimeUpdate(int time);

    public static OnTimeUpdate OnTime;

    public delegate void OnTimeEnd();

    public static OnTimeEnd OnEnd;

    public int InitialDuration = 60;
    public float CurrentTime = 0;

    private bool _timeEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = InitialDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime <= 0)
        {
            if (!_timeEnd)
            {
                OnEnd.Invoke();
                _timeEnd = true;
                CurrentTime = 0;

            }

            return;

        }

        CurrentTime -= Time.deltaTime;

        OnTime.Invoke((int)CurrentTime);


    }
}
