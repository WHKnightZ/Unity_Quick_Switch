using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMenu : MonoBehaviour
{
    void Start()
    {
        float radius = Random.Range(0.5f, 0.8f);
        transform.localScale = new Vector3(radius, radius, 1f);
        transform.Translate(new Vector3(Random.Range(-0.8f, 0.8f), 0f, 0f));
    }

    void Update()
    {
        if (transform.position.y < -3.2f)
            Destroy(gameObject);
    }
}
