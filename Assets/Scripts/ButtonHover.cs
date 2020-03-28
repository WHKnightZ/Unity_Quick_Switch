using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{

    private static Vector3 scaleHover = new Vector3(1.1f, 1.1f, 1f);
    private static Vector3 scaleNormal = new Vector3(1f, 1f, 1f);

    protected void OnMouseEnter()
    {
        transform.localScale = scaleHover;
    }

    protected void OnMouseExit()
    {
        transform.localScale = scaleNormal;
    }

}
