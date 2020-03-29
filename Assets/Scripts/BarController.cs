using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public static GameObject bar = null;
    public static TextMeshPro txtLevel;
    public static TextMeshPro txtStar;

    void Awake()
    {
        if (bar != null)
        {
            Destroy(gameObject);
        }
        else
        {
            bar = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
            txtLevel = GameObject.Find("TxtLevel").GetComponent<TextMeshPro>();
            txtStar = GameObject.Find("TxtStar").GetComponent<TextMeshPro>();
        }
    }

    public static void Reload(int level, int star)
    {
        bar.SetActive(true);
        txtLevel.text = "Level " + level;
        txtStar.text = "Stars " + star;
    }

}
