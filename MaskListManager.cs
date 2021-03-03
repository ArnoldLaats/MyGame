using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskListManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public CoinSystem coinSystem;
    public PlayerColorChanger playerColorChanger;
    [Space]
    public Sprite[] maskList;
    [Space]
    public int listInt;
    public int maxInt;

    public Image chosenMask;
    public Sprite curDisplay;

    public Color noTransparency;

    public void Start()
    {
        curDisplay = maskList[0];
        UpdateDisplay();
        maxInt = maskList.Length;
    }
    public void NextMask()
    {
        if (listInt < maskList.Length - 1) {
            listInt++;
            curDisplay = maskList[listInt];
            UpdateDisplay();
            playerColorChanger.OnEdit();
            CheckAvailability();
        }
    }
    public void PreviousMask()
    {
        if (listInt > 0)
        {
            listInt--;
            curDisplay = maskList[listInt];
            UpdateDisplay();
            playerColorChanger.OnEdit();
            CheckAvailability();
        }
    }
    public void UpdateDisplay()
    {
        chosenMask.sprite = curDisplay;
        chosenMask.color = noTransparency;
    }
    public void UpdatePlayer()
    {
        playerManager.playerSpriteRen.sprite = chosenMask.sprite;
    }

    public void CheckAvailability()
    {

    }
}
