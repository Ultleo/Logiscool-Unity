using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = $"Score: {Score}";
    }
}
