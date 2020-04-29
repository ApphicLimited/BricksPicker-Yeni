using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public Text TextLevel;
    public Image ImageLevelBar;

    private float dff;

    // Start is called before the first frame update
    void Start()
    {
        dff = Mathf.Abs(GameManager.instance.PlayerManager.StartTransform.position.z - GameManager.instance.PlayerManager.EndTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameState != GameStates.GameOnGoing)
            return;

        ImageLevelBar.fillAmount = 1 - (Mathf.Abs(GameManager.instance.PlayerManager.Player.transform.position.z - GameManager.instance.PlayerManager.EndTransform.position.z) * (1f / dff));
    }
}
