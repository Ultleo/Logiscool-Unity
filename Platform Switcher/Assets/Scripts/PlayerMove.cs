using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Delta = 2f;
    public float Speed = 2f;
    public float RotationSpeed = 2f;

    private Vector3 startpos;

    private void Start() 
    {
        startpos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotationSpeed, 0);
        var v = startpos;
        v.x += Delta * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }
}
