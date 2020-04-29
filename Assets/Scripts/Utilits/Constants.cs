using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Constants 
{
    public const string TAG_STACK = "Stack";
    public const string TAG_COIN = "Coin";
    public const string TAG_PLAYER = "Player";

    public const string EFFECT_VOLUME_AMOUNT_KEY = "effectvolume";
    public const string MUSIC_VOLUME_AMOUNT_KEY = "musicvolume";
    public const string EFFECT_VOLUME_TOOGLE_KEY = "effecttoggle"; 
    public const string MUSIC_VOLUME_TOOGLE_KEY = "musictoggle";
    public const string BEST_SCORE_KEY = "bestscore";
}

[Serializable]
public enum GameStates
{
    GameOver = 0,
    GamePaused = 1,
    GameOnGoing = 2,
    GameFinished = 3,

    MAX = 4
}

[Serializable]
public enum TouchSides
{
    Left=0,
    Right=1,

    MAX = 2
}

[Serializable]
public enum CongratWords
{
    Great = 0,
    Awesome = 1,
    Nice = 2,
    WellDone = 3,

    MAX = 4
}

[Serializable]
public enum BaseColour
{
    Blue = 0,
    Green = 1,
    Orange = 2,
    Red = 3,
    Yellow = 4,
    Pink = 5,
    Purple = 6,
    Brown = 7,
    Black = 8,
    White = 9,

    MAX = 10
}

[Serializable]
public enum ClipStyle
{
    Effect = 0,
    Music = 1,

    MAX = 2
}