using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColourMat : MonoBehaviour
{
    public GameObject[] children;

    // Start is called before the first frame update
    void Start()
    {
        var colors = new List<Color> {Color.red, Color.green, Color.cyan, Color.blue};

        if (transform.name.Equals("Player"))
        {
            var random = colors[Random.Range(0, colors.Count)];
            GetComponent<Renderer>().material.color = random;
        }

        if (!transform.childCount.Equals(0))
        {
            foreach (var item in children)
            {
                var random = colors[Random.Range(0, colors.Count)];
                item.GetComponent<Renderer>().material.color = random;
                colors.Remove(random);
            }
        }
    }
}
