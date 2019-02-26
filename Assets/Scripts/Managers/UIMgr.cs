using UnityEngine;
using UnityEngine.UI;

public enum TextType
{
    RESTART=0,
    LOSE
}

public class UIMgr : Singleton<UIMgr>
{
    //Texts
    public GameObject restartText;
    public GameObject loseText;
    public Text scoreText;
    [HideInInspector]
    public int score = 0;

    //Health
    public Slider healthSlider;

    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

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