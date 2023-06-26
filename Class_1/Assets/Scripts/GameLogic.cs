using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject Collectable;
    public GameObject BadCollectable;

    private float randomXCollectable = 0f;
    private float randomYCollectable = 0f;

    private float randomXBadCollectable = 0f;
    private float randomYBadCollectable = 0f;

    private float collectableSpawnTime = 1f;
    private float badCollectableSpawnTime = 1f;

    private float maxX = 17.5f;
    private float maxY = 9f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCollectables());
        StartCoroutine(SpawnBadCollectables());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCollectables()
    {
        while(true)
        {
            SpawnCollectable();
            yield return new WaitForSeconds(collectableSpawnTime);
        }
    }

    IEnumerator SpawnBadCollectables()
    {
        while(true)
        {
            SpawnBadCollectable();
            yield return new WaitForSeconds(badCollectableSpawnTime);
        }
    }

    void SpawnCollectable()
    {
        randomXCollectable = Random.Range(-maxX, maxX);
        randomYCollectable = Random.Range(-maxY, maxY);

        Instantiate(Collectable, new Vector2(randomXCollectable, randomYCollectable), Quaternion.identity);
    } 

    void SpawnBadCollectable()
    {
        randomXBadCollectable = Random.Range(-maxX, maxX);
        randomYBadCollectable = Random.Range(-maxY, maxY);

        Instantiate(BadCollectable, new Vector2(randomXBadCollectable, randomYBadCollectable), Quaternion.identity);
    } 

}
