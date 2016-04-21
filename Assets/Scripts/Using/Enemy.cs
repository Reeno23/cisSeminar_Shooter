using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public float chaseSpeed = 5f;
    private GameObject protagonist;
    public Text gameOverText;
    public Text yourScoreText;
    private float currentSpeed;

    private bool gameOver;

    void Start ()
    {
        gameOverText.text = "";
        gameOver = false;
    }

    void FixedUpdate()
    {
        if (!gameOver) {
                currentSpeed = chaseSpeed * Time.deltaTime;
                protagonist = GameObject.FindGameObjectWithTag("Player");
                transform.position = Vector3.MoveTowards(transform.position, protagonist.transform.position, currentSpeed);
        }
        else
        {
            //Incomplete attempt to allow restarting of the level
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

   // Kill protagonist. INSERT GAME OVER SCREEN HERE.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == protagonist)
        {

            //Destroy(protagonist);

            /* We can either pause time and open the game over screen.
            // Or, we can go through all gameobjects, pause them, and open the gameover screen. Whichever works. 
            // I'm guessing this pause approach will work. Title screen may not show when time isn't advancing.
            */

            
            gameOverText.text = "Game Over";
            yourScoreText.text = "Your score: " + GlobalStats.enemiesKilled.ToString() + " in " + GlobalStats.stopwatch.Elapsed.Seconds.ToString() + " seconds";
            gameOver = true;
            Time.timeScale = 0; // This is the pause time way.


            /* Use these stats for game over screen. They're already being calculated properly.
            GlobalStats.enemiesKilled;
            GlobalStats.stopwatch.Elapsed.Seconds;
             * 
             */
        }
    }

    // Destroy enemy & bullet if they collide.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);

            Destroy(gameObject.GetComponent<Enemy>());
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<Collider>());

            GlobalStats.enemiesKilled += 1;
        }
    }
}
