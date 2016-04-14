using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Player : MonoBehaviour
{

     public float playerSpeed = 10f; //speed player moves
     public float turnSpeed  = 100f; // speed player turns
     private bool speedEffected = false;


     void Start()
     {
         GlobalStats.stopwatch = new Stopwatch();
         GlobalStats.stopwatch.Start();
     }

     void FixedUpdate() 
     {
         MoveForwardAndBack(); // Player Movement
         TurnRightAndLeft();//Player Turning

         if (speedEffected)
         {
             StartCoroutine(pause());
         }
     }

     void MoveForwardAndBack()
     {
 
         if(Input.GetKey(KeyCode.W))//Press up arrow key to move forward on the Y AXIS
         {
             transform.Translate(0,playerSpeed * Time.deltaTime,0);
         }

         if (Input.GetKey(KeyCode.S))//Press up arrow key to move forward on the Y AXIS
         {
             transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
         }
 
     }
 
     void TurnRightAndLeft()
     {
 
         if(Input.GetKey(KeyCode.D)) //Right arrow key to turn right
         {
             transform.Rotate(-Vector3.forward *turnSpeed* Time.deltaTime);
         }
 
         if(Input.GetKey(KeyCode.A))//Left arrow key to turn left
         {
             transform.Rotate(Vector3.forward *turnSpeed* Time.deltaTime);
         }
     }

    // Speed up if we enter a fast floor object.
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "Fast Floor")
         {
             playerSpeed *= 1.5f;
             speedEffected = true;
         }
     }

    // Return speed back to normal after 5 seconds.
     IEnumerator pause()
     {
         speedEffected = false;
         yield return new WaitForSeconds(5);
         playerSpeed /= 1.5f;
     }














    /*
    public float speed = 1;

    void FixedUpdate()
    {
        moveX();
        moveY();
    }

    void moveY()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    void moveX()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    */
}