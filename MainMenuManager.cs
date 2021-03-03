using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameDataManager gameDatamanager;
    public PlayerManager playerManager;
    public LevelGenerator levelGenerator;
    public PlayerMovement playerMovement;
    public ScoreSystem scoreSystem;
    public SoundManager soundManager;
    public PlayerColorChanger playerColorChanger;

    [Header("Main Menu To Hide")]
    public GameObject MainMenu;
    public GameObject gameName;
    public GameObject volumeButton;
    public GameObject playButton;
    public GameObject customizeButton;
    public GameObject highScoreDisplay;
    public GameObject scoreDisplay;
    public GameObject continueButton;
    public Text scoreText;
    public Text speedUpText;
    [Header("Game Menu To Show")]
    public GameObject GameMenu;
    [Header("Customize Menu To Show")]

    public GameObject customizeMenu;
    public GameObject cusReqMenuBG;
    public Button cusButton;
    public int cusMenuReq;
    public Text cusMenuReqText;
    public GameObject coinDisplay;
    public Vector2 coinDisStartPos;
    public Vector2 coinDisCusMenuPos;
    [Space]
    public GameObject playMenu;

    public Button jumpButton;
    public Text jumpText;
    public Button gravityButton;
    public Text gravityText;

    public Color reduceTransparentColor;

    public void Start()
    {
        GameMenu.SetActive(false);
        coinDisStartPos = coinDisplay.transform.localPosition;
        cusReqMenuBG.SetActive(false);
        cusMenuReqText.text = "To Unlock, Collect " + cusMenuReq.ToString() + " Coins";
        cusMenuReqText.enabled = false;
        speedUpText.enabled = false;
        speedUpText.text = "Speed Up";
    }

    public void PlayButton()
    {
        playerManager.hasUpdatedCoins = false;

        MainMenu.SetActive(false);
        GameMenu.SetActive(true);
        playMenu.SetActive(true);

        if (soundManager.audioIsOn)
        {
            soundManager.menuInteract.Play();
            soundManager.gameSong.volume = 0.2f;
        }

        levelGenerator.whenToGen.transform.position = levelGenerator.whenToGenStart;
        levelGenerator.whereToGen.transform.position = levelGenerator.whereToGenStart;

        playerMovement.curJumps = playerMovement.maxJumps;

        jumpButton.enabled = true;
        jumpButton.image.color = reduceTransparentColor;
        jumpText.enabled = true;

        gravityButton.enabled = true;
        gravityButton.image.color = reduceTransparentColor;
        gravityText.enabled = true;

        scoreText.enabled = true;
    }
    public void CustomizeButton()
    {
        if(PlayerPrefs.GetInt("Coins",0) < cusMenuReq)
        {
            cusReqMenuBG.SetActive(true);
            cusMenuReqText.enabled = true;
            if (soundManager.audioIsOn)
            {
                soundManager.menuInteract.Play();
            }
            StartCoroutine(HideCusReqText());
        }

        if (PlayerPrefs.GetInt("Coins", 0) > cusMenuReq)
        {
            gameName.SetActive(false);
            volumeButton.SetActive(false);
            playButton.SetActive(false);
            highScoreDisplay.SetActive(false);
            customizeMenu.SetActive(true);
            customizeButton.SetActive(false);

            coinDisplay.transform.localPosition = coinDisCusMenuPos;
            if (soundManager.audioIsOn)
            {
                soundManager.menuInteract.Play();
            }
        }
    }
    public void CusBackButton()
    {
        gameName.SetActive(true);
        playButton.SetActive(true);
        volumeButton.SetActive(true);
        highScoreDisplay.SetActive(true);
        customizeButton.SetActive(true);
        customizeMenu.SetActive(false);
        coinDisplay.transform.localPosition = coinDisStartPos;
        if (soundManager.audioIsOn)
        {
            soundManager.menuInteract.Play();
        }
        //gamemanager.SavePlayer();
    }
    public void RestartButton()
    {
        MainMenu.SetActive(true);
        gameName.SetActive(true);
        volumeButton.SetActive(true);
        playButton.SetActive(true);
        customizeButton.SetActive(true);
        highScoreDisplay.SetActive(true);
        scoreDisplay.SetActive(false);
        continueButton.SetActive(false);
        playMenu.SetActive(false);

        if (soundManager.audioIsOn)
        {
            soundManager.menuInteract.Play();
            StartCoroutine(RefreshGameSongVolume());
        }

        playerMovement.top = false;
        playerMovement.transform.eulerAngles = new Vector3(0, 0, 0);
        scoreSystem.score = 0;

        playerManager.ResetPlayer();
    }

    IEnumerator RefreshGameSongVolume()
    {
        soundManager.gameSong.volume = 0.05f;
        yield return new WaitForSeconds(1);
        soundManager.gameSong.volume = 0.8f;
    }

    IEnumerator HideCusReqText()
    {
        yield return new WaitForSeconds(2);
        cusReqMenuBG.SetActive(false);
        cusMenuReqText.enabled = false;
    }
}
