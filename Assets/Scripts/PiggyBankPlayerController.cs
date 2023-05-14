using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankPlayerController : MonoBehaviour
{
    public bool canMove = true;

    [SerializeField]
    float maxPos;

    [SerializeField]
    float moveSpeed;

    public int score = 0;
    public int lives = 3;

    private Rigidbody2D rigidBody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Coin")
        {
            score += 1;
            Destroy(collision.gameObject); //Coin destroyed when it touches the player
        }
        if(collision.tag=="Bomb")
        {
            lives -= 1;
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Move();
        }
    }

    public void Move()
    {

        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the position of the touch
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            // Calculate the new position of the player
            Vector2 newPosition = Vector2.Lerp(rigidBody.position, touchPosition, moveSpeed * Time.deltaTime);

            // Clamp the position to the game area boundaries
            newPosition.x = Mathf.Clamp(newPosition.x, -maxPos, maxPos);

            // Move the player to the new position
            rigidBody.MovePosition(newPosition);
        }

    }

}
