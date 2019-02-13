using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    public bool isStart { get; private set; }
    bool isWin;
    bool isRestart;
    bool isQuit;
    bool isLose;

    public GameController gameController;

    public AudioClip bgmMusic;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Start()
    {
        isStart = isWin = isRestart = isLose = isQuit = false;
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    void Update()
    {
        if (isStart)
        {
            gameController.StartGame();
            isStart = false;
        }
        //Win Event
        if (isWin)
        {
            SoundMgr.Instance.PlayMusic(winSound);
            gameController.EndGame(true);
            isWin = false;
        }
        //Lose
        if (isLose)
        {
            SoundMgr.Instance.PlayMusic(loseSound);
            gameController.EndGame(false);
            isLose = false;
        }
        //Restart
        if (isRestart)
        {
            gameController.RestartGame();
            isRestart = false;
        }
        //Quit
        if (isQuit)
        {
            gameController.QuitGame();
            isQuit = false;
        }

    }

    //Start
    public void StartGame()
    {
        isStart = true;
    }

    //Win
    public void WinGame()
    {
        isWin = true;
    }

    //Lose
    public void LoseGame()
    {
        isLose = true;
    }

    //Restart
    public void RestartGame()
    {
        isRestart = true;
    }

    //Quit
    public void QuitGame()
    {
        isQuit = true;
    }

}
