using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReturn : ButtonHover
{
    private void OnMouseDown()
    {
        OnMouseExit();
        SceneManager.LoadScene("MainMenu");
    }
}
