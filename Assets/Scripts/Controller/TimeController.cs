using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float SlowDownFactor { get; set; }
    public float SlowDownTimeAmaount { get; set; }
    public float scale;

    private bool IsSlowMotionStart;
    private float timer;

    private void Start()
    {
        IsSlowMotionStart = false;
        timer = 0;

        SlowDownFactor = 0.4f;
        SlowDownTimeAmaount = 0.8f;
    }

        // Update is called once per frame
        void Update()
    {
      

        if (IsSlowMotionStart)
        {
            timer += Time.deltaTime;

            if (timer > SlowDownTimeAmaount)
            {
                timer = 0;
                StopSlowMotion();
            }
        }
    }

    public void DoSlowMotion()
    {
        IsSlowMotionStart = true;
        Time.timeScale = SlowDownFactor;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void StopSlowMotion()
    {
        IsSlowMotionStart = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;
    }
}