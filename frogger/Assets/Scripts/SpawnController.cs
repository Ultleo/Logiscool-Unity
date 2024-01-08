using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject platform;
    public GameObject car_1;
    public GameObject car_2;

    private Vector3 spawn_1 = new Vector3(51.5f, 23, 0);
    private Vector3 land_1 = new Vector3(72, 25, 18
    );
    private Vector3 land_2 = new Vector3(77f, 25, 80);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawning()
    {
        while(true) 
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            if(Random.Range(0, 2) == 1)
            {
                Instantiate(platform, spawn_1, Quaternion.identity);
            }

            if(Random.Range(0, 2) == 1)
            {
                Instantiate(car_1, land_1, Quaternion.identity);
            }

            if(Random.Range(0, 2) == 1)
            {
                Instantiate(car_2, land_2, Quaternion.Euler(0, 180f, 0));
            }
        }
    }
}