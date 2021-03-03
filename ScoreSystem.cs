using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public PlayManager playManager;
    public MainMenuManager menuManager;
    [Space]
    public float score;
    public Text scoreText;
    public Text highScoreText;
    void Start()
    {
        //highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("F0");
        scoreText.text = "";
    }

    void Update()
    {
        if (playManager.GameIsOn)
        {
            score += 50 * Time.deltaTime * (playManager.gameSpeed * 1.2f);

            scoreText.text = score.ToString("F0");

            if (score > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", score);
                highScoreText.text = "High Score: " + score.ToString("F0");
            }
        } else
        {
            menuManager.scoreText.text = "Score: " + score.ToString("F0");
        }
    }
}
