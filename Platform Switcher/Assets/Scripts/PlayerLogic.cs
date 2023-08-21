using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private bool canJump = false;
    private bool hasSwitched = false;

    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var touch = Input.GetTouch(index:0);

        if (Input.touchCount > 0)
        {
            Debug.Log("The screen got touched ");
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartPos = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                swipeEndPos = touch.position;
                Debug.Log("The screen got released");
                if(swipeStartPos.y < swipeEndPos.y)
                {
                    hasSwitched = true;
                }

                else if(swipeStartPos.y > swipeEndPos.y)
                {
                    hasSwitched = false;
                }
            }        
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasSwitched)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            }

            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }

            hasSwitched =! hasSwitched;
        }

        if(transform.position.y < -10)
        {
            hasSwitched = false;
            transform.position = new Vector3(-15, 1.5f, 0);
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

        var initX = -15;

        for(var i = 0; i < 5; i++)
        {
            var currentPlayerX = (80 * (i + 1)) - 15;

            CheckFinish(other.gameObject, $"Finish{i + 1}", currentPlayerX, 1.5f);
        }

        if(other.gameObject.tag == "obstacle")
        {
            MovePlayer(-13, 1.5f);
        }

        if(other.gameObject.tag == "Tramp")
        {
            GetComponent<Rigidbody>().AddForce(0, 750, 0);
        }

    }

    private void MovePlayer(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        hasSwitched = false;
    }

    private void CheckFinish(GameObject finishObject, string finishName, float x, float y)
    {
        if (finishObject.name == finishName)
        {
            MovePlayer(x, y);
        }
    }

}
