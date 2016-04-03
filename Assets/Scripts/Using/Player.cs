using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

     public float playerSpeed = 10; //speed player moves
     public float turnSpeed  = 100; // speed player turns
 
     void FixedUpdate () 
     {
 
         MoveForwardAndBack(); // Player Movement
         TurnRightAndLeft();//Player Turning
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