using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    //Movement Speed
    public float speed = 100.0f;
    public bool gameInProgress;
    public static int numLives = 3;
    public static int score = 0;
    public Transform livesTarget;
    public Transform scoreTarget;
    public GameObject racket;
    public float racketXPosition;

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // -1  -0.5  0  0.5   1  <- x value
        //  ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    // Use this for initialization
    void Start () {
        //Display initial score & lives
        livesTarget.GetComponent<Text>().text = "Lives: " + numLives;
        scoreTarget.GetComponent<Text>().text = "Score: " + score;
    }

    private void Update()
    {
        //press space to start game
        if (Input.GetKeyDown(KeyCode.Space) && !gameInProgress)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            gameInProgress = true;
        }

        //if ball passes y-position of paddle
        if(this.GetComponent<Transform>().position.y < -100)
        {
            //Reload
            SceneManager.LoadScene("arkanoid");
            gameInProgress = false;

            //take a life, if no more lives game over
            if (numLives > 0)
            {
                numLives--;
                livesTarget.GetComponent<Text>().text = "Lives: " + numLives;
                score = 0;
            }
            else
            {
                gameOver();
            }
        }

        if (!gameInProgress)
        {
            racketXPosition = racket.GetComponent<Transform>().position.x;
            transform.position =  new Vector2(racketXPosition,-86.27f);
        }
        //Display score
        scoreTarget.GetComponent<Text>().text = "Score: " + score;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //add score depending on colour of block
        if (col.gameObject.name.Contains("block"))
        {
            score++;
            speed += 2;
        }
    }

    void gameOver()
    {
        //Reset vars
        numLives = 3;
        gameInProgress = false;
        score = 0;
        speed = 100.0f;
    }
}
