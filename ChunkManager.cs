using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public PlayManager playManager;
    public Transform chunkDestroy;

    public void Start()
    {
        playManager = GameObject.Find("GameManager").GetComponent<PlayManager>();
        chunkDestroy = GameObject.Find("ChunkDestroy").transform;
    }

    void Update()
    {
        if (playManager.GameIsOn)
        {
            if(transform.position.x <= chunkDestroy.transform.position.x)
            {
                Destroy(gameObject);
            }
        }
        if (!playManager.GameIsOn)
        {
            StartCoroutine(WaitTillDestroy());
        }
    }

    IEnumerator WaitTillDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
