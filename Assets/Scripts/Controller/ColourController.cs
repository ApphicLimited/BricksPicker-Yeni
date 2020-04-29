using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour
{
    public List<BaseColoursMatch> BaseColours = new List<BaseColoursMatch>();  

    public Color GetColour(BaseColour baseColour)
    {
        foreach (var item in BaseColours)
            if (item.BaseColour.ToString() == baseColour.ToString())
                return item.Colour;

        return Color.black;
    }

    [System.Serializable]
    public struct BaseColoursMatch
    {
        public BaseColour BaseColour;
        public Color Colour;
    }
}
