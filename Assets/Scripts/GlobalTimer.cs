using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToFinish = 10;
    private bool timerOn;

    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCheck();
    }
    private void TimerCheck()
    {
        if (timerOn)
        {
            if (timeToFinish > 0)
            {
                timeToFinish -= Time.deltaTime;
            }
            else
            {
                timeToFinish = 0;
                timerOn = false;

            }
        }
    }
}
