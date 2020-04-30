using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float MinDistance;
    public Move AnimationMove;

    void Update()
    {
        if (GameManager.instance.GameState != GameStates.GameOnGoing)
            return;

        if (AnimationMove.StartAnimation == false)
            if (Vector3.Distance(transform.position, GameManager.instance.PlayerManager.Player.transform.position) < MinDistance)
                AnimationMove.StartAnimation = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("StackCollecter"))
        {
            GameManager.instance.GameState = GameStates.GameOver;
            FindObjectOfType<StackCollector>().ResetJointSettings();
            FindObjectOfType<Player>().Animator.enabled = false;
            GameStarter.instance.Fail();
        }
    }
}