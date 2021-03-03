using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayManager playManager;
    public SoundManager soundManager;

    public SpriteRenderer coinSprite;
    public AudioSource pickupSound;

    private bool isCollected;

    public void Start()
    {
        playManager = GameObject.Find("GameManager").GetComponent<PlayManager>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
    }

    public void CoinCollected()
    {
        if (!isCollected) {
            Debug.Log("Collected Coin");
            isCollected = true;
            coinSprite.enabled = false;
            playManager.PickedUpCoin();
                if (soundManager.audioIsOn)
                {
                    pickupSound.Play();
                }
            StartCoroutine(DestroyCoin());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CoinCollected();
        }
    }

    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
