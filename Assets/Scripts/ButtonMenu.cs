using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : ButtonHover
{

    private void OnMouseUp()
    {
        switch (gameObject.name)
        {
            case "BtnPlay":
                OnMouseExit();
                MainMenu.mainButton.SetActive(false);
                MainMenu.selectLevel.SetActive(true);
                break;
            case "BtnQuit":
                Application.Quit();
                break;
            default:
                break;
        }
    }

}
