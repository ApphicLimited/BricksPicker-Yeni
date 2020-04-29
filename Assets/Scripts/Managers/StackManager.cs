using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StackManager : MonoBehaviour
{
    public List<Stack> Stacks = new List<Stack>();
    public Material MaterialSource;
    public TMP_Text TextStackCount;

    public GameObject Stack;

    public float MaxStackWaveStrength;
    public float MinStackWaveStrength;
    public float PerStackWaveReductionAmount;

    public float StackThrowingForce;

    private void Start()
    {
        SuperPowerController.OnSuperPowerActivated += OnSuperPowerActivated;
        GameManager.instance.OnGameStarted += OnGameStarted;
    }

    public void ChangeColour()
    {
        foreach (var item in Stacks)
            item.ChangeColour(GameManager.instance.PlayerManager.CurrentColour);
    }

    public void ResetColour()
    {
        foreach (var item in Stacks)
            item.ResetColour();
    }

    #region Events

    private void OnSuperPowerActivated(bool IsActivated)
    {
        if (IsActivated)
            ChangeColour();
        else
            ResetColour();
    }

    private void OnGameStarted()
    {
  
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStarted -= OnGameStarted;
        SuperPowerController.OnSuperPowerActivated -= OnSuperPowerActivated;
    }

    #endregion
}