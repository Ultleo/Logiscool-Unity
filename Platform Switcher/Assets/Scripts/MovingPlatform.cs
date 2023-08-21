using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Delta = 2f;
    public float Speed = 2f;

    private Vector3 vector;

    // Update is called once per frame
    void Update()
    {
        vector.x = Delta * Mathf.Sin(Time.time * Speed);
        GetComponent<Rigidbody>().velocity = vector;
    }
}
