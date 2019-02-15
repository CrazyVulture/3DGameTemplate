using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    public bool isStart { get; private set; }
    bool isWin,isRestart,isQuit,isLose,isDead;

    public GameController gameController;

    

    void Start()
    {
        isStart = true;
        /*isStart =*/ isWin = isRestart = isLose = isQuit = isDead=false;
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
            gameController.EndGame(true);
            isWin = false;
        }
        if (isDead)
        {
            gameController.PlayerDead();
            isDead = false;
        }
        //Lose
        if (isLose)
        {
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
    //Dead
    public void PlayerDead()
    {
        isDead = true;
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
