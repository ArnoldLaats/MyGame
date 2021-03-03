using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public PlayManager playManager;

    public GameObject[] chunks;

    public Transform player;

    public Transform whenToGen;
    public Transform whereToGen;

    public Vector3 whenToGenStart;
    public Vector3 whereToGenStart;

    public float chunkDistance;

    public GameObject parent;

    private void Start()
    {
        whenToGenStart = whenToGen.transform.position;
        whereToGenStart = whereToGen.transform.position;
    }

    private void Update()
    {
        if (playManager.GameIsOn)
        {
            if (player.transform.position.x >= whenToGen.transform.position.x)
            {
                whenToGen.transform.position = new Vector3(whenToGen.transform.position.x + chunkDistance, 0, 0);
                GenerateChunk();
                whereToGen.transform.position = new Vector3(whereToGen.transform.position.x + chunkDistance, 0, 0);
            }
        }
    }
    public void GenerateChunk()
    {
        int chunkInt = Random.Range(0, chunks.Length);

        Instantiate(chunks[chunkInt], new Vector3(whereToGen.transform.position.x, 0,0), Quaternion.identity);
    }
}
