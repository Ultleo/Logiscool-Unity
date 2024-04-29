using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    public CoinRotate Coin;

    private Queue<CoinRotate> items = new Queue<CoinRotate>();

    public static ObjectPools Instance {get; set;}


    private void Awake()
    {
        Instance = this;
    }

    public CoinRotate Get()
    {
        if (items.Count == 0)
        {
            var obstacle = Instantiate(Coin);
            obstacle.gameObject.SetActive(false);
            items.Enqueue(obstacle);
        }

        return items.Dequeue();
    }

    public void ReturnToPool(CoinRotate obj)
    {
        obj.gameObject.SetActive(false);
        items.Enqueue(obj);
    }
}
