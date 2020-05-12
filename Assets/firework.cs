using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firework : MonoBehaviour
{
    public GameObject prefab;
    public float period;
    public float lasttime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lasttime + period)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            lasttime = Time.time;
        }
    }
}
