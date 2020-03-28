using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static GameObject selectLevel;
    public static GameObject mainButton;

    private static List<string> scenesInBuild = new List<string>();

    private static bool isInit = false;

    private GameObject balls;
    private GameObject ballMenu;

    private float delaySpawnBall = 0f;

    void Start()
    {
        if (!isInit)
        {
            isInit = true;
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                int lastSlash = scenePath.LastIndexOf("/");
                scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
            }
        }

        GameObject obj = Resources.Load<GameObject>("Prefabs/Level");
        mainButton = GameObject.Find("MainButton");
        selectLevel = GameObject.Find("SelectLevel");
        mainButton.SetActive(true);
        selectLevel.SetActive(false);
        BoardController.board.SetActive(false);
        BarController.bar.SetActive(false);
        GameObject btn;
        int level = 1;
        string str;
        int x, y;
        while (true)
        {
            str = "Level" + level;
            if (scenesInBuild.Contains(str))
            {
                x = (level - 1) % 6;
                y = (level - 1) / 6;
                btn = Instantiate(obj, selectLevel.transform);
                btn.transform.Translate(new Vector3(x * 1.0f, -y * 0.94f, 0f));
                btn.name = str;
                btn.transform.GetChild(0).GetComponent<TextMeshPro>().text = level.ToString();
            }
            else break;
            level++;
        }
        balls = GameObject.Find("Balls");
        ballMenu = Resources.Load<GameObject>("Prefabs/BallMenu");
    }

    void Update()
    {
        delaySpawnBall -= Time.deltaTime;
        if (delaySpawnBall < 0f)
        {
            delaySpawnBall += 2f;
            Instantiate(ballMenu, balls.transform);
        }
    }

}
