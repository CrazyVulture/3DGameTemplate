using UnityEngine;
using UnityEngine.UI;

public enum TextType
{
    RESTART=0,
    LOSE
}

public class UIMgr : Singleton<UIMgr>
{
    public Text scoreText;

    public GameObject restartText;
    public GameObject loseText;

    [HideInInspector]
    public int score = 0;

    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
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