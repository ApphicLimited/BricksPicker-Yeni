using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("MANAGERS")]
    public PlayerManager PlayerManager;
    public ObstacleManager ObstacleManager;
    public StackManager StackManager;
    public AudioManager AudioManager;
    public PanelManager PanelManager;
    [Header("CONTROLLERS")]
    public TouchController TouchController;
    public SuperPowerController SuperPowerController;
    public CongratWordsController CongratWordsController;
    public ColourController ColourController;
    public ScoreController ScoreController;
    public CoinController CoinController;
    public TimeController TimeController;
    public SmoothFollow SmothFollow;
    public GameStates GameState;
    public Material MetreDetecterMaterial;
    public GameObject NextButton, RestartButton;

    private bool isGameStarted;
    public bool isBonusLevel;
    public bool IsGameStarted
    {
        get { return IsGameStarted; }
        set
        {
            isGameStarted = value;
            if (isGameStarted)
                OnGameStarted?.Invoke();
        }
    }
    private bool isGameDone { get; set; }
    public bool IsGameDone
    {
        get
        { return isGameDone; }
        set
        {
            isGameDone = value;
            if (IsGameDone)
                OnGameDone?.Invoke();
        }
    }

    public event Action OnGameStarted;
    public event Action OnGameDone;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
            Destroy(this);

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        IsGameStarted = false;
    }

    public void NextLevel()
    {
        GameStarter.instance.LoadNextLevel();
    }
    public void RestartLevel()
    {
        GameStarter.instance.RestartLevel();
    }

    public Text ScoreText, CoinText, LevelCompleteText;
    public GameObject endPanel;
    public GameObject a, aa ,aaa;
    public void GameOver()
    {
        a.SetActive(false);
        aa.SetActive(false);
        aaa.SetActive(false);

        NextButton.SetActive(true);
        CoinText.text = CoinController.CollectedCoins.ToString();
        LevelCompleteText.text = "LEVEL " + (GameStarter.instance.currentLevel + 1) + " COMPLETE";
        
        endPanel.SetActive(true);
    }
}