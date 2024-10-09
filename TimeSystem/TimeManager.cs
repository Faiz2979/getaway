using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action onMinuteChange;
    public static Action onHourChange;
    public float minuteToRealTime = 0.5f;
    public float timer;
    public static int Minute{get;private set;}
    public static int Hour{get;private set;}

    void Start()
    {
        Minute=0;
        Hour=10;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Minute++;
            onMinuteChange?.Invoke();
            timer = minuteToRealTime;
            if(Minute>=60)
            {
                Minute = 0;
                Hour++;
                if(Hour>=24)
                {
                    Hour = 0;
                }
                onHourChange?.Invoke();
            }
        }
    }
}
