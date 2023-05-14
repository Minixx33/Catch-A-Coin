using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CoinGameController : MonoBehaviour
{
    public float maxPos;
    public int targetScore;
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public PiggyBankPlayerController player;
    public Text text;
    
    private void Start()
    {
        InvokeRepeating("SpawnCoin", 2, 2); //spawn the coins every 2 seconds
        InvokeRepeating("SpawnBomb", 5, 5); //spawn the bombs every 5 seconds

    }

    private void Update()
    {
        text.text = player.score.ToString();
    }

    void SpawnCoin()
    {
        float tempPos = Random.Range(-maxPos, maxPos);
        Instantiate(coinPrefab, new Vector3(tempPos, 5.6f, 0), Quaternion.identity);
    }

    public void StopSpawningCoins()
    {
        CancelInvoke();
    }

    void SpawnBomb()
    {
        float tempPos = Random.Range(-maxPos, maxPos);
        Instantiate(bombPrefab, new Vector3(tempPos, 5.8f, 0), Quaternion.identity);
    }

    public void StopSpawningBombs()
    {
        CancelInvoke();
    }

}