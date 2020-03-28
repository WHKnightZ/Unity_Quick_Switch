using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private SpriteRenderer renderGoal;
    private Sprite goalOn;
    private int maxStar;
    private int countStar;
    private bool canWin, isWin;

    private AudioSource audioSource;
    private AudioClip soundStar;
    private AudioClip soundGoal;

    public float delayStart;
    private bool isPlaying;

    private TextMeshPro txtStar;

    private void Start()
    {
        renderGoal = GameObject.Find("Goal").GetComponent<SpriteRenderer>();
        goalOn = Resources.Load<Sprite>("Sprites/Goal_On");
        countStar = 0;
        maxStar = GameObject.FindGameObjectsWithTag("Star").Length;
        canWin = false;
        isWin = false;
        audioSource = GetComponent<AudioSource>();
        soundStar = Resources.Load<AudioClip>("Sounds/Star");
        soundGoal = Resources.Load<AudioClip>("Sounds/Goal");
        BarController.Reload(SceneManager.GetActiveScene().name, maxStar);
        txtStar = BarController.txtStar;
        if (BoardController.board.activeInHierarchy)
            delayStart = 2f;
        else
            delayStart = 0.5f;
        isPlaying = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (transform.position.y < -4.5f)
            {
                if (isWin)
                {
                    GameObject[] arr = GameObject.FindGameObjectsWithTag("Wall");
                    foreach (GameObject obj in arr)
                    {
                        obj.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    BoardController.instance.ShowStart();
                }  
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Destroy(gameObject);
            }
        }
        else
        {
            delayStart -= Time.deltaTime;
            if (delayStart < 0f)
            {
                isPlaying = true;
                GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            countStar++;
            txtStar.text = "Stars " + (maxStar - countStar);
            audioSource.PlayOneShot(soundStar);
            if (countStar == maxStar)
            {
                canWin = true;
            }
        }
        else if (collision.gameObject.tag == "Goal")
        {
            if (canWin)
            {
                isWin = true;
                audioSource.PlayOneShot(soundGoal);
                renderGoal.sprite = goalOn;
            }
        }
    }
}
