using UnityEngine;
using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public Text scoreText;

    [HideInInspector]
    public int score = 0;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        scoreText.text = "Score: " + score;
    }

}
