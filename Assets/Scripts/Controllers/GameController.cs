using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{

    public virtual void StartGame()
    {
        
    }

    public virtual void EndGame(bool isWin)
    {
        if (isWin)
        {

        }
        else
        {

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
