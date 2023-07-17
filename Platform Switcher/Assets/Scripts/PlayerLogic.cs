using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
    }

    private void FixedUpdate() 
    {
        var rb = GetComponent<Rigidbody>();
        
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-MoveForce * Time.deltaTime, rb.velocity.y, rb. velocity.z);
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(MoveForce * Time.deltaTime, rb.velocity.y, rb. velocity.z);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        canJump = true;
    }

}
