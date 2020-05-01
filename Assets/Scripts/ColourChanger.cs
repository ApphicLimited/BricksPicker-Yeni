using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public BaseColour MainColour;
    public MeshRenderer MyBase, Aura;
    public ParticleSystem Particles;

    public bool IsPassedBy;

    private void Start()
    {
        MyBase.material.color = GameManager.instance.ColourController.BaseColours[(int)MainColour].Colour;
        Aura.material.color = GameManager.instance.ColourController.BaseColours[(int)MainColour].Colour;
        Particles.startColor = GameManager.instance.ColourController.BaseColours[(int)MainColour].Colour;
        IsPassedBy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_PLAYER)
        {
            GameManager.instance.AudioManager.PlayClip("CollectGoThroughColorFlow");
            GameManager.instance.PlayerManager.ChangePlayerColour(MainColour, true);
            IsPassedBy = true;
        }
    }
}
