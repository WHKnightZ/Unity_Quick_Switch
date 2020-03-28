using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2Collision : MonoBehaviour
{
    private static bool isInit = false;
    private static Sprite wallOff;
    private static Sprite wallOn;

    private BoxCollider2D boxCollider;
    private SpriteRenderer render;

    void Start()
    {
        if (!isInit)
        {
            isInit = true;
            wallOff = Resources.Load<Sprite>("Sprites/Wall2_Off");
            wallOn = Resources.Load<Sprite>("Sprites/Wall2_On");
        }
        boxCollider = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        boxCollider.isTrigger = false;
        render.sprite = wallOn;
    }

    private void OnMouseExit()
    {
        boxCollider.isTrigger = true;
        render.sprite = wallOff;
    }

}
