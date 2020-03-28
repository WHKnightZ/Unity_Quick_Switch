using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : ButtonHover
{
    private void OnMouseDown()
    {
        OnMouseExit();
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level < SceneManager.sceneCountInBuildSettings)
        {
            transform.parent.GetComponent<BoardController>().ShowEnd();
            SceneManager.LoadScene(level);
        }
        else
            SceneManager.LoadScene("MainMenu");
    }

}
