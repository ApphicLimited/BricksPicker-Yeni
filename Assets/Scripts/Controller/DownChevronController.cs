using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DownChevronController : MonoBehaviour
{
    public GameObject DownChevronPrefab;
    public int AmountOfDownChevron;
    public float AnimationRepSecond;
    public Color LightOnColour;
    public Color LightOFFColour;
    [Space]
    public Transform FirstSpawnPoint;
    public float ZAxisSpace;
    [Tooltip("If this is not checked on that means those will be spawn to backwards")]
    public bool KeepSpawnForward;

    private int currentIndex;
    private List<MeshRenderer> DownChevrons = new List<MeshRenderer>();
    private List<Material> CloneMaterials = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = FirstSpawnPoint.position;

        for (int i = 0; i < AmountOfDownChevron; i++)
        {
            GameObject go = Instantiate(DownChevronPrefab);
            go.transform.position = pos;
            if (KeepSpawnForward)
                pos.z += ZAxisSpace;
            else
                pos.z -= ZAxisSpace;

            DownChevrons.Add(go.GetComponent<MeshRenderer>());
            CloneMaterials.Add(go.GetComponent<MeshRenderer>().material);
            DownChevrons.Last().material = CloneMaterials.Last();
        }

        CloneMaterials.Reverse();

        InvokeRepeating("InvokeLightUp", 1, AnimationRepSecond);
    }

    private void InvokeLightUp()
    {
        if (++currentIndex>DownChevrons.Count-1)
            currentIndex = 0;

        for (int i = 0; i < CloneMaterials.Count; i++)
        {
            CloneMaterials[i].color = LightOFFColour;
        }

        CloneMaterials[currentIndex].color = LightOnColour;

    }
}
