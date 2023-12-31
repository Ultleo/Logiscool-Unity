using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private bool _canJump = false;
    private int _layerIndex = 0;
    private Vector2 _swipeStartPosition;
    private Vector2 _swipeEndPosition;
    public int LayerCount = 2;
    public int StageCount = 3;
    public Joystick Joystick;

    public GameObject coinText;
    public GameObject stageText;
    public GameObject LiveText;
    public GameObject FinishText;

    private int stage = 1;
    private int coinCount = 0;
    private bool game = true;
    public int HeartAmount = 3;

    void Update()
    {
        DesktopControl();
        MobileControl();

        if (transform.position.y < -10)
        {
            ChangePlayerLayer(0);
            transform.position = new Vector3(-15, 1.5f, 0);
            stage = 1;
        }

        if (game)
        {
            stageText.GetComponent<Text>().text = $"Stage: {stage}";
            coinText.GetComponent<Text>().text = $"Coins: {coinCount}";
            LiveText.GetComponent<Text>().text = GetCurrentHeartAmount(HeartAmount);
        }

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision other)
    {
        _canJump = true;

        for (var i = 0; i < 5; i++)
        {
            var currentPlayerX = (80 * (i + 1)) - 15;
            CheckFinish(other.gameObject, i + 1, currentPlayerX, 1.5f);
        }

        if (other.gameObject.tag == "obstacle")
        {
            MovePlayer(-13, 1.5f);
            stage = 1;
            HeartAmount--;
        }

        if (other.gameObject.tag == "tramp")
        {
            GetComponent<Rigidbody>().AddForce(0, 750, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            coinCount++;
        }
    }

    private void DesktopControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            ChangePlayerLayer(_layerIndex - 1, true);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && _canJump)
        {
            _canJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
    }

    private void Movement()
    {
    var rb = GetComponent<Rigidbody>();
    if (Input.GetKey(KeyCode.A) || Joystick.Horizontal < -0.5f)
    {
    rb.velocity = new Vector3(-MoveForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }

    if (Input.GetKey(KeyCode.D) || Joystick.Horizontal > 0.5f)
    {
    rb.velocity = new Vector3(MoveForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }
    }

    private void MobileControl()
    {
    var requiredTouch = Joystick.Horizontal != 0 || Joystick.Vertical != 0 ? 1 : 0;

    if (Input.touchCount == requiredTouch + 1)
    {
    Debug.Log($"Required touch: {requiredTouch}");

    var touch = Input.GetTouch(requiredTouch);
    if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2f)
    {
    Debug.Log("The screen got touched");
    _swipeStartPosition = touch.position;
    }

    if (touch.phase == TouchPhase.Ended)
    {
    Debug.Log("The screen got released.");
    _swipeEndPosition = touch.position;
    if (_swipeStartPosition.y < _swipeEndPosition.y && touch.position.x > Screen.width / 2f)
    {
    ChangePlayerLayer(_layerIndex + 1);
    } 
    else if (_swipeStartPosition.y > _swipeEndPosition.y)
    {
    ChangePlayerLayer(_layerIndex - 1);
    }
    }
    }

    if (Joystick.Vertical > 0.5f && _canJump)
    {
    _canJump = false;
    GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
    }
    }

    private void ChangePlayerLayer(int newLayerIndex, bool allowOverFlow = false)
    {
    _layerIndex = newLayerIndex;
    if (allowOverFlow)
    {
    if (_layerIndex > LayerCount - 1)
    {
    _layerIndex = 0;
    }
    if (_layerIndex < 0)
    {
    _layerIndex = LayerCount - 1;
    }
    }
    else
    {
    if (_layerIndex > LayerCount - 1)
    {
    _layerIndex = LayerCount - 1;
    }
    if (_layerIndex < 0)
    {
    _layerIndex = 0;
    } 
    }

    transform.position = new Vector3(
    transform.position.x,
    transform.position.y,
    _layerIndex * 10
    );
    }

    private void MovePlayer(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        ChangePlayerLayer(0);
    }

    private void CheckFinish(GameObject finishObject, int currentStage, float x, float y)
    {
        if (finishObject.name == $"Finish{currentStage}")
        {
            if (currentStage == StageCount)
                {
                    FinishText.GetComponent<Text>().text = $"Well Done!!\nYou collected {coinCount} Coins";
                    Time.timeScale = 0;
                    FinishText.SetActive(true);
                    return;
                }
            MovePlayer(x, y);
            stage++;
        }
    }

    private string GetCurrentHeartAmount(int amount)
    {
        var lives = "";
        
        for (var i = 0; i < amount; i++)
        {
            lives += "❤";
        }

        return lives;
    }
}