using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // public Clips[] Audioclips;

    // private List<SourceInfo> sources = new List<SourceInfo>();
    public AudioSource Audio_SmallBricks;
    public AudioSource Audio_BigBricks;
    public AudioSource Audio_ColorFlow;
    public AudioSource Audio_Redlight;

    //private void Awake()
    //{
    //    //SetVolumeFirstTime();

    //    //CreateSources();

    //    //SetToogleVolume();
    //    //SetVolume();
    //}

    //private void Update()
    //{
    //    // foreach (var source in sources)
    //    //{
    //    // if ("CollectBrick".ToLower() == source.Source.gameObject.name.ToLower())
    //    //  {
    //    //  source.Source.Play();
    //    // }
    //    // }
    //}

    //private void CreateSources()
    //{
    //    for (int i = 0; i < Audioclips.Length; i++)
    //    {
    //        GameObject source = new GameObject(Audioclips[i].ClipName, typeof(AudioSource));
    //        source.GetComponent<AudioSource>().clip = Audioclips[i].AudioClip;
    //        source.GetComponent<AudioSource>().playOnAwake = false;
    //        source.GetComponent<AudioSource>().loop = Audioclips[i].Loop;
    //        sources.Add(new SourceInfo(source.GetComponent<AudioSource>(), Audioclips[i].ClipStyle));
    //    }
    //}

    public void PlayClip(string audioClipName)
    {
        if (audioClipName == "CollectGoThroughColorFlow")
        {
            Audio_ColorFlow.Play();
        }
        else if (audioClipName == "CollectBigBrick")
        {
            Audio_BigBricks.Play();
        }
        else if (audioClipName == "CollectBrick")
        {
            Audio_SmallBricks.Play();
        }
        else if(audioClipName == "Audio_Redlight")
        {
            Audio_Redlight.Play();
        }
    }

    //public void SetVolume()
    //{
    //    for (int i = 0; i < sources.Count; i++)
    //    {
    //        if (sources[i].ClipStyle == ClipStyle.Effect)
    //        {
    //            if (sources[i].Source != null)
    //            {
    //                sources[i].Source.volume = PlayerPrefs.GetFloat(Constants.EFFECT_VOLUME_AMOUNT_KEY);
    //            }
    //        }
    //        else
    //        {
    //            if (sources[i].Source != null)
    //            {
    //                sources[i].Source.volume = PlayerPrefs.GetFloat(Constants.MUSIC_VOLUME_AMOUNT_KEY);
    //            }
    //        }        
    //    }
    //}

    //public void SetToogleVolume()
    //{
    //    int effectVolumeToggle = PlayerPrefs.GetInt(Constants.EFFECT_VOLUME_TOOGLE_KEY);
    //    int musicVolumeToggle = PlayerPrefs.GetInt(Constants.MUSIC_VOLUME_TOOGLE_KEY);

    //    for (int i = 0; i < sources.Count; i++)
    //    {
    //        if (sources[i].ClipStyle == ClipStyle.Effect)
    //        {
    //            if (sources[i].Source != null)
    //                sources[i].Source.mute = (effectVolumeToggle == 1) ? false : true;
    //        }
    //        else
    //        {
    //            if (sources[i].Source != null)
    //                sources[i].Source.mute = (musicVolumeToggle == 1) ? false : true;
    //        }
    //    }
    //}

    //public void PauseClip(string clipName)
    //{
    //    if (clipName == "")
    //        return;

    //    foreach (var source in sources)
    //    {
    //        if (clipName.ToLower() == source.Source.clip.name.ToLower())
    //            source.Source.Pause();
    //    }
    //}

    //public void StopClip(string clipName)
    //{
    //    if (clipName == "")
    //        return;

    //    foreach (var source in sources)
    //    {
    //        if (clipName.ToLower() == source.Source.clip.name.ToLower())
    //            source.Source.Stop();
    //    }
    //}

    //public bool IsSoundToogleOn()
    //{
    //    return PlayerPrefs.GetInt(Constants.EFFECT_VOLUME_TOOGLE_KEY) == 1 ? true : false;
    //}

    //public bool IsMusicToogleOn()
    //{
    //    return PlayerPrefs.GetInt(Constants.MUSIC_VOLUME_TOOGLE_KEY) == 1 ? true : false;
    //}

    //public float GetSoundSliderAmount()
    //{
    //    return PlayerPrefs.GetFloat(Constants.EFFECT_VOLUME_AMOUNT_KEY);
    //}

    //public float GetMusicSliderAmount()
    //{
    //    return PlayerPrefs.GetFloat(Constants.MUSIC_VOLUME_AMOUNT_KEY);
    //}

    //private void SetVolumeFirstTime()
    //{
    //    if (!PlayerPrefs.HasKey(Constants.EFFECT_VOLUME_TOOGLE_KEY))
    //        PlayerPrefs.SetInt(Constants.EFFECT_VOLUME_TOOGLE_KEY, 1);

    //    if (!PlayerPrefs.HasKey(Constants.MUSIC_VOLUME_TOOGLE_KEY))
    //        PlayerPrefs.SetInt(Constants.MUSIC_VOLUME_TOOGLE_KEY, 1);

    //    if (!PlayerPrefs.HasKey(Constants.EFFECT_VOLUME_AMOUNT_KEY))
    //        PlayerPrefs.SetFloat(Constants.EFFECT_VOLUME_AMOUNT_KEY, 0.5f);

    //    if (!PlayerPrefs.HasKey(Constants.MUSIC_VOLUME_AMOUNT_KEY))
    //        PlayerPrefs.SetFloat(Constants.MUSIC_VOLUME_AMOUNT_KEY, 0.5f);
    //}
}

//[System.Serializable]
//public class Clips
//{
//    public string ClipName;
//    public AudioClip AudioClip;
//    public ClipStyle ClipStyle;
//    public bool Loop;
//}

//public class SourceInfo
//{
//    public SourceInfo(AudioSource audioSource, ClipStyle ClipStyle)
//    {
//        this.Source = audioSource;
//        this.ClipStyle = ClipStyle;
//    }

//    public AudioSource Source;
//    public ClipStyle ClipStyle;
//}