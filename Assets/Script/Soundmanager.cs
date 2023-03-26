using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager instance;

    public AudioClip uiButton;
    public AudioClip balbounce;
    public AudioClip goal;
    public AudioClip gameover;

    private AudioSource audio;

    private void Awake()
    {
        if (instance != null)

            Destroy(gameObject);
        else
            instance = this;

        audio = GetComponent<AudioSource>();
    }

    public void UIClickSfx()
    {
        audio.PlayOneShot(uiButton);
    }

    public void BallBounceSfx()
    {
        audio.PlayOneShot(balbounce);
    }

    public void GoalSfx()
    {
        audio.PlayOneShot(goal);
    }

    public void GameOverSfx()
    {
        audio.PlayOneShot(gameover);
    }

}
