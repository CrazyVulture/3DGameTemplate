using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{
    public AudioClip bgmMusic;
    public AudioClip winSound;
    public AudioClip loseSound;
    public GameObject sceneManager;

    protected virtual void KeyboardControll()
    {
        if (Input.GetKeyDown(KeyCode.R) && PlayerController.GetPlayerStatus()==PlayerStatus.DEAD)
            EventMgr.Instance.RestartGame();
        if (Input.GetKeyDown(KeyCode.Escape))
            EventMgr.Instance.QuitGame();
    }

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
            UIMgr.Instance.ShowText(TextType.LOSE);
            SoundMgr.Instance.PlayMusic(loseSound);
        }
    }

    public abstract void PlayerDead();

    public void RestartGame()
    {
        Destroy(sceneManager);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
