using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    public Vector3 From;
    public Vector3 To;
    public float AnimationSpeed;

    public bool IsAnimationStarted { get; set; }
    public bool IsAnimationDone { get; set; }
    public bool IsReverseAnimationStarted { get; set; }
    public bool IsReverseAnimationDone { get; set; }

    private Vector3 FromClone;
    private Vector3 ToClone;
    private RectTransform RectTransform;

    public void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        RectTransform.localPosition = From;

        FromClone = From;
        ToClone = To;
    }

    void Update()
    {
        #region START ANIMATION

        if (IsAnimationStarted)
        {
            RectTransform.localPosition = Vector3.Lerp(RectTransform.localPosition, To, Time.deltaTime * AnimationSpeed);

            if (Vector3.Distance(RectTransform.localPosition, To) < 0.01f)
            {
                IsAnimationStarted = false;
                IsAnimationDone = true;
            }
        }

        #endregion

        #region REVERSE ANIMATION

        if (IsReverseAnimationStarted)
        {
            RectTransform.localPosition = Vector3.Lerp(RectTransform.localPosition, To, Time.deltaTime * AnimationSpeed);

            if (Vector3.Distance(RectTransform.localPosition, To) < 0.01f)
            {
                IsReverseAnimationStarted = false;
                IsReverseAnimationDone = true;
            }
        }

        #endregion
    }

    public void StartAnimation()
    {
        ResetAnimationStates();
        IsAnimationStarted = true;

        From = FromClone;
        To = ToClone;
    }

    public void StartReversAnimation()
    {
        ResetAnimationStates();
        IsReverseAnimationStarted = true;
        //IsReverseAnimationDone = false;
        //IsReverseAnimationStarted = true;
        //IsAnimationDone = false;

        From = ToClone;
        To = FromClone;
    }

    public void ResetAnimationStates()
    {
        IsAnimationStarted = false;
        IsAnimationDone = false;
        IsReverseAnimationStarted = false;
        IsReverseAnimationDone = false;
    }
}

