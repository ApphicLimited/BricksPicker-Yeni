using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private TouchPhase touchPhase;
    private Touch currentTouch;
    private Vector2 touchPos;

    public float TouchSenseDistance;
    private Vector2 initialPos;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameState!=GameStates.GameOnGoing)
            return;

        TouchDetect();

        #region KEYBOARD DETECTION

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.instance.PlayerManager.MoveToSide(TouchSides.Left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.instance.PlayerManager.MoveToSide(TouchSides.Right);
        }

        #endregion
    }

    private void TouchDetect()
    {
        if (Input.GetMouseButtonDown(0))
            initialPos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
            Calculate(Input.mousePosition);
    }

    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x - finalPos.x);
        float disY = Mathf.Abs(initialPos.y - finalPos.y);
        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (initialPos.x > finalPos.x)
                    GameManager.instance.PlayerManager.MoveToSide(TouchSides.Left);
                else
                    GameManager.instance.PlayerManager.MoveToSide(TouchSides.Right);
            }
        }
    }
}