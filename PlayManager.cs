using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public GameDataManager gameDatamanager;
    public MainMenuManager menuManager;
    public PlayerMovement playerMovement;
    public PlayerManager playerManager;
    public ScoreSystem scoreSystem;
    [Space]
    [Space]
    public float gameSpeed;
    public int scoreToSpeed;
    [Space]
    public int collectedCoins;
    [Space]
    [Space]
    public bool GameIsOn;
    [Space]
    public Button jumpButton;
    public Text jumpText;
    [Space]
    public Button gravityButton;
    public Text gravityText;

    public Color transparentColor;

    public void Start()
    {
        GameIsOn = false;
    }

    public void Update()
    {
        if (GameIsOn)
        {
            if(scoreSystem.score >= scoreToSpeed)
            {
                gameSpeed += 0.05f;
                scoreToSpeed += 1000;
                playerMovement.UpdateSpeed();
                StartCoroutine(HideScoreText());
            }
        }
    }
    public void StartGame()
    {
        if (!GameIsOn)
        {
            gameSpeed = 1;
            playerMovement.speed = 8;
            collectedCoins = 0;
        }
        GameIsOn = true;
        HideButtons();
    }

    public void PickedUpCoin()
    {
        Debug.Log("Added Collected Coin");
        collectedCoins++;
    }

    public void HideButtons()
    {
        jumpButton.image.color = transparentColor;
        jumpText.enabled = false;

        gravityButton.image.color = transparentColor;
        gravityText.enabled = false;
    }

    IEnumerator HideScoreText()
    {
        menuManager.scoreText.enabled = false;
        menuManager.speedUpText.gameObject.SetActive(true);
        menuManager.speedUpText.enabled = true;
        yield return new WaitForSeconds(1.5f);
        menuManager.scoreText.enabled = true;
        menuManager.speedUpText.gameObject.SetActive(false);
        menuManager.speedUpText.enabled = false;
    }
}
