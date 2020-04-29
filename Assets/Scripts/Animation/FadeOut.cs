using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public TMP_Text TextPoint;
    public float AnimationSpeed;
    public bool StartAnimation;

    private Vector4 nextColour;
    private Image Image;

    // Start is called before the first frame update
    void Start()
    {
        if (TextPoint!=null)
        {
            nextColour = new Vector4(TextPoint.color.r, TextPoint.color.g, TextPoint.color.b, 0);
        }
        else
        {
            Image = GetComponent<Image>();
            nextColour = new Vector4(Image.color.r, Image.color.g, Image.color.b, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartAnimation)
            return;

        if (TextPoint!=null)
        {
            TextPoint.color = Vector4.Lerp(TextPoint.color, nextColour, AnimationSpeed * Time.deltaTime);
            if (Vector4.Distance(TextPoint.color, nextColour) < 0.01f)
                Destroy(gameObject);
        }
        else
        {
            Image.color = Vector4.Lerp(Image.color, nextColour, AnimationSpeed * Time.deltaTime);
            if (Vector4.Distance(Image.color, nextColour) < 0.01f)
                Destroy(gameObject);
        }
    }
}