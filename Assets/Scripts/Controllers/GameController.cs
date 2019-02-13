using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GAMETYPE
    {
        COLLECT = 0,
        FLYSHOOT
    };

    public GAMETYPE gameType;

    public void StartGame()
    {
        switch (gameType)
        {
            case GAMETYPE.COLLECT:
                break;
            case GAMETYPE.FLYSHOOT:
                break;
        }
    }

    public void EndGame(bool isWin)
    {
        if (isWin)
        {

        }
        else
        {

        }
        switch (gameType)
        {
            case GAMETYPE.COLLECT:
                break;
            case GAMETYPE.FLYSHOOT:
                break;
        }
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
