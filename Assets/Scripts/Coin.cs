using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0));
    }

    public void DisAppear()
    {
        SpawnParticleEffect();
        Destroy(gameObject);
    }

    private void SpawnParticleEffect()
    {
        GameObject go = Instantiate(ParticleSystem.gameObject);
        go.transform.position = gameObject.transform.position;
    }
}