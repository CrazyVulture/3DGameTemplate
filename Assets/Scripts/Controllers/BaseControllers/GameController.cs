﻿using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{
    public AudioClip bgmMusic;
    public AudioClip winSound;
    public AudioClip loseSound;

    public virtual void StartGame()
    {
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    public virtual void EndGame(bool isWin)
    {
        if (isWin)
        {
            SoundMgr.Instance.PlayMusic(winSound);
        }
        else
        {
            SoundMgr.Instance.PlayMusic(loseSound);
        }
        
    }

    public virtual void PlayerDead()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(GameObject.FindGameObjectWithTag("Manager"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}