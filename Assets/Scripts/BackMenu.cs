using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenu : ButtonHover
{
    private void OnMouseUp()
    {
        OnMouseExit();
        MainMenu.mainButton.SetActive(true);
        MainMenu.selectLevel.SetActive(false);
    }

}
