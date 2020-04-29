using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float AnimationSpeed;
    public Vector3 nextPosition;
    [Space]
    public bool SetNativePosition;
    [Space]
    public bool MoveAllAxis;
    public bool XAxis;
    public bool YAxis;
    public bool ZAxis;

    public bool StartAnimation { get; set; }

    private RectTransform rectTransform;
    private Transform ownTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        ownTransform = GetComponent<Transform>();

        if (MoveAllAxis == false && XAxis == false && YAxis == false && ZAxis == false)
        {
            MoveAllAxis = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartAnimation)
            return;

        if (ownTransform != null)
        {
            if (XAxis)
            {
                nextPosition = new Vector3(nextPosition.x, transform.position.y, transform.position.z);
            }
            else if (YAxis)
            {
                nextPosition = new Vector3(transform.position.x, nextPosition.y, transform.position.z);
            }
            else if (ZAxis)
            {
                nextPosition = new Vector3(transform.position.x, transform.position.y, nextPosition.z);
            }

            ownTransform.position = Vector3.Lerp(ownTransform.position, nextPosition, AnimationSpeed * Time.deltaTime);
        }

        if (rectTransform != null)
        {
            if (XAxis)
            {
                nextPosition = new Vector3(nextPosition.y, rectTransform.localPosition.x);
            }
            else if (YAxis)
            {
                nextPosition = new Vector3(rectTransform.localPosition.x, nextPosition.y);
            }

            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, nextPosition, AnimationSpeed * Time.deltaTime);
        }
    }

        private void OnValidate()
    {
        if (SetNativePosition)
        {
            nextPosition = transform.position;
            SetNativePosition = false;
        }

        if (MoveAllAxis)
        {
            XAxis = false;
            YAxis = false;
            ZAxis = false;
        }
        else if (XAxis)
        {
            MoveAllAxis = false;
            YAxis = false;
            ZAxis = false;
        }
        else if (YAxis)
        {
            MoveAllAxis = false;
            XAxis = false;
            ZAxis = false;
        }
        else if (ZAxis)
        {
            MoveAllAxis = false;
            YAxis = false;
            XAxis = false;
        }
    }
}