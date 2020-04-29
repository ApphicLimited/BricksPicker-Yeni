using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CongratWordPrefab : MonoBehaviour
{
    public TMP_Text TextWord;

    public FadeOut AnimationFadeOut;
    public Move AnimationMove;

    private void Start()
    {
        PickWordRandomly();
    }

    private void PickWordRandomly()
    {
        int maxNumber = (int)CongratWords.MAX;
        CongratWords myEnum = (CongratWords)Random.Range(0, maxNumber);
        TextWord.text = myEnum.ToString();
    }

    public void StartAnimation()
    {
        AnimationFadeOut.StartAnimation = true;
        AnimationMove.StartAnimation = true;
    }

    public void StartAnimation(float delay)
    {
        StartCoroutine(StartAnimationByDelay(delay));
    }

    private IEnumerator StartAnimationByDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartAnimation();
    }
}