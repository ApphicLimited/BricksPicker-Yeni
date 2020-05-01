using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class StackManager : MonoBehaviour
{
    public List<Stack> Stacks = new List<Stack>();
    public List<ColourChanger> ColourChangers = new List<ColourChanger>();
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
        float fromZpos = GameManager.instance.PlayerManager.Player.transform.position.z;
        float tillZpos = 0;
        float minDistanceZpos = 100000;

        ColourChangers.Where(e => e.IsPassedBy == false).ToList().ForEach((ColourChanger changer) =>
         {
             if (Mathf.Abs(changer.transform.position.z-fromZpos)< minDistanceZpos)
             {
                 minDistanceZpos = Mathf.Abs(changer.transform.position.z - fromZpos);
                 tillZpos = changer.transform.position.z;
             }
         });

        foreach (var item in Stacks)
        {
            if (item.IsOnCollecter==false && item.transform.position.z<tillZpos && item.transform.position.z>fromZpos)
            {
                item.ChangeColour(GameManager.instance.PlayerManager.CurrentColour);
            }
            else if (item.IsOnCollecter==true)
            {
                item.ChangeColour(GameManager.instance.PlayerManager.CurrentColour);
            }
        }
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