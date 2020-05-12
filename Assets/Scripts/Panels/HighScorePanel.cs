using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
    public UIMove AnimationUIMove;

    public Text TextScore;
    public Text TextCoin;

    public void AppearUp()
    {
        TextScore.text = "YOU SCORED "+ GameManager.instance.ScoreController.CurrentCollectedStackNumber.ToString();
        TextCoin.text = GameManager.instance.ScoreController.CurrentCollectedStackNumber.ToString();
        AnimationUIMove.StartAnimation();
        StartCoroutine(DissAppear(5f));
    }

    private IEnumerator DissAppear(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        AnimationUIMove.StartReversAnimation();
    }
}