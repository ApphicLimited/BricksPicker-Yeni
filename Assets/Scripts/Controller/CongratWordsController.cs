using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratWordsController : MonoBehaviour
{
    public CongratWordPrefab CongratWordPrefab;
    public Vector3 SpawnPosition;
    public Transform ParentCanvas;
    // Start is called before the first frame update

    public void CongratPlayer(int collectedStackNumber)
    {
        if (collectedStackNumber % 20 == 0)
        {
            GameObject go = Instantiate(CongratWordPrefab.gameObject, ParentCanvas);
            go.GetComponent<RectTransform>().localPosition = SpawnPosition;
            go.GetComponent<CongratWordPrefab>().StartAnimation(0.5f);
        }
    }
}