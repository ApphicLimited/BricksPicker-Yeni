using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KickPowerBar : MonoBehaviour
{
    public Image HandGesture;
    public Image FillAmount;
    public TMP_Text Text;

    public Move AnimationHandGestureMove;
    public Move AnimationTextMove;
    public FadeOut AnimationHandGestureFadeOut;
    public FadeOut AnimationTextFadeOut;

    void Start()
    {
        FillAmount.fillAmount = 0.3f;

        StartCoroutine(StarAnimations(2));
    }

    void Update()
    {
        if (GameManager.instance.GameState == GameStates.GameFinished)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FillAmount.fillAmount += 0.1f;
        }

        FillAmount.fillAmount -= Time.deltaTime * 0.1f;

        GameManager.instance.StackManager.StackThrowingForce = 50 * FillAmount.fillAmount;
        GameManager.instance.PlayerManager.Player.ForwardSpeed = Mathf.Clamp(20 * FillAmount.fillAmount, 15, 20);
        GameManager.instance.PlayerManager.Player.AnimatorSpeed = Mathf.Clamp(FillAmount.fillAmount, 0.3f, 1);
    }

    private IEnumerator StarAnimations(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        AnimationHandGestureMove.StartAnimation = true;
        AnimationTextMove.StartAnimation = true;
        AnimationHandGestureFadeOut.StartAnimation = true;
        AnimationTextFadeOut.StartAnimation = true;
    }
}