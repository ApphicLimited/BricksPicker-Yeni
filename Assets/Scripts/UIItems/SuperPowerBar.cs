using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPowerBar : MonoBehaviour
{
    public Image Image;

    void Start()
    {
        Image.fillAmount = 0f;
    }
 
    void Update()
    {
        if (GameManager.instance.GameState != GameStates.GameOnGoing)
            return;

        if (GameManager.instance.SuperPowerController.IsPowerFull)
        {
            Image.color = Color.yellow;
            Image.fillAmount = (1 / GameManager.instance.SuperPowerController.MaxSuperPowerUsageSecond) *(GameManager.instance.SuperPowerController.MaxSuperPowerUsageSecond- GameManager.instance.SuperPowerController.timer);
        }
        else
        {
            Image.color = Color.green;
            Image.fillAmount = (1 / GameManager.instance.SuperPowerController.MaxSuperPower) * GameManager.instance.SuperPowerController.CurrentPower;
        }
    }
}