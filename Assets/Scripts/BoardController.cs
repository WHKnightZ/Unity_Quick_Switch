using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static BoardController instance = null;
    public static GameObject board = null;

    private float v, a;
    private int state;
    private Vector3 start = new Vector3(-6.4f, -0.2f, 10f);
    private Vector3 center = new Vector3(0f, -0.2f, 10f);

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            board = gameObject;
        }
    }

    void Update()
    {
        if (state == 0)
        {
            gameObject.transform.Translate(Vector3.right * v * Time.deltaTime);
            v += a * Time.deltaTime;
            if (gameObject.transform.position.x > 0f)
            {
                state = 1;
                gameObject.transform.position = center;
            }
        }
        else if (state == 2)
        {
            gameObject.transform.Translate(Vector3.right * v * Time.deltaTime);
            v += a * Time.deltaTime;
            if (gameObject.transform.position.x > 6.4f)
            {
                state = 3;
                board.SetActive(false);
            }
        }
    }

    public void ShowStart()
    {
        v = 20f;
        a = -30f;
        state = 0;
        gameObject.transform.position = start;
        gameObject.SetActive(true);
    }

    public void ShowEnd()
    {
        v = 0f;
        a = 30f;
        state = 2;
    }
}
