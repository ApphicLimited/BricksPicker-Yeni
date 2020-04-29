using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPoint : MonoBehaviour
{
    public FadeOut AnimationFadeOut;
    public Move AnimationMove;

    public void StartAnimation()
    {
        AnimationFadeOut.StartAnimation = true;
        AnimationMove.StartAnimation = true;
    }
}
