using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerController : MonoBehaviour
{
    public float MaxSuperPower;
    public float MaxSuperPowerUsageSecond;
    public Transform ParentCanvas;
    public StackPoint PlusStuckPoint;
    public StackPoint MinusStackPoint;
    public Animation RedlightPanel;
    public KickPowerBar KickPowerBar;
    public AudioManager RedlightAudio;

    public float CurrentPower { get; set; }
    public bool IsPowerFull { get; set; }
    public float timer { get; set; }

    public static event Action<bool> OnSuperPowerActivated;

    private void Start()
    {
        GameManager.instance.OnGameStarted += OnGameStarted;
    }

    private void Update()
    {
        if (GameManager.instance.GameState!=GameStates.GameOnGoing)
            return;

        if (IsPowerFull)
        {
            timer += Time.deltaTime;
            if (timer > MaxSuperPowerUsageSecond)
            {
                timer = 0;
                IsPowerFull = false;
                OnSuperPowerActivated?.Invoke(false);
            }
        }

        if (GameManager.instance.SmothFollow.CameraMovement.IsApproachedToEndPoint)
            KickPowerBar.gameObject.SetActive(true);Debug.Log("1111");

    }

    public void AddPower(float stackPoint)
    {
        if (IsPowerFull)
            return;

        CurrentPower += stackPoint;

        if (CurrentPower > MaxSuperPower)
        {
            CurrentPower = 0;
            IsPowerFull = true;
            OnSuperPowerActivated?.Invoke(true);
        }

        SpawnPlus(GameManager.instance.PlayerManager.Player.StackCollector.transform.position);
    }

    public void SubPower(float stackPoint)
    {
        if (IsPowerFull)
            return;

        CurrentPower -= stackPoint;

        if (CurrentPower < 0)
            CurrentPower = 0;

        SpawnMinus(GameManager.instance.PlayerManager.Player.StackCollector.transform.position);

        if (RedlightPanel.isPlaying)
        {
            RedlightPanel.Stop();
        }
        RedlightPanel.Play("FadeInFadeOut");
        RedlightAudio.PlayClip("Audio_Redlight");
    }

    private void SpawnPlus(Vector3 pos)
    {
        GameObject go = Instantiate(PlusStuckPoint.gameObject, ParentCanvas);
        go.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint (pos);
        go.GetComponent<StackPoint>().StartAnimation();
    }

    private void SpawnMinus (Vector3 pos)
    {
        GameObject go = Instantiate(MinusStackPoint.gameObject, ParentCanvas);
        go.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(pos);
        go.GetComponent<StackPoint>().StartAnimation();
    }

    #region Events

    private void OnGameStarted()
    {
        timer = 0;
        IsPowerFull = false;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStarted -= OnGameStarted;
    }
    #endregion
}
