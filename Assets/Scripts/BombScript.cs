using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    //private int lives = 3;
    public PiggyBankPlayerController player;
    public CoinGameController gameController;
    public GameObject life1, life2, life3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            player.lives -= 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (player.lives)
        {
            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
            case 1:
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
            case 2:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(false);
                break;
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            default:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;

        }
        if (player.lives == 0)
        {
            //Debug.Log("Endgame");
            gameController.StopSpawningCoins();
            gameController.StopSpawningBombs();
        }
    }
}
