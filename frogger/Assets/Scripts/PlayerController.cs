using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // DONT FORGET THIS ONE

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 20f)
        {
            SceneManager.LoadScene("SampleScene");            
        }
    }

    private void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "platform")
        {
            GetComponent<CharacterController>().Move(hit.transform.forward * (PlatformController.moveSpeed / 4f) * Time.deltaTime);
        }

        if (hit.gameObject.tag == "car")
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (hit.gameObject.name == "Finish")
        {
            hit.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}