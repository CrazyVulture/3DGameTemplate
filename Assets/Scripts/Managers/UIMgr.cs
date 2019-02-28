using UnityEngine;
using UnityEngine.UI;

public enum TextType
{
    RESTART=0,
    LOSE
}

public class UIMgr : Singleton<UIMgr>
{
    public int winScore;
    //Texts
    public GameObject restartText;
    public GameObject loseText;
    public Text scoreText;
    int score = 0;

    //Health
    public Slider healthSlider;

    //Score part
    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        UpdateScore();
        if (score>=winScore)
            EventMgr.Instance.WinGame();
    }
    public int GetScore()
    {
        return score;
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    
    //Health part
    public int TakeHealth(int currentHealth,int deltaHealth)
    {
        currentHealth -= deltaHealth;
        healthSlider.value = currentHealth;
        return currentHealth;
    }

    public void ShowText(TextType textType)
    {
        switch (textType)
        {
            case TextType.RESTART:
                restartText.SetActive(true);
                break;
            case TextType.LOSE:
                loseText.SetActive(true);
                break;
        }
    }

}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}