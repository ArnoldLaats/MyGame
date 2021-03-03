using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public Transform[] spawnPos;

    public void Start()
    {
        
        int chance = Random.Range(0, 2);
        if(chance == 1)
        {
            int pos = Random.Range(0, spawnPos.Length);
            Debug.Log("Spawn Coin");

            GameObject spawnedCoin = Instantiate(coin, spawnPos[pos]);
        }
    }
}
