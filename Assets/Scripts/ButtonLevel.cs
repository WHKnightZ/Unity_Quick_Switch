using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    private static Vector3 scaleHover = new Vector3(1f, 1f, 1f);
    private static Vector3 scaleNormal = new Vector3(0.9f, 0.9f, 0.9f);

    private void OnMouseEnter()
    {
        transform.localScale = scaleHover;
    }

    private void OnMouseExit()
    {
        transform.localScale = scaleNormal;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(gameObject.name);
    }

}
