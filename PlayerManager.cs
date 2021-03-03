using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameDataManager gameDataManager;
    public PlayManager playManager;
    public PlayerMovement playerMovement;
    public ScoreSystem scoreSystem;
    public CoinSystem coinSystem;
    public SoundManager soundManager;
    public MainMenuManager menuManager;

    public GameObject playerSprite;
    public SpriteRenderer playerSpriteRen;

    public GameObject gameName;
    public GameObject volumeButton;
    public GameObject playButton;
    public GameObject customizeButton;
    public GameObject scoreDisplay;
    public Text scoreText;
    public GameObject highscoreDisplay;

    public Vector3 scoreOffset;
    public Vector3 highScoreOffset;
    public GameObject restartButton;

    public bool hasUpdatedCoins = false;

    public void GameIsOver()
    {
        //gameManager.SavePlayer();

        if (!hasUpdatedCoins)
        {
            hasUpdatedCoins = true;
            coinSystem.UpdateCoins();
        }

        playerSprite.SetActive(false);
        playManager.GameIsOn = false;
        playManager.jumpButton.enabled = false;
        playManager.gravityButton.enabled = false;
        scoreSystem.scoreText.enabled = false;

        menuManager.MainMenu.SetActive(true);
        volumeButton.gameObject.SetActive(false);
        gameName.SetActive(false);
        customizeButton.SetActive(false);
        playButton.SetActive(false);
        scoreDisplay.SetActive(true);
        scoreText.text = "Score: " + scoreSystem.score.ToString("F0");
        restartButton.SetActive(true);
    }

    public void ResetPlayer()
    {
        playerMovement.speed = 0;
        playerMovement.rb.gravityScale = 1;

        playerMovement.rb.velocity = new Vector2(playerMovement.speed, playerMovement.rb.velocity.y);
        playerSprite.SetActive(true);
        playerMovement.transform.position = new Vector3(-5, -4, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            GameIsOver();
        }
    }
}
