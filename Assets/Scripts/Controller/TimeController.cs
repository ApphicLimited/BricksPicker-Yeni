﻿using System.Collections;
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

        SlowDownFactor = 0.04f;
        SlowDownTimeAmaount = 1f;
    }

        // Update is called once per frame
        void Update()
    {
        Time.timeScale += (1f / SlowDownTimeAmaount) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

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
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void StopSlowMotion()
    {
        IsSlowMotionStart = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}