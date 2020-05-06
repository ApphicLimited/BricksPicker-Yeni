using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private float furtherStackMetre;
    public float FurtherStackMetre
    {
        get { return furtherStackMetre; }
        set
        {
            if (value > furtherStackMetre)
                furtherStackMetre = value;
        }
    }

    private int currentCollectedStackNumber;
    public int CurrentCollectedStackNumber
    {
        get { return currentCollectedStackNumber; }
        set {
            currentCollectedStackNumber = value;
            GameManager.instance.CongratWordsController.CongratPlayer(value);
            GameManager.instance.StackManager.TextStackCount.text = value.ToString();
            GameManager.instance.ScoreText.text = value.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnGameStarted += OnGameStarted;
        GameManager.instance.OnGameDone += OnGameDone;
    }

    private void CheckBestScore()
    {
        if (PlayerPrefs.HasKey(Constants.BEST_SCORE_KEY))
        {
            if (CurrentCollectedStackNumber > PlayerPrefs.GetInt(Constants.BEST_SCORE_KEY))
            {
                PlayerPrefs.SetInt(Constants.BEST_SCORE_KEY, CurrentCollectedStackNumber);
                GameManager.instance.PanelManager.HighScorePanel.AppearUp();
            }
        }
    }

    #region Events

    private void OnGameStarted()
    {
        CurrentCollectedStackNumber = 0;
        FurtherStackMetre = 0;
    }

    private void OnGameDone()
    {
        CheckBestScore();
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStarted -= OnGameStarted;
    }

    #endregion
}