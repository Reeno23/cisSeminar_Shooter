using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public float chaseSpeed = 5f;
    private GameObject protagonist;
    private float currentSpeed;

    void FixedUpdate()
    {
            currentSpeed = chaseSpeed * Time.deltaTime;
            protagonist = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, protagonist.transform.position, currentSpeed);
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
             
            //Time.timeScale = 0; // This is the pause time way.


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
            Destroy(gameObject);

            GlobalStats.enemiesKilled += 1;
        }
    }
}
