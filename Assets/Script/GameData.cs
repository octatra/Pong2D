using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameData : MonoBehaviour
{
    public static GameData instace;


    [Header("Game Setting")]
    public int player1Score;
    public int player2Score;
    public float timer;
    public GameObject BallSet;
    public bool isOver;
    public bool goldenGoal;
    public bool isSpawnPowerUp;
    public GameObject ballSpawned;


    [Header("Prefab")]
    public GameObject BallPrefab;
    public GameObject[] powerUp;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject GameOverPanel;



    [Header("InGame UI")]
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI player1ScoreTxt;
    public TextMeshProUGUI player2ScoreTxt;
    public GameObject goldenGoalUI;

    [Header("Game Over UI")]
    public GameObject player1WinUI;
    public GameObject player2WinUI;
    public GameObject youWin;
    public GameObject youLose;


    private void Awake()
    {
        if(instace != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instace = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);

        player1WinUI.SetActive(false);
        player2WinUI.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);

        goldenGoalUI.SetActive(false);

        timer = GameData2.instace.gameTimer;
        BallSet = GameData2.instace.BallPrefabSet;
        isOver = false;
        goldenGoal = false;

        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreTxt.text = player1Score.ToString();
        player2ScoreTxt.text = player2Score.ToString();

        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            timeTxt.text = string.Format("{0:00}:{1:00}", minutes,seconds);

            if (seconds % 20 == 0 && !isSpawnPowerUp)
            {
                StartCoroutine("SpawnPowerUp");
            }

        }

        if(timer <= 0f && !isOver)
        {
            timeTxt.text = "00:00";
            if (player1Score == player2Score)
            {
                if (!goldenGoal)
                {
                    goldenGoal = true;
//                    Ball[] ball = FindObjectOfType<Ball>();
//                    for(int i = 0; i < ball.Length; i++)
//                    {
  //                      Destroy(ball[i].gameObject);
    //                }
                    goldenGoalUI.SetActive(true);
        //            SpawnBall();
                }
            }
            else
            {
                GameOver();
            }
        }
    }

    public IEnumerator SpawnPowerUp()
    {
        isSpawnPowerUp = true;
        int rand = Random.Range(0, powerUp.Length);
        Instantiate(powerUp[rand], new Vector3(Random.Range(-3.2f, 3.2f), Random.Range(-2.35f, 2.35f), 0), Quaternion.identity);
        yield return new WaitForSeconds(1);
        isSpawnPowerUp = false;

    }


    public void pauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        Soundmanager.instance.UIClickSfx();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
        Soundmanager.instance.UIClickSfx();

    }
    public void RestarGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Game");
        Soundmanager.instance.UIClickSfx();
    }

    public void SpawnBall()
    {
        StartCoroutine("Delayspawn");
    }

    public void GameOver()
    {
        Soundmanager.instance.UIClickSfx();
        isOver = true;
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        if (!GameData2.instace.isSinglePlayer)
        {
            if(player1Score > player2Score)
            {
                player1WinUI.SetActive(true);
            }
            if(player1Score< player2Score)
            {
                player2WinUI.SetActive(true);
            }
        }
        else
        {
            if (player1Score > player2Score)
            {
                youWin.SetActive(true);
            }
            if (player1Score < player2Score)
            {
                youLose.SetActive(true);
            }
        }
        
    }

    public IEnumerator Delayspawn()
    {
        yield return new WaitForSeconds(3);
        if(ballSpawned == null)
        {
            Instantiate(BallSet, Vector3.zero, Quaternion.identity);
        }

    }


}
