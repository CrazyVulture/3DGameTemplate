using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    public AudioClip bgmMusic;
    public AudioClip winSound;

    private bool isWin=false;

    void Start()
    {
        GameInit();
    }

    void Update()
    {
        //Win Event
        if (isWin)
        {
            WinAction();
            isWin = false;
        }
            
    }

    //Game Init
    private void GameInit()
    {
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    //Win
    public void Win()
    {
        isWin = true;
    }
    private void WinAction()
    {
        SoundMgr.Instance.PlayMusic(winSound);
    }
}
