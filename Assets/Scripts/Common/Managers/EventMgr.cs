
public class EventMgr : Singleton<EventMgr>
{
    public bool isStart { get; private set; }
    bool isWin,isRestart,isQuit,isLose, isDead;

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
        if (isLose)
        {
            gameController.EndGame(false);
            isLose = false;
        }
        if (isRestart)
        {
            gameController.RestartGame();
            isRestart = false;
        }
        if (isQuit)
        {
            gameController.QuitGame();
            isQuit = false;
        }
    }

    public void StartGame()
    {
        isStart = true;
    }
    public void WinGame()
    {
        isWin = true;
    }
    public void PlayerDead()
    {
        isDead = true;
    }
    public void LoseGame()
    {
        isLose = true;
    }
    public void RestartGame()
    {
        isRestart = true;
    }
    public void QuitGame()
    {
        isQuit = true;
    }

}
