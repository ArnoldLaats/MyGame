using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorChanger : MonoBehaviour
{
    //public GameDataManager gameDatamanager;
    public SpriteRenderer player;

    public Image colorDisplay;

    public Color color;
    public Slider red;
    public Slider green;
    public Slider blue;
    public void OnEdit()
    {
        color = player.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        colorDisplay.color = color;
    }
    public void UpdatePlayer()
    {
        player.color = color;
    }
    
}
