using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player;
    public Material MaterialSource;
    public Transform EndTransform;
    public Transform StartTransform;
    public Transform[] TrackPathTransforms;

    public BaseColour CurrentColour;
    private int currentTrackPathTransformsIndex;

    private void Start()
    {
        Player.SetUpMaterial();
        ChangePlayerColour(Player.BaseColour, false);

        GameManager.instance.OnGameStarted += OnGameStarted;
    }

    public void ChangePlayerColour(BaseColour colour, bool playParticle)
    {
        CurrentColour = colour;
        if (!GameManager.instance.isBonusLevel)
        {
            Player.ChangeColour(colour, playParticle); 
        }
    }

    public void MoveToSide(TouchSides side)
    {
        if (side == TouchSides.Left)
        {
            if (--currentTrackPathTransformsIndex < 0)
                currentTrackPathTransformsIndex = 0;
        }
        else if (side == TouchSides.Right)
        {
            if (++currentTrackPathTransformsIndex > TrackPathTransforms.Length - 1)
                currentTrackPathTransformsIndex = TrackPathTransforms.Length - 1;
        }

        Player.MoveToSide(TrackPathTransforms[currentTrackPathTransformsIndex].position);
    }

    #region Events

    private void OnGameStarted()
    {
        currentTrackPathTransformsIndex = 1;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameStarted -= OnGameStarted;
    }
    #endregion
}