using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elastic : MonoBehaviour
{
    public Transform Target;
    public float AnimationSpeed;

    private Vector3 nextPos;

    private void Start()
    {
        nextPos = transform.position;
    }

    private void Update()
    {
        nextPos.z = Target.position.z;
        nextPos.x = Target.position.x;
        nextPos.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, nextPos, Time.deltaTime * AnimationSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, Target.position.z);
    }
}
