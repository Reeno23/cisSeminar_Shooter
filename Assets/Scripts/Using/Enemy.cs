using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed = 5f;
    private GameObject protagonist;
    private float currentSpeed;
    public Text score;
   // public GameObject ;
    public Text finalScore;
    public Button playAgain;
    public Button quit;
    public Canvas gameOver;
    public int game = 0;

    void Start()
    {
            gameOver = GetComponent<Canvas>();
    }

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
            int Fscore = (GlobalStats.enemiesKilled * 10) + GlobalStats.stopwatch.Elapsed.Seconds;
            GameObject.Find("EndGame").GetComponent<Canvas>().enabled = true;
            finalScore.text = "Good Job!\nYou Died!\nYou Gained:\n" + Fscore + " Points";
            Time.timeScale = 0; // This is the pause time way.
            score.transform.localScale = new Vector3(0, 0, 0);
            playAgain.GetComponent<Button>().onClick.AddListener(() => { newgame(); });
            quit.GetComponent<Button>().onClick.AddListener(() => { quitgame(); });
            /* Use these stats for game over screen. They're already being calculated properly.
            GlobalStats.enemiesKilled;
            GlobalStats.stopwatch.Elapsed.Seconds;
             * 
             */
        }
    }

    private void newgame()
    {
        GlobalStats.enemiesKilled = 0;
        SceneManager.LoadScene(0);
        GameObject.Find("EndGame").GetComponent<Canvas>().enabled = false;
        score.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 1;
    }
    private void quitgame()
    {
        Application.Quit();
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
