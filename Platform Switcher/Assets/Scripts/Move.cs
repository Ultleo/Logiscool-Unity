using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Delta = 2f;
    public float Speed = 2f;

    private Vector3 startpos;

    private void Start() 
    {
        startpos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        var v = startpos;
        v.x += Delta * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }
}
