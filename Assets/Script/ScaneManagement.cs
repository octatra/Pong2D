using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScaneManagement : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject HTPpanel;
    public GameObject TimerPanel;
    public GameObject SetBall;


    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        HTPpanel.SetActive(false);
        TimerPanel.SetActive(false);
        SetBall.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayerButton()
    {
        GameData2.instace.isSinglePlayer = true;
        TimerPanel.SetActive(true);
        MainPanel.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }
    public void MultiPlayerButton()
    {
        GameData2.instace.isSinglePlayer = false;
        TimerPanel.SetActive(true);
        MainPanel.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }

    public void BackButton()
    {
        HTPpanel.SetActive(false);
        TimerPanel.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        GameData2.instace.gameTimer = Timer;
        SetBall.SetActive(true);
        TimerPanel.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }

    public void SetBallPlay(GameObject Ball)
    {
        GameData2.instace.BallPrefabSet = Ball;
        HTPpanel.SetActive(true);
        SetBall.SetActive(false);
        Soundmanager.instance.UIClickSfx();
    }


    public void StartBtn()
    {
        SceneManager.LoadScene("Main_Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
