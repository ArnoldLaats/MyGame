using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public bool audioIsOn;
    public Image audioImage;

    public Sprite audioOnImage;
    public Sprite audioOffImage;
    [Space]
    public AudioSource gameSong;
    [Space]
    public AudioSource jumpAudio;
    public AudioSource gravityAudio;
    public AudioSource switchAudio;
    public AudioSource menuInteract;
    public AudioSource accessDeny;
    public AudioSource gameOver;

    public void AudioSwitch()
    {
        if (!audioIsOn)
        {
            audioIsOn = true;
            audioImage.sprite = audioOnImage;
            gameSong.Play();
            switchAudio.Play();
        } else
        {
            audioIsOn = false;
            audioImage.sprite = audioOffImage;
            gameSong.Stop();
        }
    }
}
