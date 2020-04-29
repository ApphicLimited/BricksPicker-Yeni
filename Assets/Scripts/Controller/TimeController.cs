using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float SlowDownFactor;
    public float SlowDownTimeAmaount;
    public float scale;

    private bool IsSlowMotionStart;

    private void Start()
    {
        IsSlowMotionStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSlowMotionStart)
        {
            Time.timeScale += (1f / SlowDownTimeAmaount) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

            scale = Time.timeScale;
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
    }
}